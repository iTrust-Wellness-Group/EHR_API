using EHR.Application.Contract.ReferralSystem.Office;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EHR.Application.Feature.UnitOfWork
{
    public interface IUnitOfWork
    {
        IOfficeRepository office { get;  }
    }
}
