using AutoMapper;
using OrganizationDashboard.Dtos;
using OrganizationDashboard.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrganizationDashboard.Profiles
{
    public class CommitmentsProfile : Profile
    {
        public CommitmentsProfile()
        {
            //Source -> Target
            CreateMap<Commitment, CommitmentReadDto>();
            CreateMap<Commitment, CommitmentCreateDto>();
            CreateMap<Commitment, CommitmentUpdateDto>();        }
    }
}
