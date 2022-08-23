using Dapper;
using EHR.Database.Context;
using EHR.Database.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EHR.Infrastructure.Repositories.Query
{
    public class Test
    {
        private DatabaseContext context;
        private DapperQueryContext _context;
        public Test(DatabaseContext dbcontext, DapperQueryContext _context)
        {
            this.context = dbcontext;
            this._context = _context;
        }
        public void TestFunc()
        {
            //EF Core
            Office office = new Office();
            office.Id = Guid.NewGuid();
            office.Name = "TestFunc";
            this.context.Offices.Add(office);
            this.context.SaveChanges();

            var list = this.context.Offices.ToList();
            //Dapper
            using var connection = this._context.CreateConnection();
            var result = connection.Query<Office>(@"select * from ""Office""").ToList();
        }

    }
}
