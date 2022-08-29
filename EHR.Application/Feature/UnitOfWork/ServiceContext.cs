using EHR.Application.Contract.ReferralSystem.Office;
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

        public ServiceContext(IOfficeRepository office)
        {
            this.office = office;
        }

    }
}
