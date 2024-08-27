using BistroBook.Model;
using BistroBook.Model.DTOs.CustomerDTOs;

namespace BistroBook.Services.IServices
{
    public interface ICustomerService
    {
        Task<IEnumerable<CustomerSummaryDto>> GetAllCustomersAsync();
        Task<CustomerDetailDto> GetCustomerByIdAsync(int customerId);
        Task AddCustomerAsync(CustomerCreateDto customer);
        Task UpdateCustomerAsync(int customerId, CustomerUpdateDto customer);
        Task DeleteCustomerAsync(int customerId);
    }
}
