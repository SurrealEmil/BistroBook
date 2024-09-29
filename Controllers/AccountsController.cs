using BistroBook.Date;
using BistroBook.Model;
using BistroBook.Model.DTOs.AccountDTOs;
using BistroBook.Services.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace BistroBook.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private readonly IAccountService _accountService;
        public AccountsController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpPost("Register")]
        public async Task<IActionResult> Register(AccountRegisterDto accountRegister)
        {
            try
            {
                await _accountService.RegisterAccountAsync(accountRegister);

            }
            catch (InvalidOperationException ex)
            {
                return Conflict(ex.Message);
            }

            return Ok("Account added successfully.");
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login(AccountLoginDto accountLogin)
        {
            try
            {
                var token = await _accountService.LoginAccountAsync(accountLogin);
                return Ok(new { token });

            }
            catch (KeyNotFoundException ex)
            {

                return NotFound(ex.Message);

            }
            catch (InvalidOperationException ex)
            {
                return Unauthorized(ex.Message);
            }
        }
    }
}
