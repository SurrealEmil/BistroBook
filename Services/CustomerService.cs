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

        public async Task DeleteCustomerAsync(int customerId)
        {
            await _customerRepository.DeleteCustomerAsync(customerId);
        }

        public async Task<IEnumerable<CustomerSummaryDto>> GetAllCustomersAsync()
        {
            var customerList = await _customerRepository.GetAllCustomersAsync();
            return customerList.Select(c => new CustomerSummaryDto
            {
                CustomerId = c.CustomerId,
                LastName = c.LastName,
                Email = c.Email,
            }).ToList();
        }

        public async Task<CustomerDetailDto> GetCustomerByIdAsync(int customerId)
        {
            var customer = await _customerRepository.GetCustomerByIdAsync(customerId);
            if (customer == null)
            {
                return null;
            }

            return new CustomerDetailDto
            {
                CustomerId = customer.CustomerId,
                FirstName = customer.FirstName,
                LastName = customer.LastName,
                Email = customer.Email,
                PhoneNumber = customer.PhoneNumber,
            };
        }

        public async Task UpdateCustomerAsync(int customerId, CustomerUpdateDto customer)
        {
            var updateCustomer = await _customerRepository.GetCustomerByIdAsync(customerId);
            {
                updateCustomer.FirstName = customer.FirstName;
                updateCustomer.LastName = customer.LastName;
                updateCustomer.Email = customer.Email;
                updateCustomer.PhoneNumber = customer.PhoneNumber;
            };
            await _customerRepository.UpdateCustomerAsync(updateCustomer);
        }
    }
}
