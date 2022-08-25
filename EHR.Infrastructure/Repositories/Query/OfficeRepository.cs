
using EHR.Application.Contract.ReferralSystem.Office;
using EHR.Application.Feature.ReferralSystem.Office.Query;
using EHR.Database.Context;
using EHR.Database.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EHR.Infrastructure.Repositories.Query
{
    internal class OfficeRepository : IOfficeRepository
    {
        private DatabaseContext context;
        public OfficeRepository(DatabaseContext context)
        {
            this.context = context;
        }

        public List<OfficeRes> getOfficeList()
        {
            return this.context.Offices.Select(x=> new OfficeRes { Id = x.Id,Name = x.Name}).ToList();
        }

        public List<OfficeRes> getOfficeList(string Name)
        {
            return this.context.Offices.Select(x => new OfficeRes { Id = x.Id, Name = x.Name }).Where(x=>x.Name.Contains(Name)).ToList();
        }
    }
}
