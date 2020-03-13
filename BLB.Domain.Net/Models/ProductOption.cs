using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BLB.Domain.Net.Models
{
    public class ProductOption : NamedBaseEntity
    {
        [Required]
        [Range(1, long.MaxValue)]
        [ForeignKey("Product")]
        public long ProductId { get; set; }

        public int SortOrder { get; set; }
    }
}