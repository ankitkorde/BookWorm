using System.Collections.Generic;
using System.Threading.Tasks;
using BookWorm_Dotnet.Models;

namespace BookWorm_Dotnet.Services
{
    public interface IRoyaltyCalculationService
    {
        Task<List<RoyaltyCalculation>> GetAllRoyaltyCalculationsAsync();
        Task<RoyaltyCalculation?> GetRoyaltyCalculationByIdAsync(int id);
        Task<RoyaltyCalculation> SaveRoyaltyCalculationAsync(RoyaltyCalculation royaltyCalculation);
        Task<bool> DeleteRoyaltyCalculationAsync(int id);
        Task CalculateRoyaltyAsync(int invoiceId, long customerId, int cartId);
    }
}
