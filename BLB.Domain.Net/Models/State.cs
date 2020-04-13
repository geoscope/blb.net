using System.ComponentModel.DataAnnotations.Schema;

namespace BLB.Domain.Net.Models
{
    public class State : CodeNamedBaseEntity
    {
        [ForeignKey("Country")]
        public long CountryId { get; set; }
    }
}