using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BookWorm_Dotnet.DTOs;
using BookWorm_Dotnet.Models;

namespace BookWorm_Dotnet.Services
{
    public interface IProductService
    {
        Task<List<ProductMaster>> GetAllProductsAsync();
        Task<ProductMaster?> GetProductByIdAsync(int productId);
        Task<ProductMaster> AddProductAsync(ProductMaster product);
        Task<ProductMaster?> UpdateProductAsync(ProductMaster product);
        Task<bool> DeleteProductAsync(int productId);
        public Task<IEnumerable<ProductMaster>> AddProductsInBulk(List<ProductMaster> products);
        public Task<List<FilteredProductsDTO>> GetFilteredProducts(string? genreDesc, string? languageDesc, string? productType);
        public Task<List<ProductMaster>> GetProductsByIdsAsync(List<int> productIds);



    }
}
