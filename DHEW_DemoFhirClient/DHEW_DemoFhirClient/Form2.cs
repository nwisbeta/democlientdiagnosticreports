using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using Hl7.Fhir.Model;
using Hl7.Fhir.Rest;

namespace DHEW_DemoFhirClient
{
	public partial class Form2 : Form
	{
		private readonly string _patientId;
		private readonly string _observationCode;
				
		public Form2(string patientId, string observationCode)
		{
			InitializeComponent();
			_patientId = patientId;
			_observationCode = observationCode;
		}

		private void Form2_Load(object sender, EventArgs e)
		{
			var patientId = _patientId;
			var observationCode = _observationCode;

			var client = new FhirClient(" https://dhew.wales.nhs.uk/hapi-fhir-jpaserver-example/baseDstu3");
			Bundle observationBundle = client.Search<Observation>(new string[]
			{
				$"patient={patientId}",
				$"code=http://wrrs.wales.nhs.uk|{observationCode}"
			});

            // call the method to draw the graph...
			ChartObservations(observationBundle);
		}


		private void ChartObservations(Bundle observationsBundle)
		{
			var obsList = new List<Observation>();
			foreach (Bundle.EntryComponent entryComponent in observationsBundle.Entry)
			{
				Observation obs = entryComponent.Resource as Observation;
				var valueElementValue = ((Quantity)obs?.Value)?.ValueElement.Value;

				if (valueElementValue.HasValue)
				{
					// ReSharper disable once ConstantConditionalAccessQualifier
					var fhirDateTime = (FhirDateTime)obs?.Effective;
					if (fhirDateTime != null)
					{
						obsList.Add(obs);
					}
				}
			}


			List<Observation> sortedObsList = obsList.OrderBy(o => (o.Effective as FhirDateTime).ToDateTime()).ToList();

			string seriesName = sortedObsList[0].Code.Text;
			string units = (sortedObsList[0].Value as Quantity).Unit;

			Series s = new Series
			{
				ChartType = SeriesChartType.Line,
				XValueType = ChartValueType.DateTime,
				Name = seriesName,
				BorderWidth = 3
			};
			Series sLow = new Series
			{
				ChartType = SeriesChartType.Line,
				XValueType = ChartValueType.DateTime,
				Name = "Ref range low",				
				BorderWidth = 2
			};
			Series sHigh = new Series
			{
				ChartType = SeriesChartType.Line,
				XValueType = ChartValueType.DateTime,
				Name = "Ref range high",
				BorderWidth = 2
			};

			foreach (Observation obs in sortedObsList)
			{
				// ReSharper disable once PossibleInvalidOperationException
				var dt = (obs.Effective as FhirDateTime).ToDateTime().Value;
				var value = ((Quantity)obs.Value).ValueElement.Value;
				s.Points.AddXY(dt.ToOADate(), value);

				var valueLo = obs.ReferenceRange[0].Low.Value;
				if (valueLo.HasValue) sLow.Points.AddXY(dt.ToOADate(), valueLo);

				var valueHigh = obs.ReferenceRange[0].High.Value;
				if (valueLo.HasValue) sHigh.Points.AddXY(dt.ToOADate(), valueHigh);



			}

			chartObservations.Series.Add(s);
			chartObservations.Series.Add(sLow);
			chartObservations.Series.Add(sHigh);
			chartObservations.ChartAreas[0].AxisY.Title = units;
			chartObservations.Show();
		}

    }
}
