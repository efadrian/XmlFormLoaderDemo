using XMLFormLoaderDemo.Model.Domain;
using XMLFormLoaderDemo.Repository.Interface;
using Microsoft.AspNetCore.Mvc;

namespace XMLFormLoaderDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserAddress _userAddress;

        public UserController(IUserAddress userAddress)
        {
            _userAddress = userAddress;
        }

        [HttpGet("GetAllUserAddresses")]
        public async Task<IActionResult> GetAllUserAddresses()
        {
            var userAddresses = await _userAddress.GetAllUserAddressesAsync();
            return Ok(userAddresses);
        }

        [HttpGet("GetUserAddress/{addressId}")]
        public async Task<IActionResult> GetUserAddress(int addressId)
        {
            var userAddress = await _userAddress.GetUserAddressAsync(addressId);
            return Ok(userAddress);
        }

        [HttpPost("CreateUserAddress")]
        public async Task<IActionResult> CreateUserAddress([FromBody] UserAddress address)
        {
            var userAddress = await _userAddress.CreateUserAddress(address);
            return Ok(userAddress);
        }

        [HttpPost("UpdateUserAddress")]
        public async Task<IActionResult> UpdateUserAddress([FromBody] UserAddress address)
        {
            var userAddress = await _userAddress.UpdateUserAddress(address);
            return Ok(userAddress);
        }

        [HttpDelete("DeleteUserAddress")]
        public async Task<IActionResult> DeleteUserAddress(int addressId)
        {
            var userAddress = await _userAddress.DeleteUserAddressAsync(addressId);
            return Ok(null);
        }
    }
}
