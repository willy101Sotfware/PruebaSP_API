
using Microsoft.AspNetCore.Mvc;
using PruebaSP_API.Services;



namespace PruebaSP_API.Controllers;



[Route("api/[controller]")]
[ApiController]
public class TransactionController : ControllerBase
{
    private readonly TransactionService _transactionService;

    public TransactionController(TransactionService transactionService)
    {
        _transactionService = transactionService;
    }

    [HttpGet]
    public async Task<IActionResult> GetTransactions(int payPadId, DateTime startDate, DateTime endDate)
    {
        try
        {
            var transactions = await _transactionService.GetTransactionsAsync(payPadId, startDate, endDate);
            return Ok(transactions);
        }
        catch (Exception ex)
        {
            // Manejo de errores
            return StatusCode(500, $"Error al obtener las transacciones: {ex.Message}");
        }
    }
}
