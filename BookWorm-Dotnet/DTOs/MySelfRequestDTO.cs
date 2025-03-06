using System;

namespace BookWorm_Dotnet.DTOs
{
    public class MyShelfRequestDTO
    {
        public int ShelfId { get; set; }
        public int ProductId { get; set; }
        public DateTime? ExpiryDate { get; set; } // Nullable DateTime to handle optional expiry dates
        public string TranType { get; set; }
    }
}