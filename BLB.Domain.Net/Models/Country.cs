using System.Collections.Generic;

namespace BLB.Domain.Net.Models
{
    public class Country : CodeNamedBaseEntity
    {
        public ICollection<State> States { get; }
    }
}