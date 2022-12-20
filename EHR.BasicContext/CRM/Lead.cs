using EHR.Shared.Utils.Http;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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

        public Task<T> getLeadMetdadata<T>()
        {
            return this.request!.GetAsync<T>("LeadManagement.svc/LeadsMetaData.Get");
        }

        public Task<T> getLeadById<T>(string leadId)
        {
            return this.request!.GetAsync<T>("LeadManagement.svc/Leads.GetById", new Dictionary<string, string>
            {
                { "id", leadId } 
            });
        }

        public Task<T> getLeadByEmail<T>(string email)
        {
            return this.request!.GetAsync<T>("LeadManagement.svc/Leads.GetByEmailaddress", new Dictionary<string, string>
            {
                { "EmailAddress" , email}
            });
        }

        public Task<T> getLeadByPhone<T>(string phone)
        {
            return this.request!.GetAsync<T>("LeadManagement.svc/RetrieveLeadByPhoneNumber", new Dictionary<string, string>
            {
                { "Phone" , phone}
            });
        }

        public Task<T> getLeadsByKey<T>(Dictionary<string, string> key)
        {
            string[] _validKeys = { "FirstName", "LastName", "EmailAddress", "Phone", "Mobile", "Company", "City", "Country" };
            Debug.Assert(key.Count == 1, "Key search can only have 1 key");
            Debug.Assert(_validKeys.Contains(key.Keys.First()), "Invalid search key");

            return this.request!.GetAsync<T>("LeadManagement.svc/Leads.GetByQuickSearch", key);
        }

        public Task<T> getLeadsByCriteria<T>(object data)
        {
  

            return this.request!.PostAsync<T>("LeadManagement.svc/Leads.Get", data);
        }

        public Task<T> updateLead<T>(object data, Dictionary<string, string> urlParams)
        {
            return this.request!.PostAsync<T>("LeadManagement.svc/Lead.Update", data, urlParams);
        }


    }
}
