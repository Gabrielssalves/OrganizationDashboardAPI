using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OrganizationDashboard.Models;

namespace OrganizationDashboard.Data
{
    public class SqlOrganizationDashboardRepo : IOrganizationDashboardRepo
    {
        private readonly OrganizationDashboardContext _context;

        public SqlOrganizationDashboardRepo(OrganizationDashboardContext context)
        {
            _context = context;
        }

        public void CreateCommitment(Commitment cmt)
        {
            if(cmt == null)
            {
                throw new ArgumentNullException(nameof(cmt));
            }

            _context.Add(cmt);
        }

        public IEnumerable<Commitment> GetAllCommitments()
        {
            return _context.Commitments.ToList();
        }

        public Commitment GetCommitmentById(int id)
        {
            return _context.Commitments.FirstOrDefault(p => p.Id == id);
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }

        public void UpdateCommitment(Commitment cmt)
        {
            throw new NotImplementedException();
        }
    }
}
