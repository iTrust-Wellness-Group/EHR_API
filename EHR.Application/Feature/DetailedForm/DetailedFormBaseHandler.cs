using EHR.Application.Feature.UnitOfWork;
using EHR.Application.Models;
using EHR.Context.CRM;
using EHR.Database.Context;
using EHR.Database.Entities;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Mvc;

namespace EHR.Application.Feature.DetailedForm
{
    public class DetailedFormBaseHandler : BaseHandler
    {
        DatabaseContext _databaseContext;
        public DetailedFormBaseHandler(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
       
        }
        // TODO: refactor Error Handler
        public dynamic LookupCsrfToken(String csrfToken) 
        {
            var query = _databaseContext.CsrfTokens.Where(c => c.Token == csrfToken).ToList();
            var token = query.FirstOrDefault<CsrfToken>();

            if (token == null)  
                throw new Exception ("Invalid token");
            
            DateTimeOffset currentTime = DateTimeOffset.UtcNow;
            long epochTime = currentTime.ToUnixTimeSeconds();

            if (epochTime > token?.Expiry) { throw new Exception("Token Expired"); }
           
            return token?.LeadId ;
        }
    }
}
