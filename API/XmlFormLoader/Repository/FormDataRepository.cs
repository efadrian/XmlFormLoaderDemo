using XMLFormLoaderDemo.Model;
using XMLFormLoaderDemo.Model.Enum;
using XMLFormLoaderDemo.Repository.Interface;
using System.Xml.Linq;

namespace XMLFormLoaderDemo.Repository
{
    public class FormDataRepository : IFormData
    {
        private readonly IXmlHelper _xmlLoader;

        public FormDataRepository(IXmlHelper xmlLoader)
        {
            _xmlLoader = xmlLoader;
        }

        public IEnumerable<AddressForm> GetFormData(string country)
        {
            var formData = new List<AddressForm>();

            XDocument doc = _xmlLoader.LoadXmlFile(country);
            // Parse XML create AddressForm
            foreach (XElement element in doc.Descendants("AddressForm").Elements())
            {

                AddressForm formField = new AddressForm
                {
                    PositionId = formData.Count + 1,
                    FieldName = element.Name.LocalName,
                    MaxLength = int.Parse(element.Element("MaxLength")!.Value),
                    Placeholder = element.Element("Placeholder")!.Value,
                    Required = bool.Parse(element.Element("Required")!.Value),
                    Show = bool.Parse(element.Element("Displayed")!.Value),
                    Type = ParseFieldType(element.Element("Type")!.Value),
                    Country = country
                };

                if (formField.Type == FieldType.select || formField.Type == FieldType.radio)
                {
                    var options = element.Element("Options")?.Elements("Option").Select(o => o.Value).ToList();
                    formField.Options = options ?? new List<string>();
                    formField.DefaultOption = element.Element("DefaultOption")?.Value;
                }

                if(formField.Type == FieldType.checkbox)
                {
                    formField.DefaultOption = element.Element("DefaultOption")?.Value;
                }

                formData.Add(formField);
            }

            return formData;
        }

        private FieldType ParseFieldType(string fieldType)
        {
             switch (fieldType)
            {
                case "Text":
                    return FieldType.text;
                case "Select":
                    return FieldType.select;
                case "Radio":
                    return FieldType.radio;
                case "Checkbox":
                    return FieldType.checkbox;
                default:
                    return FieldType.text; 
            }
        }
    }
}
