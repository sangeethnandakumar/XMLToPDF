using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace PDF.Layout
{
	[XmlRoot(ElementName = "FirstName")]
	public class FirstName
	{

		[XmlElement(ElementName = "Part")]
		public string Part { get; set; }

		[XmlElement(ElementName = "PartType")]
		public string PartType { get; set; }
	}

	[XmlRoot(ElementName = "LastName")]
	public class LastName
	{

		[XmlElement(ElementName = "Part")]
		public string Part { get; set; }

		[XmlElement(ElementName = "PartType")]
		public string PartType { get; set; }
	}

	[XmlRoot(ElementName = "LegalName")]
	public class LegalName
	{

		[XmlElement(ElementName = "FirstName")]
		public FirstName FirstName { get; set; }

		[XmlElement(ElementName = "LastName")]
		public LastName LastName { get; set; }

		[XmlAttribute(AttributeName = "namePurpose")]
		public string NamePurpose { get; set; }

		[XmlText]
		public string Text { get; set; }
	}

	[XmlRoot(ElementName = "Names")]
	public class Names
	{

		[XmlElement(ElementName = "NamePrefix")]
		public string NamePrefix { get; set; }

		[XmlElement(ElementName = "LegalName")]
		public LegalName LegalName { get; set; }
	}

	[XmlRoot(ElementName = "HealthCard")]
	public class HealthCard
	{

		[XmlElement(ElementName = "Number")]
		public double Number { get; set; }

		[XmlElement(ElementName = "ProvinceCode")]
		public string ProvinceCode { get; set; }

		[XmlElement(ElementName = "Version")]
		public string Version { get; set; }

		[XmlElement(ElementName = "Expirydate")]
		public DateTime Expirydate { get; set; }
	}

	[XmlRoot(ElementName = "PostalZipCode")]
	public class PostalZipCode
	{

		[XmlElement(ElementName = "PostalCode")]
		public string PostalCode { get; set; }
	}

	[XmlRoot(ElementName = "Structured")]
	public class Structured
	{

		[XmlElement(ElementName = "Line1")]
		public string Line1 { get; set; }

		[XmlElement(ElementName = "City")]
		public string City { get; set; }

		[XmlElement(ElementName = "CountrySubdivisionCode")]
		public string CountrySubdivisionCode { get; set; }

		[XmlElement(ElementName = "PostalZipCode")]
		public PostalZipCode PostalZipCode { get; set; }
	}

	[XmlRoot(ElementName = "Address")]
	public class Address
	{

		[XmlElement(ElementName = "Structured")]
		public Structured Structured { get; set; }

		[XmlAttribute(AttributeName = "addressType")]
		public string AddressType { get; set; }

		[XmlText]
		public string Text { get; set; }
	}

	//[XmlRoot(ElementName = "PhoneNumber")]
	//public class MPhoneNumber
	//{

	//	[XmlElement(ElementName = "phoneNumber")]
	//	public double PhoneNumber { get; set; }

	//	[XmlElement(ElementName = "extension")]
	//	public object Extension { get; set; }

	//	[XmlAttribute(AttributeName = "phoneNumberType")]
	//	public string PhoneNumberType { get; set; }

	//	[XmlText]
	//	public double Text { get; set; }
	//}

	[XmlRoot(ElementName = "Enrolment")]
	public class Enrolment
	{

		[XmlElement(ElementName = "EnrollmentStatus")]
		public string EnrollmentStatus { get; set; }

		[XmlElement(ElementName = "EnrollmentDate")]
		public DateTime EnrollmentDate { get; set; }
	}

	[XmlRoot(ElementName = "Name")]
	public class Name
	{

		[XmlElement(ElementName = "FirstName")]
		public string FirstName { get; set; }

		[XmlElement(ElementName = "LastName")]
		public string LastName { get; set; }
	}

	[XmlRoot(ElementName = "ResultNormalAbnormalFlag")]
	public class ResultNormalAbnormalFlag
	{

		[XmlElement(ElementName = "resultNormalAbnormalFlagAsEnum")]
		public string ResultNormalAbnormalFlagAsEnum { get; set; }
	}

	[XmlRoot(ElementName = "PrimaryPhysician")]
	public class PrimaryPhysician
	{

		[XmlElement(ElementName = "OHIPPhysicianId")]
		public string OHIPPhysicianId { get; set; }

		[XmlElement(ElementName = "Name")]
		public Name Name { get; set; }

		[XmlElement(ElementName = "PrimaryPhysicianCPSO")]
		public string PrimaryPhysicianCPSO { get; set; }
	}

	[XmlRoot(ElementName = "PersonStatusCode")]
	public class PersonStatusCode
	{

		[XmlElement(ElementName = "PersonStatusAsEnum")]
		public string PersonStatusAsEnum { get; set; }
	}

	[XmlRoot(ElementName = "Demographics")]
	public class Demographics
	{

		[XmlElement(ElementName = "Names")]
		public Names Names { get; set; }

		[XmlElement(ElementName = "DateOfBirth")]
		public DateTime DateOfBirth { get; set; }

		[XmlElement(ElementName = "HealthCard")]
		public HealthCard HealthCard { get; set; }

		[XmlElement(ElementName = "ChartNumber")]
		public string ChartNumber { get; set; }

		[XmlElement(ElementName = "Gender")]
		public string Gender { get; set; }

		[XmlElement(ElementName = "UniqueVendorIdSequence")]
		public string UniqueVendorIdSequence { get; set; }

		[XmlElement(ElementName = "Address")]
		public Address Address { get; set; }

		//[XmlElement(ElementName = "PhoneNumber")]
		//public List<MPhoneNumber> PhoneNumber { get; set; }

		[XmlElement(ElementName = "PreferredOfficialLanguage")]
		public string PreferredOfficialLanguage { get; set; }

		[XmlElement(ElementName = "PreferredSpokenLanguage")]
		public string PreferredSpokenLanguage { get; set; }

		[XmlElement(ElementName = "Enrolment")]
		public Enrolment Enrolment { get; set; }

		[XmlElement(ElementName = "PrimaryPhysician")]
		public PrimaryPhysician PrimaryPhysician { get; set; }

		[XmlElement(ElementName = "Email")]
		public string Email { get; set; }

		[XmlElement(ElementName = "PersonStatusCode")]
		public PersonStatusCode PersonStatusCode { get; set; }

		[XmlElement(ElementName = "PersonStatusDate")]
		public DateTime PersonStatusDate { get; set; }
	}

	[XmlRoot(ElementName = "FamilyHistory")]
	public class FamilyHistory
	{

		[XmlElement(ElementName = "CategorySummaryLine")]
		public string CategorySummaryLine { get; set; }

		[XmlElement(ElementName = "ProblemDiagnosisProcedureDescription")]
		public string ProblemDiagnosisProcedureDescription { get; set; }
	}

	[XmlRoot(ElementName = "PastHealth")]
	public class PastHealth
	{

		[XmlElement(ElementName = "CategorySummaryLine")]
		public string CategorySummaryLine { get; set; }

		[XmlElement(ElementName = "PastHealthProblemDescriptionOrProcedures")]
		public string PastHealthProblemDescriptionOrProcedures { get; set; }

		[XmlElement(ElementName = "Notes")]
		public string Notes { get; set; }

		[XmlElement(ElementName = "LifeStage")]
		public string LifeStage { get; set; }

		[XmlElement(ElementName = "ProcedureDate")]
		public ProcedureDate ProcedureDate { get; set; }
	}

	[XmlRoot(ElementName = "ProcedureDate")]
	public class ProcedureDate
	{

		[XmlElement(ElementName = "FullDate")]
		public DateTime FullDate { get; set; }
	}

	[XmlRoot(ElementName = "OnsetDate")]
	public class OnsetDate
	{

		[XmlElement(ElementName = "FullDate")]
		public DateTime FullDate { get; set; }
	}

	[XmlRoot(ElementName = "ProblemList")]
	public class ProblemList
	{

		[XmlElement(ElementName = "CategorySummaryLine")]
		public string CategorySummaryLine { get; set; }

		[XmlElement(ElementName = "ProblemDiagnosisDescription")]
		public string ProblemDiagnosisDescription { get; set; }

		[XmlElement(ElementName = "OnsetDate")]
		public OnsetDate OnsetDate { get; set; }

		[XmlElement(ElementName = "Notes")]
		public string Notes { get; set; }

		[XmlElement(ElementName = "ProblemStatus")]
		public string ProblemStatus { get; set; }
	}

	[XmlRoot(ElementName = "RecordedDate")]
	public class RecordedDate
	{

		[XmlElement(ElementName = "FullDate")]
		public DateTime FullDate { get; set; }
	}

	[XmlRoot(ElementName = "AllergiesAndAdverseReactions")]
	public class AllergiesAndAdverseReactions
	{

		[XmlElement(ElementName = "CategorySummaryLine")]
		public string CategorySummaryLine { get; set; }

		[XmlElement(ElementName = "OffendingAgentDescription")]
		public string OffendingAgentDescription { get; set; }

		[XmlElement(ElementName = "PropertyOfOffendingAgent")]
		public string PropertyOfOffendingAgent { get; set; }

		[XmlElement(ElementName = "RecordedDate")]
		public RecordedDate RecordedDate { get; set; }
	}

	[XmlRoot(ElementName = "PrescriptionWrittenDate")]
	public class PrescriptionWrittenDate
	{

		[XmlElement(ElementName = "FullDate")]
		public DateTime FullDate { get; set; }
	}

	[XmlRoot(ElementName = "Strength")]
	public class Strength
	{

		[XmlElement(ElementName = "Amount")]
		public double Amount { get; set; }

		[XmlElement(ElementName = "UnitOfMeasure")]
		public string UnitOfMeasure { get; set; }
	}

	[XmlRoot(ElementName = "LongTermMedication")]
	public class LongTermMedication
	{

		[XmlElement(ElementName = "boolean")]
		public bool Boolean { get; set; }
	}

	[XmlRoot(ElementName = "PastMedications")]
	public class PastMedications
	{

		[XmlElement(ElementName = "boolean")]
		public bool Boolean { get; set; }
	}

	[XmlRoot(ElementName = "PatientCompliance")]
	public class PatientCompliance
	{

		[XmlElement(ElementName = "blank")]
		public object Blank { get; set; }

		[XmlElement(ElementName = "boolean")]
		public bool Boolean { get; set; }
	}

	[XmlRoot(ElementName = "DataElement")]
	public class DataElement
	{

		[XmlElement(ElementName = "Name")]
		public string Name { get; set; }

		[XmlElement(ElementName = "DataType")]
		public string DataType { get; set; }

		[XmlElement(ElementName = "Content")]
		public string Content { get; set; }
	}

	[XmlRoot(ElementName = "ResidualInfo")]
	public class ResidualInfo
	{

		[XmlElement(ElementName = "DataElement")]
		public List<DataElement> DataElement { get; set; }
	}

	[XmlRoot(ElementName = "StartDate")]
	public class StartDate
	{

		[XmlElement(ElementName = "FullDate")]
		public DateTime FullDate { get; set; }
	}

	[XmlRoot(ElementName = "PrescribedBy")]
	public class PrescribedBy
	{

		[XmlElement(ElementName = "Name")]
		public Name Name { get; set; }

		[XmlElement(ElementName = "OHIPPhysicianId")]
		public int OHIPPhysicianId { get; set; }
	}

	[XmlRoot(ElementName = "MedicationsAndTreatments")]
	public class MedicationsAndTreatments
	{

		[XmlElement(ElementName = "ResidualInfo")]
		public ResidualInfo ResidualInfo { get; set; }

		[XmlElement(ElementName = "StartDate")]
		public StartDate StartDate { get; set; }

		[XmlElement(ElementName = "DrugName")]
		public string DrugName { get; set; }

		[XmlElement(ElementName = "NumberOfRefills")]
		public int NumberOfRefills { get; set; }

		[XmlElement(ElementName = "Dosage")]
		public string Dosage { get; set; }

		[XmlElement(ElementName = "Route")]
		public string Route { get; set; }

		[XmlElement(ElementName = "Frequency")]
		public string Frequency { get; set; }

		[XmlElement(ElementName = "LongTermMedication")]
		public LongTermMedication LongTermMedication { get; set; }

		[XmlElement(ElementName = "PastMedications")]
		public PastMedications PastMedications { get; set; }

		[XmlElement(ElementName = "PrescribedBy")]
		public PrescribedBy PrescribedBy { get; set; }

		[XmlElement(ElementName = "NonAuthoritativeIndicator")]
		public string NonAuthoritativeIndicator { get; set; }

		[XmlElement(ElementName = "SubstitutionNotAllowed")]
		public string SubstitutionNotAllowed { get; set; }
	}

	[XmlRoot(ElementName = "Date")]
	public class Date
	{

		[XmlElement(ElementName = "FullDate")]
		public DateTime FullDate { get; set; }
	}

	[XmlRoot(ElementName = "RefusedFlag")]
	public class RefusedFlag
	{

		[XmlElement(ElementName = "boolean")]
		public bool Boolean { get; set; }
	}

	[XmlRoot(ElementName = "Immunizations")]
	public class Immunizations
	{

		[XmlElement(ElementName = "CategorySummaryLine")]
		public string CategorySummaryLine { get; set; }

		[XmlElement(ElementName = "ImmunizationName")]
		public string ImmunizationName { get; set; }

		[XmlElement(ElementName = "Site")]
		public string Site { get; set; }

		[XmlElement(ElementName = "Dose")]
		public string Dose { get; set; }

		[XmlElement(ElementName = "Date")]
		public Date Date { get; set; }

		[XmlElement(ElementName = "RefusedFlag")]
		public RefusedFlag RefusedFlag { get; set; }

		[XmlElement(ElementName = "Notes")]
		public string Notes { get; set; }

		[XmlElement(ElementName = "ImmunizationType")]
		public string ImmunizationType { get; set; }

		[XmlElement(ElementName = "LotNumber")]
		public string LotNumber { get; set; }

		[XmlElement(ElementName = "Route")]
		public string Route { get; set; }

		[XmlElement(ElementName = "Manufacturer")]
		public string Manufacturer { get; set; }
	}

	[XmlRoot(ElementName = "Result")]
	public class Result
	{

		[XmlElement(ElementName = "Value")]
		public string Value { get; set; }

		[XmlElement(ElementName = "UnitOfMeasure")]
		public string UnitOfMeasure { get; set; }
	}

	[XmlRoot(ElementName = "ReferenceRange")]
	public class ReferenceRange
	{

		[XmlElement(ElementName = "ReferenceRangeText")]
		public string ReferenceRangeText { get; set; }
	}

	[XmlRoot(ElementName = "CollectionDateTime")]
	public class CollectionDateTime
	{

		[XmlElement(ElementName = "FullDateTime")]
		public DateTime FullDateTime { get; set; }
	}

	[XmlRoot(ElementName = "DateTimeResultReviewed")]
	public class DateTimeResultReviewed
	{

		[XmlElement(ElementName = "FullDateTime")]
		public DateTime FullDateTime { get; set; }
	}

	[XmlRoot(ElementName = "ResultReviewer")]
	public class ResultReviewer
	{

		[XmlElement(ElementName = "Name")]
		public Name Name { get; set; }

		[XmlElement(ElementName = "OHIPPhysicianId")]
		public string OHIPPhysicianId { get; set; }

		[XmlElement(ElementName = "DateTimeResultReviewed")]
		public DateTimeResultReviewed DateTimeResultReviewed { get; set; }
	}

	[XmlRoot(ElementName = "LaboratoryResults")]
	public class LaboratoryResults
	{

		[XmlElement(ElementName = "LaboratoryName")]
		public string LaboratoryName { get; set; }

		[XmlElement(ElementName = "TestNameReportedByLab")]
		public string TestNameReportedByLab { get; set; }

		[XmlElement(ElementName = "LabTestCode")]
		public string LabTestCode { get; set; }

		[XmlElement(ElementName = "AccessionNumber")]
		public string AccessionNumber { get; set; }

		[XmlElement(ElementName = "Result")]
		public Result Result { get; set; }

		[XmlElement(ElementName = "ReferenceRange")]
		public ReferenceRange ReferenceRange { get; set; }

		[XmlElement(ElementName = "CollectionDateTime")]
		public CollectionDateTime CollectionDateTime { get; set; }

		[XmlElement(ElementName = "ResultReviewer")]
		public ResultReviewer ResultReviewer { get; set; }

		[XmlElement(ElementName = "ResultNormalAbnormalFlag")]
		public ResultNormalAbnormalFlag ResultNormalAbnormalFlag { get; set; }

		[XmlElement(ElementName = "NotesFromLab")]
		public string NotesFromLab { get; set; }

		[XmlElement(ElementName = "LabRequisitionDateTime")]
		public LabRequisitionDateTime LabRequisitionDateTime { get; set; }

		[XmlElement(ElementName = "OLISTestResultStatus")]
		public string OLISTestResultStatus { get; set; }
	}

	[XmlRoot(ElementName = "LabRequisitionDateTime")]
	public class LabRequisitionDateTime
	{

		[XmlElement(ElementName = "FullDateTime")]
		public DateTime FullDateTime { get; set; }
	}

	[XmlRoot(ElementName = "AppointmentDate")]
	public class AppointmentDate
	{

		[XmlElement(ElementName = "FullDate")]
		public DateTime FullDate { get; set; }
	}

	[XmlRoot(ElementName = "Provider")]
	public class Provider
	{

		[XmlElement(ElementName = "OHIPPhysicianId")]
		public object OHIPPhysicianId { get; set; }

		[XmlElement(ElementName = "Name")]
		public Name Name { get; set; }
	}

	[XmlRoot(ElementName = "Appointments")]
	public class Appointments
	{

		[XmlElement(ElementName = "AppointmentTime")]
		public DateTime AppointmentTime { get; set; }

		[XmlElement(ElementName = "Duration")]
		public string Duration { get; set; }

		[XmlElement(ElementName = "AppointmentStatus")]
		public string AppointmentStatus { get; set; }

		[XmlElement(ElementName = "AppointmentDate")]
		public AppointmentDate AppointmentDate { get; set; }

		[XmlElement(ElementName = "Provider")]
		public Provider Provider { get; set; }

		[XmlElement(ElementName = "AppointmentNotes")]
		public string AppointmentNotes { get; set; }

		[XmlElement(ElementName = "AppointmentPurpose")]
		public string AppointmentPurpose { get; set; }
	}

	[XmlRoot(ElementName = "EventDateTime")]
	public class EventDateTime
	{

		[XmlElement(ElementName = "FullDateTime")]
		public DateTime FullDateTime { get; set; }
	}

	[XmlRoot(ElementName = "EnteredDateTime")]
	public class EnteredDateTime
	{

		[XmlElement(ElementName = "FullDateTime")]
		public DateTime FullDateTime { get; set; }
	}

	[XmlRoot(ElementName = "DateTimeNoteCreated")]
	public class DateTimeNoteCreated
	{

		[XmlElement(ElementName = "FullDateTime")]
		public DateTime FullDateTime { get; set; }
	}

	[XmlRoot(ElementName = "ParticipatingProviders")]
	public class ParticipatingProviders
	{

		[XmlElement(ElementName = "Name")]
		public Name Name { get; set; }

		[XmlElement(ElementName = "OHIPPhysicianId")]
		public string OHIPPhysicianId { get; set; }

		[XmlElement(ElementName = "DateTimeNoteCreated")]
		public DateTimeNoteCreated DateTimeNoteCreated { get; set; }
	}

	[XmlRoot(ElementName = "ClinicalNotes")]
	public class ClinicalNotes
	{

		[XmlElement(ElementName = "MyClinicalNotesContent")]
		public string MyClinicalNotesContent { get; set; }

		[XmlElement(ElementName = "EventDateTime")]
		public EventDateTime EventDateTime { get; set; }

		[XmlElement(ElementName = "EnteredDateTime")]
		public EnteredDateTime EnteredDateTime { get; set; }

		[XmlElement(ElementName = "ParticipatingProviders")]
		public List<ParticipatingProviders> ParticipatingProviders { get; set; }

		[XmlElement(ElementName = "NoteReviewer")]
		public List<NoteReviewer> NoteReviewer { get; set; }
	}

	[XmlRoot(ElementName = "DateTimeNoteReviewed")]
	public class DateTimeNoteReviewed
	{

		[XmlElement(ElementName = "FullDateTime")]
		public DateTime FullDateTime { get; set; }
	}

	[XmlRoot(ElementName = "NoteReviewer")]
	public class NoteReviewer
	{

		[XmlElement(ElementName = "Name")]
		public Name Name { get; set; }

		[XmlElement(ElementName = "OHIPPhysicianId")]
		public object OHIPPhysicianId { get; set; }

		[XmlElement(ElementName = "DateTimeNoteReviewed")]
		public DateTimeNoteReviewed DateTimeNoteReviewed { get; set; }
	}

	[XmlRoot(ElementName = "Content")]
	public class Content
	{

		[XmlElement(ElementName = "Media")]
		public string Media { get; set; }
		public List<string> PDFPages { get; set; }
	}

	[XmlRoot(ElementName = "ReceivedDateTime")]
	public class ReceivedDateTime
	{

		[XmlElement(ElementName = "FullDateTime")]
		public DateTime FullDateTime { get; set; }
	}

	[XmlRoot(ElementName = "AuthorName")]
	public class AuthorName
	{

		[XmlElement(ElementName = "FirstName")]
		public string FirstName { get; set; }

		[XmlElement(ElementName = "LastName")]
		public string LastName { get; set; }
	}

	[XmlRoot(ElementName = "SourceAuthorPhysician")]
	public class SourceAuthorPhysician
	{

		[XmlElement(ElementName = "AuthorName")]
		public AuthorName AuthorName { get; set; }
	}

	[XmlRoot(ElementName = "Reports")]
	public class ReportsReceived
	{

		[XmlElement(ElementName = "Format")]
		public string Format { get; set; }

		[XmlElement(ElementName = "FileExtensionAndVersion")]
		public string FileExtensionAndVersion { get; set; }

		[XmlElement(ElementName = "Content")]
		public Content Content { get; set; }

		[XmlElement(ElementName = "Class")]
		public string Class { get; set; }

		[XmlElement(ElementName = "SubClass")]
		public string SubClass { get; set; }

		[XmlElement(ElementName = "ReceivedDateTime")]
		public ReceivedDateTime ReceivedDateTime { get; set; }

		[XmlElement(ElementName = "SourceAuthorPhysician")]
		public SourceAuthorPhysician SourceAuthorPhysician { get; set; }

		[XmlElement(ElementName = "SourceFacility")]
		public string SourceFacility { get; set; }

		[XmlElement(ElementName = "ReportReviewed")]
		public ReportReviewed ReportReviewed { get; set; }

		[XmlElement(ElementName = "Notes")]
		public string Notes { get; set; }
	}

	[XmlRoot(ElementName = "DateTimeReportReviewed")]
	public class DateTimeReportReviewed
	{

		[XmlElement(ElementName = "FullDate")]
		public DateTime FullDate { get; set; }
	}

	[XmlRoot(ElementName = "ReportReviewed")]
	public class ReportReviewed
	{

		[XmlElement(ElementName = "Name")]
		public Name Name { get; set; }

		[XmlElement(ElementName = "ReviewingOHIPPhysicianId")]
		public object ReviewingOHIPPhysicianId { get; set; }

		[XmlElement(ElementName = "DateTimeReportReviewed")]
		public DateTimeReportReviewed DateTimeReportReviewed { get; set; }
	}

	[XmlRoot(ElementName = "Weight")]
	public class MWeight
	{

		[XmlElement(ElementName = "Weight")]
		public double Weight { get; set; }

		[XmlElement(ElementName = "WeightUnit")]
		public string WeightUnit { get; set; }

		[XmlElement(ElementName = "Date")]
		public DateTime Date { get; set; }
	}

	[XmlRoot(ElementName = "Height")]
	public class MHeight
	{

		[XmlElement(ElementName = "Height")]
		public double Height { get; set; }

		[XmlElement(ElementName = "HeightUnit")]
		public string HeightUnit { get; set; }

		[XmlElement(ElementName = "Date")]
		public DateTime Date { get; set; }
	}

	[XmlRoot(ElementName = "BloodPressure")]
	public class BloodPressure
	{

		[XmlElement(ElementName = "SystolicBP")]
		public string SystolicBP { get; set; }

		[XmlElement(ElementName = "DiastolicBP")]
		public string DiastolicBP { get; set; }

		[XmlElement(ElementName = "BPUnit")]
		public string BPUnit { get; set; }

		[XmlElement(ElementName = "Date")]
		public DateTime Date { get; set; }
	}

	[XmlRoot(ElementName = "CareElements")]
	public class CareElements
	{

		[XmlElement(ElementName = "Weight")]
		public List<MWeight> Weight { get; set; }

		[XmlElement(ElementName = "Height")]
		public List<MHeight> Height { get; set; }

		[XmlElement(ElementName = "BloodPressure")]
		public List<BloodPressure> BloodPressure { get; set; }
	}

	[XmlRoot(ElementName = "DateActive")]
	public class DateActive
	{

		[XmlElement(ElementName = "FullDate")]
		public DateTime FullDate { get; set; }
	}

	[XmlRoot(ElementName = "AlertsAndSpecialNeeds")]
	public class AlertsAndSpecialNeeds
	{

		[XmlElement(ElementName = "CategorySummaryLine")]
		public string CategorySummaryLine { get; set; }

		[XmlElement(ElementName = "AlertDescription")]
		public string AlertDescription { get; set; }

		[XmlElement(ElementName = "DateActive")]
		public DateActive DateActive { get; set; }
	}

	[XmlRoot(ElementName = "PatientRecord")]
	public class PatientRecord
	{

		[XmlElement(ElementName = "Demographics")]
		public Demographics Demographics { get; set; }

		[XmlElement(ElementName = "FamilyHistory")]
		public FamilyHistory FamilyHistory { get; set; }

		[XmlElement(ElementName = "PastHealth")]
		public List<PastHealth> PastHealth { get; set; }

		[XmlElement(ElementName = "ProblemList")]
		public List<ProblemList> ProblemList { get; set; }

		[XmlElement(ElementName = "AllergiesAndAdverseReactions")]
		public AllergiesAndAdverseReactions AllergiesAndAdverseReactions { get; set; }

		[XmlElement(ElementName = "MedicationsAndTreatments")]
		public List<MedicationsAndTreatments> MedicationsAndTreatments { get; set; }

		[XmlElement(ElementName = "Immunizations")]
		public List<Immunizations> Immunizations { get; set; }

		[XmlElement(ElementName = "LaboratoryResults")]
		public List<LaboratoryResults> LaboratoryResults { get; set; }

		[XmlElement(ElementName = "Appointments")]
		public List<Appointments> Appointments { get; set; }

		[XmlElement(ElementName = "ClinicalNotes")]
		public List<ClinicalNotes> ClinicalNotes { get; set; }

		[XmlElement(ElementName = "Reports")]
		public List<ReportsReceived> ReportsReceived { get; set; }

		[XmlElement(ElementName = "CareElements")]
		public CareElements CareElements { get; set; }

		[XmlElement(ElementName = "AlertsAndSpecialNeeds")]
		public List<AlertsAndSpecialNeeds> AlertsAndSpecialNeeds { get; set; }
	}

	[XmlRoot(ElementName = "OmdCds")]
	public class OmdCds
	{
		[XmlElement(ElementName = "PatientRecord")]
		public PatientRecord PatientRecord { get; set; }
	}


}
