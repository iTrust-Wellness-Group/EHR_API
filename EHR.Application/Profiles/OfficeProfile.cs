using AutoMapper;
using EHR.Application.Feature.ReferralSystem.Office.Models;
using EHR.Database.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EHR.Application.Profiles
{
    public class OfficeProfile : Profile
    {
        public OfficeProfile()
        {
            CreateMap<Office, OfficeModel>().ReverseMap();
        }

    }
}
