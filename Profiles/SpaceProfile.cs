using AutoMapper;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using OrganizationDashboardAPI.Dtos;
using OrganizationDashboardAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrganizationDashboardAPI.Profiles
{
    public class SpaceProfile : Profile
    {
        public SpaceProfile()
        {
            //Source -> Target
            CreateMap<Space, SpaceReadDto>();
            CreateMap<Space, SpaceCreateDto>();
            CreateMap<SpaceUpdateDto, Space>();
            CreateMap<Space, SpaceUpdateDto>();
        }
    }
}
