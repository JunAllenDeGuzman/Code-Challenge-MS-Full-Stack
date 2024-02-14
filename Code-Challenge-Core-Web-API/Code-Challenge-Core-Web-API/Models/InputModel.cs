namespace Code_Challenge_Core_Web_API.Models
{
    public class InputModel
    {
        public int LearnerId { get; set; }
        public string LearnerCode { get; set; }
        public string Forename { get; set; }
        public string LegalForename { get; set; }
        public string Surname { get; set; }
        public string LegalSurname { get; set; }
        public string gender { get; set; }
        public string Year { get; set; }
        public string DateOfBirth { get; set; }
        public string UPN { get; set; }
        public string FormerUPN { get; set; }
        public string ULN { get; set; }
        public bool EAL { get; set; }
        public string ServiceChild { get; set; }
        public string EnrolementStatus { get; set; }
        public List<AddressDetailModel> AddressDetails { get; set; }
        public List<LanguageDetailModel> LanguageDetails { get; set; }
        public List<SENProvisionDetailModel> SENProvisionDetails { get; set; }
    }
}
