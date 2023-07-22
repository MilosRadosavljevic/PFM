using System.Text.Json.Serialization;

namespace PFM.Models
{
    public class PagedSortListItems<T>
    {
        [JsonPropertyName("items")]
        public List<T> Items { get; set; }

    }
}
