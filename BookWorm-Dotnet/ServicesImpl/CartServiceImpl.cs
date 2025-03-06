using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BookWorm_Dotnet.Models;
using BookWorm_Dotnet.Repository;
using BookWorm_Dotnet.Services;

public class CartServiceImpl : ICartService
{
    private readonly BookWormDbContext _context;

    public CartServiceImpl(BookWormDbContext context)
    {
        _context = context;
    }

    // Get all carts
    public async Task<List<CartMaster>> GetAllCarts()
    {
        return await _context.CartMasters.ToListAsync();
    }

    // Get cart by ID
    public async Task<CartMaster?> GetCartById(int id)
    {
        return await _context.CartMasters.FindAsync(id);
    }

    // Create or update cart
    public async Task<CartMaster> SaveCart(CartMaster cartMaster)
    {
        await UpdateCartCost(cartMaster);
        _context.CartMasters.Update(cartMaster);
        await _context.SaveChangesAsync();
        return cartMaster;
    }

    // Delete cart by ID
    public async Task DeleteCart(int id)
    {
        var cartMaster = await _context.CartMasters.FindAsync(id);
        if (cartMaster != null)
        {
            _context.CartMasters.Remove(cartMaster);
            await _context.SaveChangesAsync();
        }
    }

    // Get cart by customer ID
    public async Task<CartMaster?> GetCartByCustomerId(long id)
    {
        return await _context.CartMasters.FirstOrDefaultAsync(cm => cm.CustomerId == id && cm.IsActive);
    }

    // Update the cost of the cart by summing all offer_costs of CartDetails
    public async Task UpdateCartCost(CartMaster cartMaster)
    {
        var cartDetailsList = await _context.CartDetails
            .Where(cd => cd.CartId == cartMaster.CartId)
            .ToListAsync();

        cartMaster.Cost = cartDetailsList.Sum(cd => cd.OfferCost);
        _context.CartMasters.Update(cartMaster);
        await _context.SaveChangesAsync();
    }

    // Checkout cart
    public async Task<CartMaster> CheckoutCart(string email)
    {
        using var transaction = await _context.Database.BeginTransactionAsync();
        try
        {
            var customer = await _context.CustomerMasters.FirstOrDefaultAsync(c => c.Customeremail == email);
            long customerId = customer.CustomerId;
            var cartMaster = await _context.CartMasters
                .FirstOrDefaultAsync(cm => cm.CustomerId == customerId && cm.IsActive);

            if (cartMaster == null)
            {
                Console.WriteLine($"[DEBUG] No active cart found for customer ID: {customerId}");
                throw new Exception("Active cart not found for customer");
            }
            await UpdateCartCost(cartMaster);

            System.Diagnostics.Debug.WriteLine("------------------------------------"+$"[DEBUG] Found active cart ID: {cartMaster.CartId}");

            cartMaster.IsActive = false;
            _context.Entry(cartMaster).Property(x => x.IsActive).IsModified = true;
            await _context.SaveChangesAsync();
            System.Diagnostics.Debug.WriteLine("------------------------------------" + $"[DEBUG] Cart ID {cartMaster.CartId} deactivated.");

            // Detach the old cart before adding a new one
            _context.Entry(cartMaster).State = EntityState.Detached;

            var newCartMaster = new CartMaster
            {
                CustomerId = customerId,
                IsActive = true,
                Cost = 0.0
            };

            _context.CartMasters.Add(newCartMaster);
            await _context.SaveChangesAsync();
            System.Diagnostics.Debug.WriteLine("------------------------------------" + $"[DEBUG] New cart created for customer {customerId} with ID {newCartMaster.CartId}");

            await transaction.CommitAsync();
            return await _context.CartMasters.FindAsync(newCartMaster.CartId);
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.WriteLine("------------------------------------" + $"[ERROR] Transaction failed: {ex.Message}");
            await transaction.RollbackAsync();
            throw;
        }
    }



    // Add cart
    public async Task AddCartAsync(CartMaster cartMaster)
    {
        _context.CartMasters.Add(cartMaster);
        await _context.SaveChangesAsync();
    }
}
