using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;

namespace BookWorm_Dotnet.Models;

[Table("my_shelf_details")]
[Index("ShelfId", Name = "FK3vkqpj988tywu7bhqeobs2nr5")]
[Index("RentId", Name = "FKbtjwvxhfuon9laskq27fxc7g5")]
[Index("ProductId", Name = "FKnydbo1psmybo0qmv9rvgqo1o6")]
public partial class MyShelfDetail
{
    [Key]
    [Column("shelf_dtl_id")]
    public int ShelfDtlId { get; set; }

    [Column("expiry_date")]
    [MaxLength(6)]
    public DateTime? ExpiryDate { get; set; }

    [Column("tran_type")]
    [StringLength(255)]
    public string? TranType { get; set; }

    [Column("product_id")]
    public int ProductId { get; set; }

    [Column("rent_id")]
    public int? RentId { get; set; }

    [Column("shelf_id")]
    public int ShelfId { get; set; }

    [JsonIgnore]
    [ForeignKey("ProductId")]
    [InverseProperty("MyShelfDetails")]
    public virtual ProductMaster Product { get; set; } = null!;

    [JsonIgnore]
    [ForeignKey("RentId")]
    [InverseProperty("MyShelfDetails")]
    public virtual RentDetail? Rent { get; set; }

    [JsonIgnore]
    [ForeignKey("ShelfId")]
    [InverseProperty("MyShelfDetails")]
    public virtual MyShelf Shelf { get; set; } = null!;
}
