using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;

namespace BookWorm_Dotnet.Models;

[Table("product_master")]
[Index("LanguageId", Name = "FK98ccg011o5dskuffl8qf7o7kk")]
[Index("GenreId", Name = "FKceskcho96iufjsecekgohckua")]
[Index("TypeId", Name = "FKkqx9yklv6gwn0rx53udabv5bd")]
public partial class ProductMaster
{
    [Key]
    [Column("product_id")]
    public int ProductId { get; set; }

    [Column("is_rentable")]
    public bool IsRentable { get; set; }

    [Column("min_rent_days")]
    public int? MinRentDays { get; set; }

    [Column("product_author")]
    [StringLength(255)]
    public string? ProductAuthor { get; set; }

    [Column("product_base_price")]
    public double? ProductBasePrice { get; set; }

    [Column("product_description_long")]
    [StringLength(255)]
    public string? ProductDescriptionLong { get; set; }

    [Column("product_description_short")]
    [StringLength(255)]
    public string? ProductDescriptionShort { get; set; }

    [Column("product_english_name")]
    [StringLength(255)]
    public string? ProductEnglishName { get; set; }

    [Column("product_isbn")]
    [StringLength(255)]
    public string? ProductIsbn { get; set; }

    [Column("product_name")]
    [StringLength(255)]
    public string? ProductName { get; set; }

    [Column("product_off_price_expiry_date")]
    public DateOnly? ProductOffPriceExpiryDate { get; set; }

    [Column("product_offer_price")]
    public double? ProductOfferPrice { get; set; }

    [Column("product_sp_cost")]
    public double? ProductSpCost { get; set; }

    [Column("rent_per_day")]
    public double? RentPerDay { get; set; }

    [Column("genre_id")]
    public int? GenreId { get; set; }

    [Column("language_id")]
    public int? LanguageId { get; set; }

    [Column("type_id")]
    public int? TypeId { get; set; }

    [Column("product_description")]
    [StringLength(255)]
    public string? ProductDescription { get; set; }

    [Column("img_src")]
    [StringLength(255)]
    public string? ImgSrc { get; set; }

    [InverseProperty("Product")]
    public virtual ICollection<CartDetail>? CartDetails { get; set; }

    [ForeignKey("GenreId")]
    [InverseProperty("ProductMasters")]
    public virtual GenreMaster? Genre { get; set; }

    [InverseProperty("Product")]
    public virtual ICollection<InvoiceDetail>? InvoiceDetails { get; set; }

    [ForeignKey("LanguageId")]
    [InverseProperty("ProductMasters")]
    public virtual LanguageMaster? Language { get; set; }

    [InverseProperty("Product")]
    public virtual ICollection<MyShelfDetail>? MyShelfDetails { get; set; }

    [InverseProperty("Product")]
    public virtual ICollection<ProductArribute>? ProductArributes { get; set; }

    [InverseProperty("Product")]
    public virtual ICollection<ProductBeneficiary>? ProductBeneficiaries { get; set; }

    [InverseProperty("Product")]
    public virtual ICollection<RentDetail>? RentDetails { get; set; }

    [InverseProperty("Product")]
    public virtual ICollection<RoyaltyCalculation>? RoyaltyCalculations { get; set; }

    [ForeignKey("TypeId")]
    [InverseProperty("ProductMasters")]
    public virtual ProductTypeMaster? Type { get; set; }
}
