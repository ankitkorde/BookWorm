using BookWorm_Dotnet.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookWorm_Dotnet.Services
{
    public interface IProductTypeService
    {
        Task<List<ProductTypeMaster>> GetAllProductTypes();
        Task<ProductTypeMaster> GetProductTypeById(int id);
        Task<ProductTypeMaster> AddProductType(ProductTypeMaster type);
    }
}
