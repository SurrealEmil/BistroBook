using BistroBook.Model;
using BistroBook.Model.DTOs.CustomerDTOs;

namespace BistroBook.Services.IServices
{
    public interface ICustomerService
    {
        // Create a new customer
        Task AddCustomerAsync(CustomerCreateDto customer);

        // Read operations
        Task<CustomerDetailDto> GetCustomerByIdAsync(int customerId);
        Task<IEnumerable<CustomerSummaryDto>> GetAllCustomersAsync();

        // Update an existing customer
        Task UpdateCustomerAsync(int customerId, CustomerUpdateDto customer);

        // Delete a customer
        Task DeleteCustomerAsync(int customerId);
    }
}
