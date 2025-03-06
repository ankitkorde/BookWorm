using BookWorm_Dotnet.Models;

namespace BookWorm_Dotnet.Services
{
    public interface ICartService
    {
        public Task<List<CartMaster>> GetAllCarts();
        public  Task<CartMaster?> GetCartById(int id);
        public Task<CartMaster?> GetCartByCustomerId(long id);
        public  Task<CartMaster> SaveCart(CartMaster cartMaster);
        public  Task DeleteCart(int id);
        public  Task UpdateCartCost(CartMaster cartMaster);
        public Task<CartMaster> CheckoutCart(string email);
        public Task AddCartAsync(CartMaster cartMaster);



    }
}
