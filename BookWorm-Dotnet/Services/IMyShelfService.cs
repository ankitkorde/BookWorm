using BookWorm_Dotnet.Models;
using System.Threading.Tasks;

namespace BookWorm_Dotnet.Services
{
    public interface IMyShelfService
    {
        Task<MyShelf?> GetMyShelfByCustomerAsync(string email);
        Task<MyShelf> AddMyShelfAsync(MyShelf myShelf);
        Task<MyShelf> GetMyShelfByIdAsync(long shelfId);
        Task<bool> UpdateMyShelfAsync(long shelfId, MyShelf myShelf);
        Task<bool> DeleteMyShelfAsync(long shelfId);
        Task<bool> IsProductInShelfAsync(long shelfId, long productId);
    }
}
