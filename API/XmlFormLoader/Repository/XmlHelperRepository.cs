using XMLFormLoaderDemo.Repository.Interface;
using System.Xml.Linq;
namespace XMLFormLoaderDemo.Repository
{

    public class XmlHelperRepository : IXmlHelper
    {
        public XDocument LoadXmlFile(string country)
        {
            if (string.IsNullOrEmpty(country) || country.Equals("undefined"))
            {
                country = "UK"; // default country
            }
            // Load XML file
            return XDocument.Load($"XmlData/DataXml_{country.ToUpper()}.xml");

        }
    }
}
