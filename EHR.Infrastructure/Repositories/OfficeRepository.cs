using Dapper;
using EHR.Application.Contract.CRM.Office;
using EHR.Application.Feature.CRM.Office.QueryOffice;
using EHR.Application.Feature.CRM.Office.UpdateOffice;
using EHR.Database.Context;
using EHR.Database.Entities;
using EHR.Infrastructure.Repositories.Command;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

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

        public QueryOfficeRes? getOffice(string Name)
        {
            return this.context.Offices.Select(x => new QueryOfficeRes { Id = x.Id, Name = x.Name }).Where(x=>x.Name.Contains(Name)).FirstOrDefault();
        }

        public List<QueryOfficeRes> getOfficeList()
        {
            return this.context.Offices.Select(x => new QueryOfficeRes { Id = x.Id, Name = x.Name }).ToList();
        }

        public async Task<bool> updateOffice(UpdateOfficeReq office)
        {
            return true;
        }
    }
}
