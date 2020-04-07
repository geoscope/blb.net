using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BLB.Domain.Net.Models
{
    public class Category : NamedBaseEntity
    {
        public ICollection<ProductInCategory> CategoryProducts { get; }

        [Required]
        [ForeignKey("Store")]
        public long StoreId { get; set; }

        [Range(1, long.MaxValue)]
        public long? ParentCategoryId { get; set; }
    }
}