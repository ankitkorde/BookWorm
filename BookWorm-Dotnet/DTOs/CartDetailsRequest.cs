using BookWorm_Dotnet.Models;

namespace Project.BookWorm.DTOs
{
    public class CartDetailsRequest
    {
        public int CustomerId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public int rentNoOfDays { get; set; }
        public string TransType { get; set; }
        public double OfferCost { get; set; }
        //public ProductMaster? Product { get; set; }

    }
}
