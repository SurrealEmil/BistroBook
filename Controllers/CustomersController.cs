using BistroBook.Model;
using BistroBook.Model.DTOs.CustomerDTOs;
using BistroBook.Services.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

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

        // Get /api/Customers/GetAllCustomers
        [HttpGet]
        [Route("GetAllCustomers")]
        public async Task<ActionResult<IEnumerable<Customer>>> GetAllCustomers()
        {
            var customerList = await _customerService.GetAllCustomersAsync();

            if (customerList.IsNullOrEmpty())
            {
                return StatusCode(404, "No customers found.");
            }

            return Ok(customerList);
        }

        // Get /api/Customers/GetCustomerById/{id}
        [HttpGet]
        [Route("GetCustomerById/{id}")]
        public async Task<ActionResult<Customer>> GetCustomerById(int id)
        {
            var customer = await _customerService.GetCustomerByIdAsync(id);

            if (customer == null)
            {
                return StatusCode(404, "No matching customer found.");
            }

            return Ok(customer);
        }

        // Post /api/Customers/AddCustomer
        [HttpPost]
        [Route("AddCustomer")]
        public async Task<ActionResult> AddCustomer([FromBody] CustomerCreateDto customer)
        {
            try
            {
                await _customerService.AddCustomerAsync(customer);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
            return Ok("Customer added successfully.");
        }

        // Put /api/Customers/UpdateCustomer/{id}
        [HttpPut]
        [Route("UpdateCustomer/{id}")]
        public async Task<ActionResult> UpdateCustomer(int id, [FromBody] CustomerUpdateDto customer)
        {
            try
            {
                await _customerService.UpdateCustomerAsync(id, customer);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
            return Ok("Customer updated successfully.");
        }

        // DELETE /api/Customers/DeleteCustomer/{id}
        [HttpDelete]
        [Route("DeleteCustomer/{id}")]
        public async Task<ActionResult<Customer>> DeleteCustomer(int id)
        {
            try
            {
                await _customerService.DeleteCustomerAsync(id);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok("Customer deleted successfully.");
        }
    }
}
