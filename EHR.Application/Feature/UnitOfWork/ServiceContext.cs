using EHR.Application.Contract.Identity;
using EHR.Application.Contract.ReferralSystem.Office;
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

        public IOfficeRepository office { get; private set; }

        public IIdentityRepository identity { get; private set; }
        public IJWTService jwtService { get; private set; }
        public ServiceContext(IOfficeRepository office, IIdentityRepository identity, IJWTService jwtService)
        {
            this.office = office;
            this.identity = identity;
            this.jwtService = jwtService;
        }

    }
}
