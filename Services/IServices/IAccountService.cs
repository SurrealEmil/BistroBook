using BistroBook.Model.DTOs.AccountDTOs;

namespace BistroBook.Services.IServices
{
    public interface IAccountService
    {
        Task RegisterAccountAsync(AccountRegisterDto account);

        Task<string> LoginAccountAsync(AccountLoginDto account);
    }
}
