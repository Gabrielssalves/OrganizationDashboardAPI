using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OrganizationDashboardAPI.Models
{
    public class Space
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [MaxLength(20)]
        public string Icon { get; set; }

        [MaxLength(20)]
        public string Color { get; set; }
        public ICollection<Commitment> Commitments { get; set; }
        [Required]
        public string UserId { get; set; }
    }
}
