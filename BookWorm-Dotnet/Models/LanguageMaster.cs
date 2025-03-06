using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;

namespace BookWorm_Dotnet.Models;

[Table("language_master")]
public partial class LanguageMaster
{
    [Key]
    [Column("language_id")]
    public int LanguageId { get; set; }

    [Column("language_desc")]
    [StringLength(255)]
    public string? LanguageDesc { get; set; }

    [JsonIgnore]
    [InverseProperty("Language")]
    public virtual ICollection<ProductMaster>? ProductMasters { get; set; }
}
