using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BookWorm_Dotnet.Models;

namespace BookWorm_Dotnet.Services
{
    public interface IInvoiceService
    {
        Task<List<Invoice>> GetAllInvoicesAsync();
        Task<Invoice?> GetInvoiceByIdAsync(int id);
        Task<Invoice> SaveInvoiceAsync(Invoice invoice);
        Task<bool> DeleteInvoiceAsync(int id);
        Task<Invoice> CreateInvoiceAndCalculateRoyaltyAsync(string email, int cartId);
    }
}
