using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BookWorm_Dotnet.Models;
using BookWorm_Dotnet.Repository;

namespace BookWorm_Dotnet.Services
{
    public class InvoiceServiceImpl : IInvoiceService
    {
        private readonly BookWormDbContext _dbContext;
        private readonly IRoyaltyCalculationService _royaltyCalculationService;

        public InvoiceServiceImpl(BookWormDbContext dbContext, IRoyaltyCalculationService royaltyCalculationService)
        {
            _dbContext = dbContext;
            _royaltyCalculationService = royaltyCalculationService;
        }

        public async Task<List<Invoice>> GetAllInvoicesAsync()
        {
            return await _dbContext.Invoices.ToListAsync();
        }

        public async Task<Invoice?> GetInvoiceByIdAsync(int id)
        {
            return await _dbContext.Invoices.FindAsync(id);
        }

        public async Task<Invoice> SaveInvoiceAsync(Invoice invoice)
        {
            _dbContext.Invoices.Add(invoice);
            await _dbContext.SaveChangesAsync();
            return invoice;
        }

        public async Task<bool> DeleteInvoiceAsync(int id)
        {
            var invoice = await _dbContext.Invoices.FindAsync(id);
            if (invoice != null)
            {
                _dbContext.Invoices.Remove(invoice);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<Invoice> CreateInvoiceAndCalculateRoyaltyAsync(string email, int cartId)
        {
            
            var cartMaster = await _dbContext.CartMasters
                .Include(c => c.Customer)
                .FirstOrDefaultAsync(c => c.CartId == cartId);

            if (cartMaster == null)
            {
                throw new Exception("Invalid cartId");
            }

            var invoice = new Invoice
            {
                CustomerId = cartMaster.CustomerId, // Assuming `Customer` is a navigation property
                CartId = cartMaster.CartId,
                Amount = cartMaster.Cost,
                Date = DateTime.UtcNow
            };

            _dbContext.Invoices.Add(invoice);
            await _dbContext.SaveChangesAsync();

            return invoice;
        }
    }
}
