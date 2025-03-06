using BookWorm_Dotnet.Models;

namespace BookWorm_Dotnet.Services
{
    public interface ICustomerService
    {
        Task<List<CustomerMaster>> GetAllCustomersAsyn();
        Task<CustomerMaster?> GetCustomerByIdAsyn(long id);
        Task<CustomerMaster?> UpdateCustomerAsync(CustomerMaster customer);
        Task<bool> DeleteCustomerAsync(long id);
        Task<CustomerMaster> AddCustomerAsync(CustomerMaster customer);
        Task<CustomerMaster?> GetCustomerByEmailAsync(string email);
        Task<CustomerMaster?> GetCustomerByEmailAndPasswordAsync(string email,string password);

    }
}
