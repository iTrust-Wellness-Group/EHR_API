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
    public interface IServiceContext
    {
        IMapper mapper { get; }
        IOfficeRepository office { get; }
        IIdentityRepository identity {get;}
        IJWTService jwtService { get; }
    }
}
