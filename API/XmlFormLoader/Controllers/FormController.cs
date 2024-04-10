using XMLFormLoaderDemo.Repository.Interface;
using Microsoft.AspNetCore.Mvc;
namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FormController : ControllerBase
    {
        private readonly IFormData _formData;
        private readonly IPayments _payments;
        private readonly ILogger<FormController> _logger;

        public FormController(ILogger<FormController> logger,
            IFormData formData,
            IPayments paymentOptions)
        {
            _logger = logger;
            _formData = formData;
            _payments = paymentOptions;
        }

        [HttpGet("GetForm/{country}")]
        public IActionResult GetForm(string country)
        {
            var formData = _formData.GetFormData(country);
            
            _logger.LogInformation("Successfully retrieved form data.");
            return Ok(formData);
        }

        [HttpGet("GetPayments/{country}")]
        public IActionResult GetPayments(string country)
        {
            var paymentOptions = _payments.GetPayments(country);
            return Ok(paymentOptions);
        }
    }
}
