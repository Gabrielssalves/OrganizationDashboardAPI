using OrganizationDashboardAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrganizationDashboardAPI.Data
{
    public interface ICommitmentRepo
    {
        bool SaveChanges();

        IEnumerable<Commitment> GetAllCommitments();
        IEnumerable<Commitment> GetCommitmentsBySpace(int spaceId);
        Commitment GetCommitmentById(int id);
        void CreateCommitment(Commitment cmt);
        void UpdateCommitment(Commitment cmt);
        void DeleteCommitment(Commitment cmt);

    }
}
