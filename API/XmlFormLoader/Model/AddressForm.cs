using XMLFormLoaderDemo.Model.Enum;
using System.Text.Json.Serialization;

namespace XMLFormLoaderDemo.Model
{
    public class AddressForm
    {
        public string? FieldName { get; set; }
        public int MaxLength { get; set; }
        public string? Placeholder { get; set; }
        public int PositionId { get; set; }
        public bool Required { get; set; }
        public bool Show { get; set; }

        [JsonConverter(typeof(JsonStringEnumConverter))]
        public FieldType Type { get; set; }
        public List<string>? Options { get; set; }
        public string? DefaultOption { get; set; }
        public string? Country { get; set; }
    }
}
