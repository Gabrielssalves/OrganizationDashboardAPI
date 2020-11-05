using OrganizationDashboardAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrganizationDashboardAPI.Data
{
    public interface ISpaceRepo
    {
        bool SaveChanges();

        IEnumerable<Space> GetAllSpaces();
        Space GetSpaceById(int id);
        void CreateSpace(Space space);
        void UpdateSpace(Space space);
        void DeleteSpace(Space space);

    }
}
