using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using BookWorm_Dotnet.Models;
using BookWorm_Dotnet.Services;

[Route("api/invoice-details")]
[ApiController]
public class InvoiceDetailsController : ControllerBase
{
    private readonly IInvoiceDetailsService _invoiceDetailsService;

    public InvoiceDetailsController(IInvoiceDetailsService invoiceDetailsService)
    {
        _invoiceDetailsService = invoiceDetailsService;
    }

    // Get all invoice details
    [HttpGet]
    public async Task<ActionResult<IEnumerable<InvoiceDetail>>> GetAllInvoiceDetails()
    {
        var invoiceDetails = await _invoiceDetailsService.GetAllInvoiceDetailsAsync();
        return Ok(invoiceDetails);
    }

    // Get invoice detail by ID
    [HttpGet("{id}")]
    public async Task<ActionResult<InvoiceDetail>> GetInvoiceDetailById(int id)
    {
        var invoiceDetail = await _invoiceDetailsService.GetInvoiceDetailByIdAsync(id);
        if (invoiceDetail == null)
        {
            return NotFound();
        }
        return Ok(invoiceDetail);
    }

    // Create invoice detail
    [HttpPost]
    public async Task<ActionResult<InvoiceDetail>> CreateInvoiceDetail([FromBody] InvoiceDetail invoiceDetail)
    {
        if (invoiceDetail == null)
        {
            return BadRequest("Invalid data");
        }

        var createdInvoiceDetail = await _invoiceDetailsService.SaveInvoiceDetailAsync(invoiceDetail);
        return CreatedAtAction(nameof(GetInvoiceDetailById), new { id = createdInvoiceDetail.InvDtlId }, createdInvoiceDetail);
    }

    // Delete invoice detail by ID
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteInvoiceDetail(int id)
    {
        bool deleted = await _invoiceDetailsService.DeleteInvoiceDetailAsync(id);
        if (!deleted)
        {
            return NotFound();
        }
        return NoContent();
    }
}
