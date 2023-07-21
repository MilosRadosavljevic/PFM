namespace PFM.Models
{
    public class Category
    {
        public string CategoryCode { get; set; }

        public string Name { get; set; }

        public string? ParentCode { get; set; }
    }
}