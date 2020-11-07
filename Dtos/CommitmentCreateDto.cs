using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OrganizationDashboardAPI.Dtos
{
    public class CommitmentCreateDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public DateTime InitialCommitmentDate { get; set; }
        public DateTime FinalCommitmentDate { get; set; }
        public int SpaceID { get; set; }
    }
}
