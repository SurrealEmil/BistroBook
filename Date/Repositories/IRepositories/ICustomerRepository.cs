using BistroBook.Model;

namespace BistroBook.Date.Repositories.IRepositories
{
    public interface ICustomerRepository
    {
        // Create a new customer
        Task AddCustomerAsync(Customer customer);

        // Read operations
        Task<Customer> GetCustomerByIdAsync(int customerId);
        Task<IEnumerable<Customer>> GetAllCustomersAsync();

        // Update an existing customer
        Task UpdateCustomerAsync(Customer customer);

        // Delete a customer
        Task DeleteCustomerAsync(Customer customer);
    }
}
