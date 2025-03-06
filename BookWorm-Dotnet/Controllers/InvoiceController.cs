using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using BookWorm_Dotnet.Models;
using BookWorm_Dotnet.Services;
using BookWormAPI.Models;
using System.Net.Http;
using System.Text.Json;
using System.Text;

[Route("api/invoices")]
[ApiController]
[Produces("application/json")]
public class InvoiceController : ControllerBase
{
    private readonly IInvoiceService _invoiceService;
    private readonly IInvoiceDetailsService _invoiceDetailsService;
    private readonly ICartService _cartMasterService;
    private readonly HttpClient _httpClient;

    public InvoiceController(
        IInvoiceService invoiceService,
        IInvoiceDetailsService invoiceDetailsService,
        ICartService cartMasterService,
        HttpClient httpClient)
    {
        _invoiceService = invoiceService;
        _invoiceDetailsService = invoiceDetailsService;
        _cartMasterService = cartMasterService;
        _httpClient = httpClient;
    }

    // Get all invoices
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Invoice>>> GetAllInvoices()
    {
        var invoices = await _invoiceService.GetAllInvoicesAsync();
        return Ok(invoices);
    }

    // Get invoice by ID
    [HttpGet("{id}")]
    public async Task<ActionResult<Invoice>> GetInvoiceById(int id)
    {
        var invoice = await _invoiceService.GetInvoiceByIdAsync(id);
        if (invoice == null)
        {
            return NotFound();
        }
        return Ok(invoice);
    }

    // Create invoice
    [HttpPost]
    public async Task<ActionResult<Invoice>> CreateInvoice([FromBody] InvoiceRequestDTO invoiceRequest)
    {
        if (invoiceRequest == null)
        {
            return BadRequest("Invalid request");
        }

        try
        {
            var savedInvoice = await _invoiceService.CreateInvoiceAndCalculateRoyaltyAsync(invoiceRequest.Email, invoiceRequest.CartId);
            await _invoiceDetailsService.CreateInvoiceDetailsAsync(savedInvoice.InvoiceId);
            await SendEmailAsync(invoiceRequest.Email, "Invoice Created", "Your invoice has been created successfully.");
            return CreatedAtAction(nameof(GetInvoiceById), new { id = savedInvoice.InvoiceId }, savedInvoice);
        }
        catch (System.Exception ex)
        {
            return BadRequest(new { message = ex.Message });
        }
    }

    // Delete invoice by ID
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteInvoice(int id)
    {
        var deleted = await _invoiceService.DeleteInvoiceAsync(id);
        if (!deleted)
        {
            return NotFound();
        }
        return NoContent();
    }

    public async Task SendEmailAsync(string toEmail, string subject, string body)
    {
        var request = new
        {
            ToEmail = toEmail,
            Subject = subject,
            Body = body
        };

        var content = new StringContent(JsonSerializer.Serialize(request), Encoding.UTF8, "application/json");
        await _httpClient.PostAsync("http://localhost:5194/api/email/send", content);
    }
}
