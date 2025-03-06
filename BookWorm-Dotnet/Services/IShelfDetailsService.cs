using System.Collections.Generic;
using System.Threading.Tasks;
using BookWorm_Dotnet.Models;

public interface IShelfDetailsService
{
    Task<MyShelfDetail> AddProductToShelfAsync(int shelfId, int productId, DateTime? expiryDate, string tranType);
    Task<List<MyShelfDetail>> GetShelfDetailsAsync(int shelfId);
    Task<MyShelfDetail?> CreateMyShelfDetailsAsync(MyShelfDetail myShelfDetail);
    Task<MyShelfDetail?> UpdateMyShelfDetailsAsync(int shelfDetailId, MyShelfDetail myShelfDetail);
    Task<bool> DeleteMyShelfDetailsAsync(int shelfDetailId);
    Task<bool> IsProductInShelfAsync(int shelfId, int productId);
}
