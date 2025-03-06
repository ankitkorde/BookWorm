using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;

namespace BookWorm_Dotnet.Models;

[Table("my_shelf")]
[Index("CustomerId", Name = "UKa0wjpu0o249cdo2it1dxw19of", IsUnique = true)]
public partial class MyShelf
{
    [Key]
    [Column("shelf_id")]
    public int ShelfId { get; set; }

    [Column("no_of_books")]
    public int NoOfBooks { get; set; }

    [Column("customer_id")]
    public long CustomerId { get; set; }

    [JsonIgnore]
    [ForeignKey("CustomerId")]
    [InverseProperty("MyShelf")]
    public virtual CustomerMaster Customer { get; set; } = null!;

    [JsonIgnore]
    [InverseProperty("Shelf")]
    public virtual ICollection<MyShelfDetail> MyShelfDetails { get; set; } = new List<MyShelfDetail>();
}
