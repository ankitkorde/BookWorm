using BookWorm_Dotnet.Models;

public interface ICartDetailsService
{
    Task<List<CartDetail>> GetAllCartDetailsAsync();
    Task<CartDetail> GetCartDetailsByIdAsync(int id);
    Task<List<CartDetail>> GetCartDetailsByCartIdAsync(int cartId);
    Task<CartDetail> AddProductToCartAsync(int customerId, int productId, int rentNoOfDays, string transType);
    Task<CartDetail> SaveCartDetailsAsync(CartDetail cartDetails);
    Task DeleteCartDetailsAsync(int id);
    Task UpdateCartDetailsAsync(CartDetail cartDetails);
}