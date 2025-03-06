using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BookWorm_Dotnet.Models;
using BookWorm_Dotnet.Repository;
using BookWorm_Dotnet.Services;
using BookWorm_Dotnet.DTOs;

namespace BookWorm_Dotnet.ServicesImpl
{
    public class ProductServiceImpl:IProductService
    {
        private readonly BookWormDbContext _context;

        public ProductServiceImpl(BookWormDbContext context)
        {
            _context = context;
        }

        // Get all products
        public async Task<List<ProductMaster>> GetAllProductsAsync()
        {
            return await _context.ProductMasters.ToListAsync();
        }

        // Get product by ID
        public async Task<ProductMaster?> GetProductByIdAsync(int productId)
        {
            return await _context.ProductMasters.FindAsync(productId);
        }

        // Add a new product
        public async Task<ProductMaster> AddProductAsync(ProductMaster product)
        {
            _context.ProductMasters.Add(product);
            await _context.SaveChangesAsync();
            return product;
        }

        public async Task<List<ProductMaster>> GetProductsByIdsAsync(List<int> productIds)
        {
            return await _context.ProductMasters.Where(p => productIds.Contains(p.ProductId)).ToListAsync();
        }

        public async Task<IEnumerable<ProductMaster>> AddProductsInBulk(List<ProductMaster> products)
        {
            if (products == null || !products.Any())
                throw new ArgumentException("Product list cannot be null or empty.");

            try
            {
                await _context.ProductMasters.AddRangeAsync(products);
                await _context.SaveChangesAsync();
                return products;
            }
            catch (Exception ex)
            {
                // Log the exception (Assuming _logger is injected)
                throw;
            }
        }


        // Update a product
        public async Task<ProductMaster?> UpdateProductAsync(ProductMaster product)
        {
            var existingProduct = await _context.ProductMasters.FindAsync(product.ProductId);
            if (existingProduct == null)
            {
                return null; 
            }

            _context.Entry(existingProduct).CurrentValues.SetValues(product);
            await _context.SaveChangesAsync();

            return await _context.ProductMasters.FindAsync(product.ProductId);
        }


        // Delete a product
        public async Task<bool> DeleteProductAsync(int productId)
        {
            var product = await _context.ProductMasters.FindAsync(productId);
            if (product == null) return false;

            _context.ProductMasters.Remove(product);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<List<FilteredProductsDTO>> GetFilteredProducts(string? genreDesc, string? languageDesc, string? productType)
        {
            var query = _context.ProductMasters
                .Include(p => p.Genre)
                .Include(p => p.Language)
                .Include(p => p.Type)
                .AsQueryable();
            System.Diagnostics.Debug.WriteLine("----------------------------"+query.ToString);

            if (!string.IsNullOrEmpty(genreDesc))
                query = query.Where(p => p.Genre != null && p.Genre.GenreDesc == genreDesc);

            if (!string.IsNullOrEmpty(languageDesc))
                query = query.Where(p => p.Language != null && p.Language.LanguageDesc == languageDesc);

            if (!string.IsNullOrEmpty(productType))
                query = query.Where(p => p.Type != null && p.Type.TypeDesc == productType);

            var filteredProducts = await query
                .Select(p => new FilteredProductsDTO
                {
                    ProductId = p.ProductId,
                    ProductName = p.ProductName,
                    GenreDesc = p.Genre != null ? p.Genre.GenreDesc : null,
                    LanguageDesc = p.Language != null ? p.Language.LanguageDesc : null,
                    ProductType = p.Type != null ? p.Type.TypeDesc : null,
                    ImgSrc = p.ImgSrc,
                    ProductAuthor = p.ProductAuthor,
                    ProductDescriptionShort = p.ProductDescriptionShort,
                    ProductOfferPrice = p.ProductOfferPrice
                })
                .ToListAsync();

            return filteredProducts;
        }
    }
}
