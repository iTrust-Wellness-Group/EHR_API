
using EHR.Application.Contract.ReferralSystem.Office;
using EHR.Application.Feature.ReferralSystem.Office.Models;
using EHR.Application.Feature.ReferralSystem.Office.Query;
using EHR.Database.Context;
using EHR.Database.Entities;
using EHR.Infrastructure.Repositories.Command;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EHR.Infrastructure.Repositories.Query
{
    internal class OfficeRepository : BaseRepository<Office>, IOfficeRepository
    {
        private DatabaseContext context;
        private IDbConnection queryContext;
        public OfficeRepository(DatabaseContext commandContext, IDbConnection queryContext) : base(commandContext, queryContext)
        {
            this.context = commandContext;
            this.queryContext = queryContext;

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

        public List<OfficeModel> getOfficeList()
        {
            var list = this.context.Offices.Select(x => new OfficeModel { Id = x.Id, Name = x.Name }).ToList();

            return list;
        }

        public List<OfficeModel> getOfficeList(string Name)
        {
            return this.context.Offices.Select(x => new OfficeModel { Id = x.Id, Name = x.Name }).Where(x=>x.Name.Contains(Name)).ToList();
        }
    }
}
