using BistroBook.Date.Repositories.IRepositories;
using BistroBook.Model;
using Microsoft.EntityFrameworkCore;

namespace BistroBook.Date.Repositories
{
    public class AccountRepository : IAccountRepository
    {
        private readonly BistroBookContext _context;

        public AccountRepository(BistroBookContext context)
        {
            _context = context;
        }

        public async Task<Account> GetAccountByEmailAsync(string email)
        {
            var account = await _context.Accounts.SingleOrDefaultAsync(a => a.Email == email);
            return account;
        }

        public async Task RegisterAccountAsync(Account account)
        {
            _context.Accounts.Add(account);
            await _context.SaveChangesAsync();
        }
    }
}
