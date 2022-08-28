
using EHR.Application.Contract.ReferralSystem.Office;
using EHR.Application.Feature.ReferralSystem.Office.Query;
using EHR.Database.Context;
using EHR.Database.Entities;
using EHR.Infrastructure.Repositories.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EHR.Infrastructure.Repositories.Query
{
    internal class OfficeRepository : BaseRepository<Office>, IOfficeRepository
    {
        private DatabaseContext context;
        public OfficeRepository(DatabaseContext context):base(context)
        {
            this.context = context;
        }

        public async Task<bool> createOffice(string Name)
        {
            try
            {
               
                Office office = new Office();
                office.Id = Guid.NewGuid();
                office.Name = Name;
                await CreateAsync(office);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
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
