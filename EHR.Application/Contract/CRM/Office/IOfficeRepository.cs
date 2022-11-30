using EHR.Application.Feature.CRM.Office.QueryOffice;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EHR.Application.Contract.CRM.Office
{
    public interface IOfficeRepository : IBaseCommandRepository<EHR.Database.Entities.Office>
    {
        public List<QueryOfficeRes> getOfficeList();
        public QueryOfficeRes getOffice(String Name);
        public Task<bool> createOffice(string Name);
    }
}
