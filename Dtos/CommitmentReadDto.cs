using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrganizationDashboardAPI.Dtos
{
    public class CommitmentReadDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime InitialCommitmentDate { get; set; }
        public DateTime FinalCommitmentDate { get; set; }
    }
}
