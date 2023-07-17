using CsvHelper.Configuration.Attributes;

namespace PFM.Models
{
    public class Category
    {
        [Name("code")]
        public string CatCode { get; set; }

        [Name("parent-code")]
        public string? ParentCode { get; set; }

        [Name("name")]
        public string CatName { get; set; }
    }
}
