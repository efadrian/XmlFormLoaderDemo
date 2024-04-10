using XMLFormLoaderDemo.Model;

namespace XMLFormLoaderDemo.Repository.Interface
{

    public interface IFormData
    {
        IEnumerable<AddressForm> GetFormData(string country);
    }
}
