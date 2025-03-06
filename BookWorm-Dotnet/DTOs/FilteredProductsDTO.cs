namespace BookWorm_Dotnet.DTOs
{
    public class FilteredProductsDTO
    {
        public int ProductId { get; set; }
        public string? ProductName { get; set; }
        public string? GenreDesc { get; set; }
        public string? LanguageDesc { get; set; }
        public string? ProductType { get; set; }
        public string? ImgSrc { get; set; }
        public string? ProductDescriptionShort { get; set; }
        public double? ProductOfferPrice { get; set; }
        public string? ProductAuthor { get; set; }


    }
}
