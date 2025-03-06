using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BookWorm_Dotnet.Models;
using BookWorm_Dotnet.Repository;

namespace BookWorm_Dotnet.Service
{
    public class CartDetailsServiceImpl : ICartDetailsService
    {
        private readonly BookWormDbContext _context;

        public CartDetailsServiceImpl(BookWormDbContext context)
        {
            _context = context;
        }

        // Method to get all cart details
        public async Task<List<CartDetail>> GetAllCartDetailsAsync()
        {
            return await _context.CartDetails.ToListAsync();
        }

        // Method to get cart details by ID
        public async Task<CartDetail> GetCartDetailsByIdAsync(int id)
        {
            return await _context.CartDetails.FindAsync(id);
        }

        // Method to get cart details by cart ID
        public async Task<List<CartDetail>> GetCartDetailsByCartIdAsync(int cartId)
        {
            return await _context.CartDetails.Where(cd => cd.CartId == cartId).Include(c=>c.Product).ToListAsync();
        }

        public async Task<CartDetail> AddProductToCartAsync(int customerId, int productId, int rentNoOfDays, string transType)
        {
            // Fetch the active CartMaster by customerId
            var cartMaster = await _context.CartMasters.FirstOrDefaultAsync(cm => cm.CustomerId == customerId && cm.IsActive ==true);
            if (cartMaster == null)
            {
                throw new Exception("No active cart found for the customer");
            }

            var product = await _context.ProductMasters.FindAsync(productId);
            if (product == null)
            {
                throw new Exception("Product not found");
            }

            // Create a new CartDetail object
            var cartDetails = new CartDetail
            {
                CartId = cartMaster.CartId,
                ProductId = product.ProductId,
                IsRented = transType.Equals("rent", StringComparison.OrdinalIgnoreCase),
                RentNoOfDays = product.MinRentDays,
                //OfferCost = (double)(transType.Equals("rent", StringComparison.OrdinalIgnoreCase)
                //    ? product.RentPerDay * rentNoOfDays
                //    : product.ProductBasePrice)
                OfferCost = 0.0
            };

            _context.CartDetails.Add(cartDetails);
            await _context.SaveChangesAsync();
            return cartDetails;
        }

        // Method to save cart details
        public async Task<CartDetail> SaveCartDetailsAsync(CartDetail cartDetails)
        {
            _context.CartDetails.Update(cartDetails);
            await _context.SaveChangesAsync();
            return cartDetails;
        }

        // Method to delete cart details by ID
        public async Task DeleteCartDetailsAsync(int id)
        {
            var cartDetails = await _context.CartDetails.FindAsync(id);
            if (cartDetails != null)
            {
                _context.CartDetails.Remove(cartDetails);
                await _context.SaveChangesAsync();
            }
        }
        public async Task UpdateCartDetailsAsync(CartDetail cartDetails)
        {
            _context.CartDetails.Update(cartDetails);
            await _context.SaveChangesAsync();
        }
    }
}
