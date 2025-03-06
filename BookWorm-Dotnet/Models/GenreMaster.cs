using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;

namespace BookWorm_Dotnet.Models;

[Table("genre_master")]
public partial class GenreMaster
{
    [Key]
    [Column("genre_id")]
    public int GenreId { get; set; }

    [Column("genre_desc")]
    [StringLength(255)]
    public string? GenreDesc { get; set; }

    [JsonIgnore]
    [InverseProperty("Genre")]
    public virtual ICollection<ProductMaster>? ProductMasters { get; set; } 
}
