using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BLB.Domain.Net.Models
{
    public class Store : BaseEntity
    {
        [Required]
        [StringLength(256)]
        public string Code { get; set; }

        [Range(0, float.MaxValue)]
        public float DefaultPercentageMargin { get; set; }

        [StringLength(256)]
        public string DefaultProductImageUri { get; set; }

        public string Description { get; set; }

        [Required]
        [StringLength(256)]
        public string Name { get; set; }

        public ICollection<Category> StoreCategories { get; }

        public ICollection<StoreHostName> StoreDomainNames { get; }

        public ICollection<Page> StorePages { get; }

        public ICollection<StoreSetting> StoreSettings { get; }

        public ICollection<User> StoreUsers { get; }

        public ICollection<Order> StoreOrders { get; }

        [StringLength(512)]
        public string Summary { get; set; }
    }
}