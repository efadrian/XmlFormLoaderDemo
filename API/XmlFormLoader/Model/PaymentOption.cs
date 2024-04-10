namespace XMLFormLoaderDemo.Model
{
    public class PaymentOption
    {
        public int PaymentId { get; set; }
        public string PaymentName { get; set; } = string.Empty;
        public string PaymentCode { get; set; } = string.Empty;
        public bool PaymentSelected { get; set; }
    }
}
