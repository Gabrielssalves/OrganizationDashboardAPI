using OrganizationDashboardAPI.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OrganizationDashboardAPI.Dtos
{
    public class UserCreateDto
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Senha { get; set; }
        public string ProfileImage { get; set; }
        public ICollection<Space> Spaces { get; set; }
        [Required]
        public DateTime CreationDate { get; set; }
    }
}
