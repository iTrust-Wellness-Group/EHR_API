using EHR.Shared.Utils.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EHR.Context.CRM
{
    public class Leads
    {
        IHttpRequest? request = null;
        public Leads(IHttpRequest request) {
            this.request = request;
        }

        public Task<T> getLeads<T>()
        {
           return this.request!.GetAsync<T>("LeadsMetaData.Get");
        }
        
    }
}
