using System.ComponentModel.DataAnnotations.Schema;

namespace BLB.Domain.Net.Models
{
    public class StoreDomainName : BaseEntity
    {
        public string DomainName { get; set; }

        [ForeignKey("Store")]
        public long StoreId { get; set; }
    }
}