using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BLB.Domain.Net.Models
{
    public class StoreSetting : BaseEntity
    {
        [Required]
        [StringLength(256)]
        public string Key { get; set; }

        [Required]
        [ForeignKey("Store")]
        public long StoreId { get; set; }

        [StringLength(512)]
        public string Value { get; set; }
    }
}