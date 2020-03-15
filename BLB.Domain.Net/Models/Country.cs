using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BLB.Domain.Net.Models
{
    public class Country
    {
        [Required]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        public bool IsEnabled { get; set; }

        [StringLength(256)]
        public string Name { get; set; }

        public ICollection<State> States { get; }
    }
}