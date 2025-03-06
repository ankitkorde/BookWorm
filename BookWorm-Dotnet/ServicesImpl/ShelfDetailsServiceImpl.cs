using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BookWorm_Dotnet.Models;
using BookWorm_Dotnet.Repository;

public class ShelfDetailsServiceImpl : IShelfDetailsService
{
    private readonly BookWormDbContext _context;

    public ShelfDetailsServiceImpl(BookWormDbContext context)
    {
        _context = context;
    }

    public async Task<MyShelfDetail> AddProductToShelfAsync(int shelfId, int productId, DateTime? expiryDate, string tranType)
    {
        var shelf = await _context.MyShelves.FindAsync(shelfId);
        if (shelf == null) throw new Exception("Shelf not found");

        var product = await _context.ProductMasters.FindAsync(productId);
        if (product == null) throw new Exception("Product not found");

        var shelfDetail = new MyShelfDetail
        {
            ShelfId = shelfId,
            ProductId = productId,
            ExpiryDate = expiryDate,
            TranType = tranType
        };

        _context.MyShelfDetails.Add(shelfDetail);
        await _context.SaveChangesAsync();
        return shelfDetail;
    }

    public async Task<List<MyShelfDetail>> GetShelfDetailsAsync(int shelfId)
    {
        return await _context.MyShelfDetails
            .Where(sd => sd.ShelfId == shelfId)
            .ToListAsync();
    }

    public async Task<MyShelfDetail?> CreateMyShelfDetailsAsync(MyShelfDetail myShelfDetail)
    {
        _context.MyShelfDetails.Add(myShelfDetail);
        await _context.SaveChangesAsync();
        return myShelfDetail;
    }

    public async Task<MyShelfDetail?> UpdateMyShelfDetailsAsync(int shelfDetailId, MyShelfDetail myShelfDetail)
    {
        var existingDetail = await _context.MyShelfDetails.FindAsync(shelfDetailId);
        if (existingDetail == null) return null;

        _context.Entry(existingDetail).CurrentValues.SetValues(myShelfDetail);
        await _context.SaveChangesAsync();
        return existingDetail;
    }

    public async Task<bool> DeleteMyShelfDetailsAsync(int shelfDetailId)
    {
        var detail = await _context.MyShelfDetails.FindAsync(shelfDetailId);
        if (detail == null) return false;

        _context.MyShelfDetails.Remove(detail);
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> IsProductInShelfAsync(int shelfId, int productId)
    {
        return await _context.MyShelfDetails
            .AnyAsync(sd => sd.ShelfId == shelfId && sd.ProductId == productId);
    }
}
