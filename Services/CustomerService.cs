using BistroBook.Date.Repositories.IRepositories;
using BistroBook.Model;
using BistroBook.Model.DTOs.CustomerDTOs;
using BistroBook.Services.IServices;

namespace BistroBook.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomerService(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        // Add a new customer
        public async Task AddCustomerAsync(CustomerCreateDto customer)
        {
            var newCustomer = new Customer
            {
                FirstName = customer.FirstName,
                LastName = customer.LastName,
                Email = customer.Email,
                PhoneNumber = customer.PhoneNumber,
            };
            await _customerRepository.AddCustomerAsync(newCustomer);
        }

        // Delete a customer by its ID
        public async Task DeleteCustomerAsync(int customerId)
        {
            var customer = await _customerRepository.GetCustomerByIdAsync(customerId);
            if (customer == null)
            {
                throw new InvalidOperationException("Customer was not found.");
            }
            await _customerRepository.DeleteCustomerAsync(customer);
        }

        // Get all customers and map to summary DTOs
        public async Task<IEnumerable<CustomerSummaryDto>> GetAllCustomersAsync()
        {
            var customerList = await _customerRepository.GetAllCustomersAsync();
            return customerList.Select(c => new CustomerSummaryDto
            {
                Id = c.Id,
                LastName = c.LastName,
                Email = c.Email,
            }).ToList();
        }

        // Get a customer by its ID and map to detail DTO
        public async Task<CustomerDetailDto> GetCustomerByIdAsync(int customerId)
        {
            var customer = await _customerRepository.GetCustomerByIdAsync(customerId);
            if (customer == null)
            {
                return null;
            }

            return new CustomerDetailDto
            {
                Id = customer.Id,
                FirstName = customer.FirstName,
                LastName = customer.LastName,
                Email = customer.Email,
                PhoneNumber = customer.PhoneNumber,
            };
        }

        // Update an existing customer by its ID
        public async Task UpdateCustomerAsync(int customerId, CustomerUpdateDto customer)
        {
            var updateCustomer = await _customerRepository.GetCustomerByIdAsync(customerId);
            if (updateCustomer == null)
            {
                throw new InvalidOperationException("Customer was not found.");
            }
            
            updateCustomer.FirstName = customer.FirstName;
            updateCustomer.LastName = customer.LastName;
            updateCustomer.Email = customer.Email;
            updateCustomer.PhoneNumber = customer.PhoneNumber;
            
            await _customerRepository.UpdateCustomerAsync(updateCustomer);
        }
    }
}
