using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using BookWorm_Dotnet.Models;
using BookWorm_Dotnet.Services;

[Route("api/royalty-calculations")]
[ApiController]
public class RoyaltyCalculationController : ControllerBase
{
    private readonly IRoyaltyCalculationService _royaltyCalculationService;

    public RoyaltyCalculationController(IRoyaltyCalculationService royaltyCalculationService)
    {
        _royaltyCalculationService = royaltyCalculationService;
    }

    // Get all royalty calculations
    [HttpGet]
    public async Task<ActionResult<IEnumerable<RoyaltyCalculation>>> GetAllRoyaltyCalculations()
    {
        var royaltyCalculations = await _royaltyCalculationService.GetAllRoyaltyCalculationsAsync();
        return Ok(royaltyCalculations);
    }

    // Get royalty calculation by ID
    [HttpGet("{id}")]
    public async Task<ActionResult<RoyaltyCalculation>> GetRoyaltyCalculationById(int id)
    {
        var royaltyCalculation = await _royaltyCalculationService.GetRoyaltyCalculationByIdAsync(id);
        if (royaltyCalculation == null)
        {
            return NotFound();
        }
        return Ok(royaltyCalculation);
    }

    // Create or update royalty calculation
    [HttpPost]
    public async Task<ActionResult<RoyaltyCalculation>> SaveRoyaltyCalculation([FromBody] RoyaltyCalculation royaltyCalculation)
    {
        if (royaltyCalculation == null)
        {
            return BadRequest("Invalid data");
        }

        var savedRoyaltyCalculation = await _royaltyCalculationService.SaveRoyaltyCalculationAsync(royaltyCalculation);
        return CreatedAtAction(nameof(GetRoyaltyCalculationById), new { id = savedRoyaltyCalculation.RoyCalId }, savedRoyaltyCalculation);
    }

    // Delete royalty calculation by ID
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteRoyaltyCalculation(int id)
    {
        bool deleted = await _royaltyCalculationService.DeleteRoyaltyCalculationAsync(id);
        if (!deleted)
        {
            return NotFound();
        }
        return NoContent();
    }
}
