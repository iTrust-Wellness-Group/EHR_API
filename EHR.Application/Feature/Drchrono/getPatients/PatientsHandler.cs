using EHR.Application.Feature.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EHR.Application.Feature.Drchrono.getPatients
{
    public class PatientsHandler : BaseHandler{ 
        IServiceContext _serviceContext;

        public PatientsHandler(IServiceContext serviceContext)
        {
            _serviceContext = serviceContext;
        }

    }
}
