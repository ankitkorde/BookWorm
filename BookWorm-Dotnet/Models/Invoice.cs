using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;

namespace BookWorm_Dotnet.Models;

[Table("invoice")]
[Index("CartId", Name = "FK74rjp8604l111tb50mbg1ubbd")]
[Index("CustomerId", Name = "FKk9j7m0iwl2u5ccibh3piocfj")]
public partial class Invoice
{
    [Key]
    [Column("invoice_id")]
    public int InvoiceId { get; set; }

    [Column("amount")]
    public double? Amount { get; set; }

    [Column("date")]
    [MaxLength(6)]
    public DateTime? Date { get; set; }

    [Column("cart_id")]
    public int? CartId { get; set; }


    [Column("customer_id")]
    public long? CustomerId { get; set; }

    [JsonIgnore]
    [ForeignKey("CartId")]
    [InverseProperty("Invoices")]
    public virtual CartMaster? Cart { get; set; }

    [JsonIgnore]
    [ForeignKey("CustomerId")]
    [InverseProperty("Invoices")]
    public virtual CustomerMaster? Customer { get; set; }

    [JsonIgnore]
    [InverseProperty("Invoice")]
    public virtual ICollection<InvoiceDetail> InvoiceDetails { get; set; }

    [JsonIgnore]
    [InverseProperty("Invoice")]
    public virtual ICollection<RoyaltyCalculation> RoyaltyCalculations { get; set; }
}
