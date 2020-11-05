using OrganizationDashboardAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OrganizationDashboardAPI.Data
{
    public class SqlCommitmentRepo : ICommitmentRepo
    {
        private readonly OrganizationDashboardAPIContext _context;

        public SqlCommitmentRepo(OrganizationDashboardAPIContext context)
        {
            _context = context;
        }

        public void CreateCommitment(Commitment cmt)
        {
            if (cmt == null)
            {
                throw new ArgumentNullException(nameof(cmt));
            }

            _context.Add(cmt);
        }

        public void DeleteCommitment(Commitment cmt)
        {
            if(cmt == null)
            {
                throw new ArgumentNullException(nameof(cmt));
            }

            _context.Commitments.Remove(cmt);
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
