using XMLFormLoaderDemo.Model;
using XMLFormLoaderDemo.Repository.Interface;
using System.Xml.Linq;

namespace XMLFormLoaderDemo.Repository
{
    public class PaymentsRepository : IPayments
    {
        private readonly IXmlHelper _xmlLoader;

        public PaymentsRepository(IXmlHelper xmlLoader)
        {
            _xmlLoader = xmlLoader;
        }

        public IEnumerable<PaymentOption> GetPayments(string country)
        {
            List<PaymentOption> paymentOptions = new List<PaymentOption>();
            
            XDocument xml = _xmlLoader.LoadXmlFile(country);
            foreach (XElement element in xml.Descendants("Payments").Elements())
            { 
                bool paymentSelected = false;
                var Id = paymentOptions.Count + 1;
                XAttribute selectedAttribute = element.Attribute("selected")!;
               
                if (selectedAttribute != null && bool.TryParse(selectedAttribute.Value, out bool isSelected))
                {
                    paymentSelected = isSelected;
                }

                paymentOptions.Add(new PaymentOption
                {
                    PaymentId = Id,
                    PaymentName = element.Name.LocalName,
                    PaymentCode = Id.ToString().PadLeft(3, '0'),
                    PaymentSelected = paymentSelected
                });
            }

            return paymentOptions;
        }
    }

}
