using OrganizationDashboardAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrganizationDashboardAPI.Data
{
    public class MockCommitmentRepo : ICommitmentRepo
    {
        public void CreateCommitment(Commitment cmt)
        {
            throw new NotImplementedException();
        }

        public void DeleteCommitment(Commitment cmt)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Commitment> GetAllCommitments()
        {
            var commitments = new List<Commitment>
            {
                new Commitment { Id = 0, Name = "Almoço", Description = "Fritar um ovão maneiro!", Date = DateTime.Now.ToUniversalTime() },
                new Commitment { Id = 1, Name = "Café da tarde", Description = "Fazer uns pão de queijo top", Date = DateTime.Now.ToUniversalTime() },
                new Commitment { Id = 2, Name = "janta", Description = "MCzão", Date = DateTime.Now.ToUniversalTime() }
            };

            return commitments;
        }

        public Commitment GetCommitmentById(int id)
        {
            return new Commitment { Id = 0, Name = "Almoço", Description = "Fritar um ovão maneiro!", Date = DateTime.Now.ToUniversalTime() };
        }

        public IEnumerable<Commitment> GetCommitmentsBySpace(int spaceId)
        {
            throw new NotImplementedException();
        }

        public bool SaveChanges()
        {
            throw new NotImplementedException();
        }

        public void UpdateCommitment(Commitment cmt)
        {
            throw new NotImplementedException();
        }
    }
}
