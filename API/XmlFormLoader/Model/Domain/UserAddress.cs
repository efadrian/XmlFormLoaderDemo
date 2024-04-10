using System.ComponentModel.DataAnnotations;

namespace XMLFormLoaderDemo.Model.Domain
{
    public class UserAddress
    {
        [Key]
        public int AddressID { get; set; }
        public string Salutation { get; set; } = string.Empty;
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string AdrLine1 { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string CustomerType { get; set; } = string.Empty;
        public string Mobile { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public string? Country { get; set; } 
        public bool SubscribeToNewsletter { get; set; } = false;
    }
}
