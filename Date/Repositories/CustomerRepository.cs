using BistroBook.Date.Repositories.IRepositories;
using BistroBook.Model;
using Microsoft.EntityFrameworkCore;

namespace BistroBook.Date.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly BistroBookContext _context;

        public CustomerRepository(BistroBookContext context)
        {
            _context = context;
        }

        public async Task AddCustomerAsync(Customer customer)
        {
            await _context.Customers.AddAsync(customer);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteCustomerAsync(int customerId)
        {
            var customer = await _context.Customers.FindAsync(customerId);
            if (customer != null)
            {
                _context.Customers.Remove(customer);
            }
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Customer>> GetAllCustomersAsync()
        {
            var customerList = await _context.Customers.ToListAsync();
            return customerList;
        }

        public async Task<Customer> GetCustomerByIdAsync(int customerId)
        {
            var customer = await _context.Customers.FindAsync(customerId);
            return customer;
        }

        public async Task UpdateCustomerAsync(Customer customer)
        {
            _context.Customers.Update(customer);
            await _context.SaveChangesAsync();
        }
    }
}
