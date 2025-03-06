using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BookWorm_Dotnet.Models;
using BookWorm_Dotnet.Services;
using BookWorm_Dotnet.DTOs;

[Route("api/myshelf")]
[ApiController]
public class MyShelfController : ControllerBase
{
    private readonly IMyShelfService _myShelfService;
    private readonly IShelfDetailsService _myShelfDetailsService;

    public MyShelfController(IMyShelfService myShelfService, IShelfDetailsService myShelfDetailsService)
    {
        _myShelfService = myShelfService;
        _myShelfDetailsService = myShelfDetailsService;
    }

    // Get MyShelf by customer ID
    [HttpGet("customer/{email}")]
    public async Task<IActionResult> GetMyShelfByCustomerId(string email)
    {
        var myShelf = await _myShelfService.GetMyShelfByCustomerAsync(email);
        return myShelf != null ? Ok(myShelf) : NotFound();
    }

    // Check if a product exists in the shelf
    [HttpGet("{shelfId}/product/{productId}")]
    public async Task<IActionResult> CheckProductInShelf(int shelfId, int productId)
    {
        bool exists = await _myShelfDetailsService.IsProductInShelfAsync(shelfId, productId);
        return exists ? Ok() : NotFound();
    }

    //// Create a new MyShelf
    //[HttpPost]
    //public async Task<IActionResult> CreateMyShelf([FromBody] MyShelf myShelf)
    //{
    //    var createdShelf = await _myShelfService.CreateMyShelfAsync(myShelf);
    //    return CreatedAtAction(nameof(GetMyShelfByCustomerId), new { customerId = myShelf.CustomerId }, createdShelf);
    //}

    // Update MyShelf
    [HttpPut("{shelfId}")]
    public async Task<IActionResult> UpdateMyShelf(int shelfId, [FromBody] MyShelf myShelf)
    {
        var updatedShelf = await _myShelfService.UpdateMyShelfAsync(shelfId, myShelf);
        return updatedShelf != null ? Ok(updatedShelf) : NotFound();
    }

    // Delete MyShelf
    [HttpDelete("{shelfId}")]
    public async Task<IActionResult> DeleteMyShelf(int shelfId)
    {
        await _myShelfService.DeleteMyShelfAsync(shelfId);
        return NoContent();
    }

    // Add product to shelf
    [HttpPost("add")]
    public async Task<IActionResult> AddProductToShelf([FromBody] MyShelfRequestDTO myShelfRequest)
    {
        var myShelfDetails = await _myShelfDetailsService.AddProductToShelfAsync(
            myShelfRequest.ShelfId,
            myShelfRequest.ProductId,
            myShelfRequest.ExpiryDate,
            myShelfRequest.TranType
        );
        return Created("", myShelfDetails);
    }

    // Get all products in a shelf
    [HttpGet("{shelfId}/details")]
    public async Task<IActionResult> GetShelfDetails(int shelfId)
    {
        var shelfDetails = await _myShelfDetailsService.GetShelfDetailsAsync(shelfId);
        return shelfDetails != null && shelfDetails.Count > 0 ? Ok(shelfDetails) : NotFound();
    }

    // Remove a product from the shelf
    [HttpDelete("{shelfId}/details/{shelfDetailId}")]
    public async Task<IActionResult> RemoveProductFromShelf(int shelfId, int shelfDetailId)
    {
        await _myShelfDetailsService.DeleteMyShelfDetailsAsync(shelfDetailId);
        return NoContent();
    }
}
