using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using BookWorm_Dotnet.Models;
using BookWorm_Dotnet.Repository;
using BookWorm_Dotnet.Services;

namespace BookWorm_Dotnet.ServicesImpl
{
    public class InvoiceDetailsServiceImpl : IInvoiceDetailsService
    {
        private readonly BookWormDbContext _context;
        private readonly IRoyaltyCalculationService _royaltyCalculationService;

        public InvoiceDetailsServiceImpl(
            BookWormDbContext context,
            IRoyaltyCalculationService royaltyCalculationService)
        {
            _context = context;
            _royaltyCalculationService = royaltyCalculationService;
        }

        public async Task<List<InvoiceDetail>> GetAllInvoiceDetailsAsync()
        {
            return await _context.InvoiceDetails.ToListAsync();
        }

        public async Task<InvoiceDetail?> GetInvoiceDetailByIdAsync(int id)
        {
            return await _context.InvoiceDetails.FindAsync(id);
        }

        public async Task<InvoiceDetail> SaveInvoiceDetailAsync(InvoiceDetail invoiceDetail)
        {
            _context.InvoiceDetails.Add(invoiceDetail);
            await _context.SaveChangesAsync();
            return invoiceDetail;
        }

        public async Task<bool> DeleteInvoiceDetailAsync(int id)
        {
            var invoiceDetail = await _context.InvoiceDetails.FindAsync(id);
            if (invoiceDetail != null)
            {
                _context.InvoiceDetails.Remove(invoiceDetail);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task CreateInvoiceDetailsAsync(int invoiceId)
        {
            var invoice = await _context.Invoices
                .Include(i => i.Cart)
                .FirstOrDefaultAsync(i => i.InvoiceId == invoiceId);

            if (invoice == null)
            {
                throw new Exception("Invoice not found");
            }

            var cartDetailsList = await _context.CartDetails
                .Where(cd => cd.CartId == invoice.CartId)
                .ToListAsync();

            foreach (var cartDetails in cartDetailsList)
            {
                var invoiceDetails = new InvoiceDetail
                {
                    InvoiceId = invoice.InvoiceId,
                    ProductId = cartDetails.ProductId,
                    Quantity = 1, // Assuming quantity is always 1
                    TranType = cartDetails.IsRented ? "rent" : "purchase",
                    RentNoOfDays = (int)cartDetails.RentNoOfDays,
                    SellPrice = cartDetails.OfferCost
                };

                _context.InvoiceDetails.Add(invoiceDetails);
            }

            await _context.SaveChangesAsync();

            await _royaltyCalculationService.CalculateRoyaltyAsync(invoiceId, (long)invoice.CustomerId, (int)invoice.CartId);
        }
    }
}
