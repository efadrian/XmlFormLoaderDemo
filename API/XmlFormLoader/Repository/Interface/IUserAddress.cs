using XMLFormLoaderDemo.Model.Domain;

namespace XMLFormLoaderDemo.Repository.Interface
{
    public interface IUserAddress
    {
        Task<IEnumerable<UserAddress>> GetAllUserAddressesAsync();
        Task<UserAddress?> GetUserAddressAsync(int addressId);
        Task<UserAddress> CreateUserAddress(UserAddress address);
        Task<UserAddress?> UpdateUserAddress(UserAddress address);
        Task<UserAddress?> DeleteUserAddressAsync(int addressId);
    }
}
