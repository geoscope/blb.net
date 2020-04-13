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

        public ICollection<StoreDomainName> StoreDomainNames { get; }

        public ICollection<Page> StorePages { get; }

        public ICollection<StoreSetting> StoreSettings { get; }

        public ICollection<User> StoreUsers { get; }

        [StringLength(512)]
        public string Summary { get; set; }
    }
}