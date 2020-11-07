using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OrganizationDashboardAPI.Models
{
    public class Commitment
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
        public string Description { get; set; }

        [Required]
        public DateTime Date { get; set; }
        
        [Required]
        public int SpaceId { get; set; }
    }
}
