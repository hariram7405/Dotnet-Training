using BankManagement.Core.DTOs;
using BankManagement.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BankManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionController : ControllerBase
    {
        private readonly ITransactionService _transactionService;

        public TransactionController(ITransactionService transactionService)
        {
            _transactionService = transactionService;
        }

        [HttpPost("transfer")]
        public async Task<ActionResult<TransactionResponseDTO>> TransferMoney([FromBody] TransactionRequestDTO request)
        {
            try
            {
                var transaction = await _transactionService.TransferMoneyAsync(request);
                return Ok(transaction);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("history/{accountId}")]
        public async Task<ActionResult<IEnumerable<TransactionResponseDTO>>> GetTransactionHistory(
            string accountId, 
            [FromQuery] int page = 1, 
            [FromQuery] int pageSize = 10)
        {
            try
            {
                var transactions = await _transactionService.GetTransactionHistoryAsync(accountId, page, pageSize);
                return Ok(transactions);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TransactionResponseDTO>> GetTransactionById(string id)
        {
            try
            {
                var transaction = await _transactionService.GetTransactionByIdAsync(id);
                if (transaction == null)
                    return NotFound();
                return Ok(transaction);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TransactionResponseDTO>>> GetAllTransactions()
        {
            try
            {
                var transactions = await _transactionService.GetAllTransactionsAsync();
                return Ok(transactions);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
