using BookWorm_Dotnet.Models;
using BookWorm_Dotnet.Repository;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace BookWorm_Dotnet.Services
{
    public class MyShelfServiceImpl : IMyShelfService
    {
        private readonly BookWormDbContext _context;


        public MyShelfServiceImpl(BookWormDbContext context)
        {
            _context = context;
        }

        public async Task<MyShelf> AddMyShelfAsync(MyShelf myShelf)
        {
            _context.MyShelves.Add(myShelf);
            await _context.SaveChangesAsync();
            return myShelf;
        }

        public async Task<MyShelf> GetMyShelfByIdAsync(long shelfId)
        {
            return await _context.MyShelves.FindAsync(shelfId);
        }

        public async Task<bool> UpdateMyShelfAsync(long shelfId, MyShelf myShelf)
        {
            var existingShelf = await _context.MyShelves.FindAsync(shelfId);
            if (existingShelf == null)
            {
                return false;
            }

            existingShelf.CustomerId = myShelf.CustomerId;
            existingShelf.NoOfBooks = myShelf.NoOfBooks;
            // Update other properties as needed

            _context.MyShelves.Update(existingShelf);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteMyShelfAsync(long shelfId)
        {
            var myShelf = await _context.MyShelves.FindAsync(shelfId);
            if (myShelf == null)
            {
                return false;
            }

            _context.MyShelves.Remove(myShelf);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> IsProductInShelfAsync(long shelfId, long productId)
        {
            return await _context.MyShelfDetails.AnyAsync(s => s.ShelfDtlId == shelfId && s.Product.ProductId == productId);
        }

        public async Task<MyShelf?> GetMyShelfByCustomerAsync(string email)
        {
            var customer = await _context.CustomerMasters.FirstOrDefaultAsync(s => s.Customeremail == email);
            return await _context.MyShelves.FirstOrDefaultAsync(s => s.CustomerId == customer.CustomerId);
        }

    }
}
