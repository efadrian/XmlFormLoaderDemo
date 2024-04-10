using XMLFormLoaderDemo.Model.Domain;
using XMLFormLoaderDemo.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace XMLFormLoaderDemo.Repository
{
    public class UserAddressRepository : IUserAddress
    {
        private readonly DbSQLContext _dbContext;

        public UserAddressRepository(DbSQLContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<UserAddress> CreateUserAddress(UserAddress address)
        {
            await _dbContext.Addresses.AddAsync(address);
            await _dbContext.SaveChangesAsync();
            return address;
        }

        public async Task<IEnumerable<UserAddress>> GetAllUserAddressesAsync()
        {
            return await _dbContext.Addresses.ToListAsync();
        }

        public async Task<UserAddress?> GetUserAddressAsync(int addressId)
        {
            return await _dbContext.Addresses.FirstOrDefaultAsync(c => c.AddressID==addressId);
        }

        public async Task<UserAddress?> UpdateUserAddress(UserAddress address)
        {
            var IsAddress = await _dbContext.Addresses.FirstOrDefaultAsync(x => x.AddressID == address.AddressID);
            if (IsAddress != null)
            {
                _dbContext.Entry(IsAddress).CurrentValues.SetValues(address);
                await _dbContext.SaveChangesAsync();
                return address;
            }
            return null;
        }

        //
        public async Task<UserAddress?> DeleteUserAddressAsync(int addressId)
        {
            var IsAddress = await _dbContext.Addresses.FirstOrDefaultAsync(x => x.AddressID == addressId);
            if (IsAddress is null)
            {
                return null;
            }
                _dbContext.Remove(IsAddress);
                await _dbContext.SaveChangesAsync();
                return IsAddress!;
        }

        //
        public async Task<List<UserAddress>> SelectSqlRawAsync()
        {
            return await _dbContext.Addresses.FromSqlRaw(@"
            SELECT TOP 100 [AddressID], [Salutation], [FirstName], [LastName]
            FROM [dbo].[Addresses]").ToListAsync();
        }
    }
}
