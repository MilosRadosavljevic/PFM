using CsvHelper.Configuration.Attributes;

namespace PFM.Database.Entities
{
    public class CategoryEntity
    {
        public string Code { get; set; }
        public string? ParentCode { get; set; }
        public string CatName { get; set; }
    }
}
