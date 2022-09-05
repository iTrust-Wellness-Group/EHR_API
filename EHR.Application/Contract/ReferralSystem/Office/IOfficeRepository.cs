using EHR.Application.Feature.ReferralSystem.Office.Models;
using EHR.Application.Feature.ReferralSystem.Office.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EHR.Application.Contract.ReferralSystem.Office
{
    public interface IOfficeRepository : IBaseCommandRepository<EHR.Database.Entities.Office>
    {
        // only init OfficeRepository
        List<OfficeModel> getOfficeList();
    }
}
