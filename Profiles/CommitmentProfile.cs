using AutoMapper;
using OrganizationDashboardAPI.Dtos;
using OrganizationDashboardAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace OrganizationDashboardAPI.Profiles
{
    public class CommitmentProfile : Profile
    {
        public CommitmentProfile()
        {

            //Source -> Target
            CreateMap<Commitment, CommitmentReadDto>();
            CreateMap<Commitment, CommitmentCreateDto>();
            CreateMap<Commitment, CommitmentUpdateDto>();

        } 
    }
}
