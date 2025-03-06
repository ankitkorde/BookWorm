using BookWorm_Dotnet.Models;
using BookWorm_Dotnet.Repository;
using BookWorm_Dotnet.Services;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookWorm_Dotnet.ServicesImpl
{
    public class ProductTypeServiceImpl : IProductTypeService
    {
        private readonly BookWormDbContext _dbContext;

        public ProductTypeServiceImpl(BookWormDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<ProductTypeMaster>> GetAllProductTypes()
        {
            return await _dbContext.ProductTypeMasters.ToListAsync();
        }

        public async Task<ProductTypeMaster> GetProductTypeById(int id)
        {
            return await _dbContext.ProductTypeMasters.FindAsync(id);
        }

        public async Task<ProductTypeMaster> AddProductType(ProductTypeMaster type)
        {
            var addedType = await _dbContext.ProductTypeMasters.AddAsync(type);
            await _dbContext.SaveChangesAsync();
            return addedType.Entity;
        }
    }
}
