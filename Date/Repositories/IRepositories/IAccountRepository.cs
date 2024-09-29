using BistroBook.Model;

namespace BistroBook.Date.Repositories.IRepositories
{
    public interface IAccountRepository
    {
        Task RegisterAccountAsync(Account user);
        Task<Account> GetAccountByEmailAsync(string email);
    }
}
