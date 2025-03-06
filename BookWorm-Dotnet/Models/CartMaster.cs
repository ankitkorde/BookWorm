using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;

namespace BookWorm_Dotnet.Models;

[Table("cart_master")]
[Index("CustomerId", Name = "FK44sbajofqx6cngygmmwui5igc")]
public partial class CartMaster
{
    [Key]
    [Column("cart_id")]
    public int CartId { get; set; }

    [Column("cost")]
    public double? Cost { get; set; }

    [Column("is_active")]
    public bool IsActive { get; set; }

    [Column("customer_id")]
    public long? CustomerId { get; set; }

    [JsonIgnore]
    [InverseProperty("Cart")]
    public virtual ICollection<CartDetail> CartDetails { get; set; }

    [JsonIgnore]
    [ForeignKey("CustomerId")]
    [InverseProperty("CartMasters")]
    public virtual CustomerMaster? Customer { get; set; }

    [JsonIgnore]
    [InverseProperty("Cart")]
    public virtual ICollection<Invoice> Invoices { get; set; }
}
