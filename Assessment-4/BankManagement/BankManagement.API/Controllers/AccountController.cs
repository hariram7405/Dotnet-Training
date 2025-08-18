using BankManagement.Core.DTOs;
using BankManagement.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BankManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _accountService;

        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<AccountResponseDTO>>> GetAllAccounts()
        {
            try
            {
                var accounts = await _accountService.GetAllAccountsAsync();
                return Ok(accounts);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<AccountResponseDTO>> GetAccountById(string id)
        {
            try
            {
                var account = await _accountService.GetAccountByIdAsync(id);
                if (account == null)
                    return NotFound();
                return Ok(account);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("customer/{customerId}")]
        public async Task<ActionResult<IEnumerable<AccountResponseDTO>>> GetAccountsByCustomerId(string customerId)
        {
            try
            {
                var accounts = await _accountService.GetAccountsByCustomerIdAsync(customerId);
                return Ok(accounts);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult<AccountResponseDTO>> CreateAccount([FromBody] AccountRequestDTO request)
        {
            try
            {
                var account = await _accountService.CreateAccountAsync(request);
                return CreatedAtAction(nameof(GetAccountById), new { id = account.Id }, account);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<AccountResponseDTO>> UpdateAccount(string id, [FromBody] AccountRequestDTO request)
        {
            try
            {
                var account = await _accountService.UpdateAccountAsync(id, request);
                return Ok(account);
            }
            catch (ArgumentException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteAccount(string id)
        {
            try
            {
                var result = await _accountService.DeleteAccountAsync(id);
                if (!result)
                    return NotFound();
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
            
        }
    }
}
