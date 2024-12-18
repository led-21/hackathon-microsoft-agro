namespace hackaton_microsoft_agro.Models
{
    public class CropProtection
    {
        public int Id { get; set; }
        public string RegistrationNumber { get; set; }
        public string CommercialBrand { get; set; }
        public string Formulation { get; set; }
        public string ActiveIngredient { get; set; }
        public string RegistrationHolder { get; set; }
        public string Class { get; set; }
        public string ModeOfAction { get; set; }
        public string Crop { get; set; }
        public string PestScientificName { get; set; }
        public string PestCommonName { get; set; }
        public string CompanyCountryType { get; set; }
        public string ToxicologicalClass { get; set; }
        public string EnvironmentalClass { get; set; }
        public string Organic { get; set; }
        public string Status { get; set; }
    }
}
