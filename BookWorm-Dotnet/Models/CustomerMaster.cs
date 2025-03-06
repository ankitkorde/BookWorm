using BookWorm_Dotnet.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

[Table("customer_master")]
public partial class CustomerMaster
{
    [Key]
    [Column("customer_id")]
    public long CustomerId { get; set; }

    [Column("age")]
    public int? Age { get; set; }

    [Column("customeremail")]
    public string? Customeremail { get; set; }

    [Column("customername")]
    [StringLength(255)]
    public string? Customername { get; set; }

    [Column("customerpassword")]
    [StringLength(255)]
    public string? Customerpassword { get; set; }

    [Column("dob")]
    public DateOnly? Dob { get; set; }

    [Column("pan")]
    [StringLength(255)]
    public string? Pan { get; set; }

    [Column("phonenumber")]
    [StringLength(255)]
    public string? Phonenumber { get; set; }

    [JsonIgnore]
    // ✅ Make these properties optional by setting `?`
    [InverseProperty("Customer")]
    public virtual ICollection<CartMaster>? CartMasters { get; set; } = new List<CartMaster>();
    [JsonIgnore]
    [InverseProperty("Customer")]
    public virtual ICollection<Invoice>? Invoices { get; set; } = new List<Invoice>();
    [JsonIgnore]
    [InverseProperty("Customer")]
    public virtual MyShelf? MyShelf { get; set; }
    [JsonIgnore]
    [InverseProperty("Customer")]
    public virtual ICollection<RentDetail>? RentDetails { get; set; } = new List<RentDetail>();
}
