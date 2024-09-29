using BistroBook.Date;
using BistroBook.Date.Repositories.IRepositories;
using BistroBook.Model;
using BistroBook.Model.DTOs.AccountDTOs;
using BistroBook.Services.IServices;
using BistroBook.Utilitys;

namespace BistroBook.Services
{
    public class AccountService : IAccountService
    {
        private readonly IAccountRepository _accountRepository;
        private readonly IConfiguration _configuration;

        public AccountService(IAccountRepository accountRepository, IConfiguration configuration)
        {
            _accountRepository = accountRepository;
            _configuration = configuration;
        }

        public async Task<string> LoginAccountAsync(AccountLoginDto account)
        {
            var findAccount = await _accountRepository.GetAccountByEmailAsync(account.Email);
            if (findAccount == null)
            {
                throw new KeyNotFoundException($"Cant find user with email:{account.Email}");
            }

            //controll if email or pass is correct
            if (TokenHelper.CheckEmailAndPassword(findAccount, account.Password, findAccount.PasswordHash))
            {
                throw new InvalidOperationException("Invalid email or password!");
            };

            //generate jwt token and returns it
            var token = TokenHelper.GenerateJwtToken(findAccount, _configuration);
            return token;
        }

        public async Task RegisterAccountAsync(AccountRegisterDto account)
        {
            var existingAccount = await _accountRepository.GetAccountByEmailAsync(account.Email);
            if (existingAccount != null)
            {
                throw new InvalidOperationException("This email is already in use!");
            }

            //hashing the password
            string hashPassword = BCrypt.Net.BCrypt.HashPassword(account.Password);
            var registerAccount = new Account
            {
                FirstName = account.FirstName,
                LastName = account.LastName,
                Email = account.Email,
                PasswordHash = hashPassword
            };
            await _accountRepository.RegisterAccountAsync(registerAccount);
        }
    }
}
