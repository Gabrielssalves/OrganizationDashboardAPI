using OrganizationDashboardAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrganizationDashboardAPI.Data
{
    public class SqlSpaceRepo : ISpaceRepo
    {

        private readonly OrganizationDashboardAPIContext _context;

        public SqlSpaceRepo(OrganizationDashboardAPIContext context)
        {
            _context = context;
        }
        public void CreateSpace(Space space)
        {
            if (space == null)
            {
                throw new ArgumentNullException(nameof(space));
            }

            _context.Add(space);
        }

        public void DeleteSpace(Space space)
        {
            if (space == null)
            {
                throw new ArgumentNullException(nameof(space));
            }

            _context.Spaces.Remove(space);
        }

        public IEnumerable<Space> GetAllSpaces()
        {
            return _context.Spaces.ToList();
        }

        public Space GetSpaceById(int id)
        {
            return _context.Spaces.FirstOrDefault(p => p.Id == id);
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }

        public void UpdateSpace(Space space)
        {
            throw new NotImplementedException();
        }
    }
}
