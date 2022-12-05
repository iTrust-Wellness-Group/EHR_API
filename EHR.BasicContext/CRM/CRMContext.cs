using EHR.Context.Models;
using EHR.Shared.Utils.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EHR.Context.CRM
{
    public class CRMContext : BasicContext
    {
        private static string baseUrl = "http://{host}/v2/LeadManagement.svc/";
        public Leads Leads { get; private set; }


        public CRMContext(IHttpRequest httpRequest):base(httpRequest,baseUrl,Credential.leadsquaredAccessToken)
        {
            // generate all of Drchrono class
            Leads = new Leads(httpRequest); 
        }
    }
}
