using System.Collections.Generic;
using System.Threading.Tasks;
using BookWorm_Dotnet.Models;

namespace BookWorm_Dotnet.Services
{
    public interface IInvoiceDetailsService
    {
        Task<List<InvoiceDetail>> GetAllInvoiceDetailsAsync();
        Task<InvoiceDetail?> GetInvoiceDetailByIdAsync(int id);
        Task<InvoiceDetail> SaveInvoiceDetailAsync(InvoiceDetail invoiceDetail);
        Task<bool> DeleteInvoiceDetailAsync(int id);
        Task CreateInvoiceDetailsAsync(int invoiceId);
    }
}
