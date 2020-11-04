﻿using OrganizationDashboard.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrganizationDashboard.Data
{
    public interface IOrganizationDashboardRepo
    {
        bool SaveChanges();

        IEnumerable<Commitment> GetAllCommitments();
        Commitment GetCommitmentById(int id);
        void CreateCommitment(Commitment cmt);
        void UpdateCommitment(Commitment cmt);
    }
}
