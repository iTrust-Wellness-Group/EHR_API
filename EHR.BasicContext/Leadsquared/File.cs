using EHR.Shared.Utils.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EHR.Context.CRM
{
    public class File
    {
        IHttpRequest? request = null;
        public File(IHttpRequest request)
        {
            this.request = request;
        }

        public Task<T> getFile<T>()
        {
            return this.request!.GetAsync<T>("LeadManagement.svc/Leads.GetById?");
        }


        public Task<T> sendFile<T>(object data)
        {
            return this.request!.PostAsync<T>("FileMarketing.svc/SendFileToLead", data);
        }


    }
}
