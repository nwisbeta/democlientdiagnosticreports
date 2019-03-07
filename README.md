# DHEW Demo FHIR Client
This is a simple .NET Windows Forms application that demonstrates the use of the DHEW FHIR API. It's intended to demonstrate how we can do the following:
* Retrieve a patient's record based on an NHS number
* Display a list of diagnostic test report for the patient
* View a test report
* Draw a graph of one or more results within the report

## Development requirements ##

* Visual Studio 2017
* .NET Framework 4.6  

## Getting the demo application up and running ##

1. Clone from the GitHub repository: https://github.com/nwisbeta/democlientdiagnosticreports and then open in Visual Studio 2017.
2. Right click the solution 'DHEW_DemoFhirClient' and select 'Restore Nuget packages'. 
3. Hit 'F6' to build the solution.
4. Hit 'F5' to run the solution.

## View a test report and display a graph ##

1. Hit the 'Find Patient Record' button to find the patient with NHS no: **3795624164**. The patient's details are displayed. *Note that other dummy NHS numbers are provided within the code comments.* 
2. To display a list of diagnostic test reports for the patient hit the 'Show Test Results' button.

![][image2]

3. Select one of the test reports to view. Note that the drop-down list below the test report include the result items for that selected report.
4. Select a result item e.g. Haemoglobin (Hb), and hit the 'Draw Graph' button.

![][image3]

## Understanding the solution a little deeper ##
**NuGet packages**

The following NuGet packages are used in this solution:

| NuGet Package            | Description           |
| :----------------------- |:----------------------|
| Hl7.Fhir.STU3            | This is the core support library for HL7's FHIR standard (http://hl7.org/fhir). It contains the core functionality to working with RESTful FHIR servers: POCO classes for FHIR, parsing/serialization of FHIR data and a FhirClient for easy access to FHIR servers.    |
| HtmlRenderer.WinForms    | HTML UI in .NET WinForms applications using controls or static rendering. This package provides a control to view HTML within a Windows Forms application    |


**FHIR server client**

The FHIR server is the DHEW server at https://dhew.wales.nhs.uk/hapi-fhir-jpaserver-example/baseDstu3. The `DhewServer` variable is set to this value, and the `client` variable is declared as follows:

`FhirClient client = new FhirClient(DhewServer);`


**Patient search**

The following code is used to retrieve patient records with the NHS number entered by the user in the `txtNHSno` control. There's no validation and we assume that there is only one patient record is returned

```
// find a patient record based on NHS number
Bundle results = client.Search<Patient>(new string[]
{
  $"identifier=https://fhir.nhs.uk/Id/nhs-number|{txtNHSno.Text}"
});

// retrieve the patient record from the search results
var patient = reresults.Entry[0].Resource as Patient;
```


**Get diagnostic test reports for the patient**

The following code is used to retrieve the test reports for the patient. We then iterate through the reports to add them to the list. 

```
Bundle results = client.Search<DiagnosticReport>(new string[]
{
  $"patient={patient.Id}"
});

foreach (Bundle.EntryComponent entryComponent in results.Entry)
{
  // add the DiagnosticReport to the list...
  DiagnosticReport report = entryComponent.Resource as DiagnosticReport;
```


**Retrieve the selected report**

When the user selects a test report from the list, we retrive the report from the API using its id. The HTML panel source is set with the HTML provided in the `DiagnosticReport.Text.Div` property. Note that in real life we would probably not use this value - rather we would construct the view of the test report using the data contained within the `DiagnosticReport` resource. 

In our demo solution example  we iterate through the `Observation` resources contained within the report to display the observation codes within the drop-down list.

```
DiagnosticReport diagnosticReport = client.Read<DiagnosticReport>(fhirRef);
_htmlPanel.Text = diagnosticReport.Text.Div;
```

**Draw a graph of the selected results**

Form2 within the solution is used to draw the chart, and contains a method called `ChartObservations` to take care of drawing the graph using the WinForms Chart control. To retrieve the observations containing the diagnostic results for the selected patient, and for the selected observation code the following code is used.

```
Bundle observationBundle = client.Search<Observation>(new string[]
{
  $"patient={patientId}",
  $"code=http://wrrs.wales.nhs.uk|{observationCode}"
});

// call the method to draw the graph...
ChartObservations(observationBundle);
```

[image1]: https://github.com/nwisbeta/democlientdiagnosticreports/blob/master/DHEW_DemoFhirClient/Images/DHEW_DemoFhirClient1.png "DHEW Demo App"
[image2]: https://github.com/nwisbeta/democlientdiagnosticreports/blob/master/DHEW_DemoFhirClient/Images/DHEW_DemoFhirClient2.png "DHEW Demo App"
[image3]: https://github.com/nwisbeta/democlientdiagnosticreports/blob/master/DHEW_DemoFhirClient/Images/HaemoglobinChart.png "DHEW Demo App"
