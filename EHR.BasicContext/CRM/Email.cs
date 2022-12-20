using EHR.Shared.Utils.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EHR.Context.CRM
{
    public class Email
    {
        IHttpRequest? request = null;
        public Email(IHttpRequest request)
        {
            this.request = request;
        }

        public Task<T> getEmail<T>()
        {
            return this.request!.GetAsync<T>("LeadManagement.svc/Leads.GetById?");
        }


        public Task<T> sendEmail<T>(object data)
        {
            return this.request!.PostAsync<T>("EmailMarketing.svc/SendEmailToLead", data);
        }


    }
}
