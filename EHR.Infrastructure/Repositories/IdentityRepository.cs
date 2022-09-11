using EHR.Application.Contract.Identity;
using EHR.Application.Feature.Identity.Models;
using EHR.Application.Models;
using EHR.Database.Context;
using EHR.Database.Entities;
using EHR.Infrastructure.Repositories.Command;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EHR.Infrastructure.Repositories
{
    internal class IdentityRepository : BaseRepository<Account>, IIdentityRepository
    {
        DatabaseContext commandContext;
        IDbConnection queryContext;
        public IdentityRepository(DatabaseContext commandContext, IDbConnection queryContext) : base(commandContext, queryContext)
        {
            this.commandContext = commandContext;
            this.queryContext = queryContext;
        }

        public Task<Account> LoginAsync(LoginModel req)
        {
            throw new NotImplementedException();
        }

        public Task LoginO365Async()
        {
            throw new NotImplementedException();
        }

        public bool RefreshTokenAsync(RefreshModel req)
        {
           Account? account = this.commandContext.Accounts.Where(x => x.Id.Equals(req.UserID) && x.RefreshToken.Equals(req.RefreshToken)).FirstOrDefault();
            if (account != null)
                return true;
            else
                return false;
            
        }

        public bool RevokeToken(RefreshModel req)
        {
            Account? account = this.commandContext.Accounts.Find(req.UserID);
            if (account != null)
            {
                account.RefreshToken = req.RefreshToken;
                this.commandContext.SaveChanges();
                return true;
            }
                
            else
                return false;
        }
    }
}
