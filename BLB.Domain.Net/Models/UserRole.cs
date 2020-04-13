using System.Collections.Generic;

namespace BLB.Domain.Net.Models
{
    public class UserRole : BaseEntity
    {
        public string RoleName { get; set; }

        public ICollection<UserInUserRole> Users { get; }
    }
}