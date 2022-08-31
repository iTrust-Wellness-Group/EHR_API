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
    public interface IServiceContext
    {
        IOfficeRepository office { get; }
        IIdentityRepository identity {get;}
        IJWTService jwtService { get; }
    }
}
