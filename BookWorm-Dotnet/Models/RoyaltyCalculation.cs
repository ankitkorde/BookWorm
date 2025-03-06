using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;

namespace BookWorm_Dotnet.Models;

[Table("royalty_calculation")]
[Index("InvoiceId", Name = "FK6ef225pnw8r22kw85xfua6hni")]
[Index("ProductId", Name = "FKas49u6dxu8mu28ylsq0cucx1b")]
[Index("BeneficiaryId", Name = "FKk6t36n4hai8yk4uo16c2u4xl5")]
public partial class RoyaltyCalculation
{
    [Key]
    [Column("roy_cal_id")]
    public int RoyCalId { get; set; }

    [Column("royalty_date")]
    public DateOnly RoyaltyDate { get; set; }

    [Column("royalty_on_sales_price")]
    public double RoyaltyOnSalesPrice { get; set; }

    [Column("sales_price")]
    public double SalesPrice { get; set; }

    [Column("transaction_type")]
    [StringLength(255)]
    public string TransactionType { get; set; } = null!;

    [Column("beneficiary_id")]
    public int BeneficiaryId { get; set; }

    [Column("invoice_id")]
    public int InvoiceId { get; set; }

    [Column("product_id")]
    public int ProductId { get; set; }

    [JsonIgnore]
    [ForeignKey("BeneficiaryId")]
    [InverseProperty("RoyaltyCalculations")]
    public virtual BeneficiaryMaster Beneficiary { get; set; } = null!;

    [JsonIgnore]
    [ForeignKey("InvoiceId")]
    [InverseProperty("RoyaltyCalculations")]
    public virtual Invoice Invoice { get; set; } = null!;

    [JsonIgnore]
    [ForeignKey("ProductId")]
    [InverseProperty("RoyaltyCalculations")]
    public virtual ProductMaster Product { get; set; } = null!;
}
