using AutoMapper;
using EHR.Application.Contract.Identity;
using EHR.Application.Contract.CRM.Office;
using EHR.Identity.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EHR.Shared.Extension;
using EHR.Shared.Attributes;

namespace EHR.Application.Feature.UnitOfWork
{
    public class ServiceContext : IServiceContext
    {
        public IMapper mapper { get; set; }
        public IOfficeRepository office { get; set; }

        public IIdentityRepository identity { get; set; }
        public IJWTService jwtService { get; set; }
        public ServiceContext(IMapper mapper, IOfficeRepository office, IIdentityRepository identity, IJWTService jwtService)
        {
            this.mapper = mapper;
            this.office = office;
            this.identity = identity;
            this.jwtService = jwtService;
        }
        //public ServiceContext(IServiceProvider provider)
        //{
        //    provider.Inject(this);
        //}

    }
}
