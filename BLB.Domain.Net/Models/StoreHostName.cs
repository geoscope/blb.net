using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BLB.Domain.Net.Models
{
    public class StoreHostName : BaseEntity
    {
        public string HostName { get; set; }

        [Required]
        [ForeignKey("Store")]
        public long StoreId { get; set; }
    }
}