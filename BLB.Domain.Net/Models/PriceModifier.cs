using BLB.Domain.Net.Models.Enum;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace BLB.Domain.Net.Models
{
    public class PriceModifier : BaseEntity
    {
        [ForeignKey("Category")]
        public long? CategoryId { get; set; }

        public DateTime? EndDate { get; set; }

        public float? ExactMargin { get; set; }

        public float? ExactPrice { get; set; }

        public float? PercentMargin { get; set; }

        [ForeignKey("Product")]
        public long? ProductId { get; set; }

        [ForeignKey("ProductOption")]
        public long? ProductOptionId { get; set; }

        public DateTime? StartDate { get; set; }
    }
}