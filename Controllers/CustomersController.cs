using BistroBook.Model;
using BistroBook.Model.DTOs.CustomerDTOs;
using BistroBook.Services.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BistroBook.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly ICustomerService _customerService;

        public CustomersController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpGet]
        [Route("GetAllCustomers")]
        public async Task<ActionResult<IEnumerable<Customer>>> GetAllCustomers()
        {
            var customerList = await _customerService.GetAllCustomersAsync();
            return Ok(customerList);
        }

        [HttpGet]
        [Route("GetCustomerById/{customerId}")]
        public async Task<ActionResult<Customer>> GetCustomerById(int customerId)
        {
            var customer = await _customerService.GetCustomerByIdAsync(customerId);
            return Ok(customer);
        }

        [HttpPost]
        [Route("AddCustomer")]
        public async Task<ActionResult> AddCustomer([FromBody] CustomerCreateDto customer)
        {
            await _customerService.AddCustomerAsync(customer);
            return Ok();
        }

        [HttpPut]
        [Route("UpdateCustomer/{customerId}")]
        public async Task<ActionResult> UpdateCustomer(int customerId, [FromBody] CustomerUpdateDto customer)
        {
            await _customerService.UpdateCustomerAsync(customerId, customer);
            return Ok();
        }

        [HttpDelete]
        [Route("DeleteCustomer/{customerId}")]
        public async Task<ActionResult<Customer>> DeleteCustomer([FromBody] int customerId)
        {
            await _customerService.DeleteCustomerAsync(customerId);
            return Ok();
        }
    }
}
