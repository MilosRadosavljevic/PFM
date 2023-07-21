using System.ComponentModel;
using System.Text.Json.Serialization;

namespace PFM.Models
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum Direction
    {
        [Description("Debit")]
        d,
        [Description("Credit")]
        c,
    }
}
