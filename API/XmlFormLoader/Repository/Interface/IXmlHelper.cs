using System.Xml.Linq;

namespace XMLFormLoaderDemo.Repository.Interface
{
    public interface IXmlHelper
    {
        XDocument LoadXmlFile(string country);
    }
}
