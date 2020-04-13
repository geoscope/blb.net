using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace BLB.Domain.Net.Models
{
    public class Address : BaseEntity
    {
        [StringLength(50)]
        public string City { get; set; }

        [ForeignKey("Country")]
        public long CountryId { get; set; }

        [Required]
        [StringLength(100)]
        public string Line1 { get; set; }

        [StringLength(100)]
        public string Line2 { get; set; }

        [StringLength(10)]
        public string PostalCode { get; set; }

        [ForeignKey("State")]
        public long StateId { get; set; }

        [ForeignKey("User")]
        public long UserId { get; set; }
    }
}