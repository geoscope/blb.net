using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BLB.Domain.Net.Models
{
    public class Product : NamedBaseEntity
    {
        [Required]
        [Range(0, float.MaxValue)]
        public float CostPrice { get; set; }

        public string Description { get; set; }

        [Range(0, long.MaxValue)]
        public long? PrimaryProductImageId { get; set; }

        public ICollection<ProductAttribute> ProductAttributes { get; set; }

        public ICollection<ProductInCategory> ProductCategories { get; set; }

        public ICollection<ProductImage> ProductImages { get; set; }

        public ICollection<ProductOption> ProductOptions { get; set; }

        [Range(0, long.MaxValue)]
        public long? ProductSupplierId { get; set; }

        [StringLength(50)]
        public string Sku { get; set; }

        public DateTime? StockBackOrderEstimatedArrival { get; set; }

        [Range(0, int.MaxValue)]
        public int? StockOnBackOrder { get; set; }

        [Range(0, int.MaxValue)]
        public int? StockOnHand { get; set; }

        [Range(0, int.MaxValue)]
        public int? StockReorderLevel { get; set; }

        [ForeignKey("Store")]
        public long StoreId { get; set; }
    }
}