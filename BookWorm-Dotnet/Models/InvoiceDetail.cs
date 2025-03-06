using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;

namespace BookWorm_Dotnet.Models;

[Table("invoice_details")]
[Index("ProductId", Name = "FK1anfj9yh7l91txbjf905la63l")]
[Index("InvoiceId", Name = "FKpc7xa72mljy7weoct7uubgjy7")]
public partial class InvoiceDetail
{
    [Key]
    [Column("inv_dtl_id")]
    public int InvDtlId { get; set; }

    [Column("quantity")]
    public int? Quantity { get; set; }

    [Column("rent_no_of_days")]
    public int RentNoOfDays { get; set; }

    [Column("royalty_amount")]
    public double? RoyaltyAmount { get; set; }

    [Column("sell_price")]
    public double? SellPrice { get; set; }

    [Column("tran_type")]
    [StringLength(255)]
    public string? TranType { get; set; }

    [Column("invoice_id")]
    public int? InvoiceId { get; set; }

    [Column("product_id")]
    public int? ProductId { get; set; }

    [JsonIgnore]
    [ForeignKey("InvoiceId")]
    [InverseProperty("InvoiceDetails")]
    public virtual Invoice? Invoice { get; set; }

    [JsonIgnore]
    [ForeignKey("ProductId")]
    [InverseProperty("InvoiceDetails")]
    public virtual ProductMaster? Product { get; set; }
}
