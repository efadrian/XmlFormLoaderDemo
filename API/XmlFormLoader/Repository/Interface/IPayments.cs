using XMLFormLoaderDemo.Model;

namespace XMLFormLoaderDemo.Repository.Interface
{
    public interface IPayments
    {
        IEnumerable<PaymentOption> GetPayments(string country);
    }
}
