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
        IEnumerable<Space> GetSpacesByUser(string userId);
        Space GetSpaceById(int id);
        void CreateSpace(Space space);
        void UpdateSpace(Space space);
        void DeleteSpace(Space space);

    }
}
