using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows.Forms;
using Hl7.Fhir.Model;
using Hl7.Fhir.Rest;
using TheArtOfDev.HtmlRenderer.WinForms;

namespace DHEW_DemoFhirClient
{
	public partial class Form1 : Form
	{
		private readonly HtmlPanel _htmlPanel = new HtmlPanel();
		private const string DhewServer = "https://dhew.wales.nhs.uk/hapi-fhir-jpaserver-example/baseDstu3";

		private Patient patient;

		FhirClient client = new FhirClient(DhewServer);

		public Form1()
		{
			InitializeComponent();
		}

		private void Form1_Load(object sender, EventArgs e)
		{
			_htmlPanel.Dock = DockStyle.Fill;
			panel1.Controls.Add(_htmlPanel);
		}

		private void btnFindPatient_Click(object sender, EventArgs e)
		{

			ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };

			// find a patient record based on NHS number
			Bundle results = client.Search<Patient>(new string[]
			{
				$"identifier=https://fhir.nhs.uk/Id/nhs-number|{txtNHSno.Text}"
			});


			// display the patient's name and date of bith in the demographcis label			
			if (results.Total.HasValue && results.Total.Value == 1)
			{
				patient = results.Entry[0].Resource as Patient;

				var familyName = patient.Name[0].Family.ToUpper();
				var givenName = patient.Name[0].Given.FirstOrDefault();
				var dob = patient.BirthDateElement.ToDateTime().Value.ToString("dd-MMM-yyyy");

				string nhs = "";
				string formatedNhs = "";
				foreach (Identifier identifier in patient.Identifier)
				{
					if (identifier.System == "https://fhir.nhs.uk/Id/nhs-number")
					{
						nhs = identifier.Value;
						formatedNhs = $"{nhs.Substring(0, 3)} {nhs.Substring(3, 3)} {nhs.Substring(6, 4)}";
						break;
					}
				}
				

				lblName.Text = $@"{familyName}, {givenName}";
				lblBorn.Text = dob;
				lblNhsNo.Text = formatedNhs;

			}
		}

		private void btnShowTestResults_Click(object sender, EventArgs e)
		{
			// get test results for patient
			// find a patient record based on NHS number
			Bundle results = client.Search<DiagnosticReport>(new string[]
			{
				$"patient={patient.Id}"
			});

			foreach (Bundle.EntryComponent entryComponent in results.Entry)
			{
				DiagnosticReport report = entryComponent.Resource as DiagnosticReport;
				string testReportId = report.Id;
				string test =
					report.GetExtension("http://wales.nhs.uk/fhir/extensions/DiagnosticReport-WrrsReportTitle").Value.ToString();
				string effectiveDate = ((FhirDateTime) report.Effective).ToDateTime().Value.ToString("dd-MMM-yyyy");
				string organisation = "";
				DiagnosticReport.PerformerComponent firstOrDefault = report.Performer.FirstOrDefault();
				if (firstOrDefault != null)
				{
					organisation = firstOrDefault.Actor.Display;
				}

				var lvi = new ListViewItem(testReportId);
				lvi.SubItems.Add(test);
				lvi.SubItems.Add(effectiveDate);
				lvi.SubItems.Add(organisation);
				lstTestResults.Items.Add(lvi);
			}
		}

		private void lstTestResults_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (lstTestResults.SelectedItems.Count == 1)
			{
				string diagnosticReportId = lstTestResults.SelectedItems[0].Text;
				string fhirRef = $"DiagnosticReport/{diagnosticReportId}";
				DiagnosticReport diagnosticReport = client.Read<DiagnosticReport>(fhirRef);
				_htmlPanel.Text = diagnosticReport.Text.Div;

				//cboObservations.Items.Clear();
				Dictionary<string, string> obsDictionary = new Dictionary<string, string>();
				foreach (Resource resource in diagnosticReport.Contained)
				{
					if (resource.TypeName == "Observation")
					{
						Observation observation = (Observation) resource;
						CodeableConcept firstOrDefault = observation.Category.FirstOrDefault();
						Coding orDefault = firstOrDefault?.Coding.FirstOrDefault();
						if (orDefault != null && (firstOrDefault != null && orDefault.Code == "laboratory"))
						{
							string observationCode = observation.Code.Coding.FirstOrDefault().Code;
							string observationDisplay = observation.Code.Coding.FirstOrDefault().Display;

							if (!obsDictionary.ContainsKey(observationCode)) obsDictionary.Add(observationCode, observationDisplay);
						}
					}
				}
				cboObservations.DataSource = new BindingSource(obsDictionary, null);
				cboObservations.DisplayMember = "Value";
				cboObservations.ValueMember = "Key";
			}
		}

		private void btnGraph_Click(object sender, EventArgs e)
		{
			string observationCode = ((KeyValuePair<string, string>)cboObservations.SelectedItem).Key;
			string observationValue = ((KeyValuePair<string, string>)cboObservations.SelectedItem).Value;
			string familyName = patient.Name[0].Family.ToUpper();
			string givenName = patient.Name[0].Given.FirstOrDefault();


			Form2 frmGraph = new Form2(patient.Id, observationCode);
			frmGraph.Text = $"{familyName}, {givenName}: {observationValue}";
			
		

			frmGraph.Show();
		}
	}
}
