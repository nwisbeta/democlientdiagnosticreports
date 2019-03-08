# DHEW Demo FHIR Client
This is a simple .NET Windows Forms application to demonstrate the DHEW FHIR API. It shows how we can:
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

1. Click 'Find Patient Record' to find the patient with NHS no: **3795624164**. The display shows the patient's details. *Note that other dummy NHS numbers are provided within the code comments.* 
2. Click 'Show Test Results' to view a list of diagnostic test reports for the patient.

![][image2]

3. Select one of the test reports to view. The drop-down list below the test report includes the result items for that selected report.
4. Select a result item e.g. Haemoglobin (Hb), and click 'Draw Graph'.

![][image3]

## Understanding the solution a little deeper ##
**NuGet packages**

This solution uses the following NuGet packages:

| NuGet Package            | Description           |
| :----------------------- |:----------------------|
| Hl7.Fhir.STU3            | This is the core support library for HL7's FHIR standard (http://hl7.org/fhir). It contains the core functionality to working with RESTful FHIR servers: POCO classes for FHIR, parsing/serialization of FHIR data and a FhirClient for easy access to FHIR servers.    |
| HtmlRenderer.WinForms    | HTML UI in .NET WinForms applications using controls or static rendering. This package provides a control to view HTML within a Windows Forms application    |


**FHIR server client**

The FHIR server is the DHEW server at https://dhew.wales.nhs.uk/hapi-fhir-jpaserver-example/baseDstu3. The `DhewServer` variable is set to this value, and the `client` variable is declared as follows:

`FhirClient client = new FhirClient(DhewServer);`


**Patient search**

This code retrieves patient records with the NHS number entered by the user in the `txtNHSno` control. There's no validation. We assume that the server returns only one patient record.

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

This code retrieves the test reports for the patient. We then iterate through the reports to add them to the list. 

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

When you select a test report from the list, you retrive the report from the API using its id. The HTML panel source is set with the HTML provided in the `DiagnosticReport.Text.Div` property. Note that in real life you would probably not use this value - rather you would construct the view of the test report using the data contained within the `DiagnosticReport` resource. 

Our demo solution example  iterates through the `Observation` resources contained within the report to display the observation codes within the drop-down list.

```
DiagnosticReport diagnosticReport = client.Read<DiagnosticReport>(fhirRef);
_htmlPanel.Text = diagnosticReport.Text.Div;
```

**Draw a graph of the selected results**

Form2 within the solution draws the chart. It contains a method called `ChartObservations` to draw the graph using the WinForms Chart control. To retrieve the observations containing the diagnostic results for the selected patient, and for the selected observation code use this code.

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
