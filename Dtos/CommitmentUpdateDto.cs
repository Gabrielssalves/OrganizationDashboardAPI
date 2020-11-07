using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OrganizationDashboardAPI.Dtos
{
    public class CommitmentUpdateDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime InitialCommitmentDate { get; set; }
        public DateTime FinalCommitmentDate { get; set; }
    }
}
