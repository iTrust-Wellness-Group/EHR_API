using EHR.Application.Feature.ReferralSystem.Office.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EHR.Application.Contract.ReferralSystem.Office
{
    public interface IOfficeRepository
    {
        public List<OfficeRes> getOfficeList();
        public List<OfficeRes> getOfficeList(String Name);
    }
}
