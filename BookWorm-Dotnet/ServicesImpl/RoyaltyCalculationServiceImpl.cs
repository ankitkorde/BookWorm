using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using BookWorm_Dotnet.Models;
using BookWorm_Dotnet.Repository;
using BookWorm_Dotnet.Services;

namespace BookWorm_Dotnet.ServicesImpl
{
    public class RoyaltyCalculationServiceImpl : IRoyaltyCalculationService
    {
        private readonly BookWormDbContext _context;

        public RoyaltyCalculationServiceImpl(BookWormDbContext context)
        {
            _context = context;
        }

        public async Task<List<RoyaltyCalculation>> GetAllRoyaltyCalculationsAsync()
        {
            return await _context.RoyaltyCalculations.ToListAsync();
        }

        public async Task<RoyaltyCalculation?> GetRoyaltyCalculationByIdAsync(int id)
        {
            return await _context.RoyaltyCalculations.FindAsync(id);
        }

        public async Task<RoyaltyCalculation> SaveRoyaltyCalculationAsync(RoyaltyCalculation royaltyCalculation)
        {
            _context.RoyaltyCalculations.Add(royaltyCalculation);
            await _context.SaveChangesAsync();
            return royaltyCalculation;
        }

        public async Task<bool> DeleteRoyaltyCalculationAsync(int id)
        {
            var royaltyCalculation = await _context.RoyaltyCalculations.FindAsync(id);
            if (royaltyCalculation != null)
            {
                _context.RoyaltyCalculations.Remove(royaltyCalculation);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task CalculateRoyaltyAsync(int invoiceId, long customerId, int cartId)
        {
            var cartMaster = await _context.CartMasters.FindAsync(cartId);
            var invoice = await _context.Invoices.FindAsync(invoiceId);

            if (cartMaster == null || invoice == null)
            {
                System.Diagnostics.Debug.WriteLine("-------------------------------------------Cart Not Found");
                throw new Exception("CartMaster or Invoice not found.");
            }

            var cartDetailsList = await _context.CartDetails
                .Where(cd => cd.CartId == cartId)
                .ToListAsync();
            System.Diagnostics.Debug.WriteLine("-------------------------------------------Cart Found"+cartDetailsList);


            foreach (var cartDetails in cartDetailsList)
            {
                var productMaster = cartDetails.ProductId;
                var productBeneficiaries = await _context.ProductBeneficiaries
                    .Where(pb => pb.ProductId == productMaster)
                    .ToListAsync();

                foreach (var productBeneficiary in productBeneficiaries)
                {
                    var beneficiaryMaster = productBeneficiary.BeneficiaryId;
                    if (beneficiaryMaster == null) continue;

                    System.Diagnostics.Debug.WriteLine("------------------------------------------"+beneficiaryMaster);
                    System.Diagnostics.Debug.WriteLine("-------------------------------------------Cart Not Found"+productBeneficiary);


                    double royaltyPercentage = (double)productBeneficiary.Percentage;

                    var royaltyCalculation = new RoyaltyCalculation
                    {
                        Invoice = invoice,
                        BeneficiaryId = (int)beneficiaryMaster,
                        RoyaltyDate = DateOnly.FromDateTime(DateTime.UtcNow),
                        Product = await _context.ProductMasters.FindAsync(productMaster),
                        TransactionType = cartDetails.IsRented ? "rent" : "purchase",
                        SalesPrice = cartDetails.OfferCost,
                        RoyaltyOnSalesPrice = cartDetails.OfferCost * (royaltyPercentage / 100) // Calculate royalty
                    };

                    _context.RoyaltyCalculations.Add(royaltyCalculation);
                }
            }
            await _context.SaveChangesAsync();
        }
    }
}
