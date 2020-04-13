using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BLB.Domain.Net.Models
{
    public class Page : NamedBaseEntity
    {
        [Required]
        public string Body { get; set; }

        public DateTime? EndDate { get; set; }

        [Range(1, long.MaxValue)]
        public long? ParentPageId { get; set; }

        public DateTime? StartDate { get; set; }

        [ForeignKey("Store")]
        public long StoreId { get; set; }
    }
}