using AutoMapper;
using EHR.Application.Contract.Identity;
using EHR.Application.Contract.CRM.Office;
using EHR.Identity.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EHR.Application.Feature.UnitOfWork
{
    public class ServiceContext : IServiceContext
    {
        public IMapper mapper { get; private set; }
        public IOfficeRepository office { get; private set; }

        public IIdentityRepository identity { get; private set; }
        public IJWTService jwtService { get; private set; }
        public ServiceContext(IMapper mapper, IOfficeRepository office, IIdentityRepository identity, IJWTService jwtService)
        {
            this.mapper = mapper;
            this.office = office;
            this.identity = identity;
            this.jwtService = jwtService;
        }

    }
}
