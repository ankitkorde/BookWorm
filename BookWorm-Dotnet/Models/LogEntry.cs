using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookWorm_Dotnet.Models
{
    [Table("log_entries")]
    public class LogEntry
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public DateTime Timestamp { get; set; } = DateTime.UtcNow;

        [Required]
        [StringLength(50)]
        public string LogLevel { get; set; } = "Information";

        [Required]
        [StringLength(1000)]
        public string Message { get; set; }

        [StringLength(2000)]
        public string? Exception { get; set; }
    }
}
