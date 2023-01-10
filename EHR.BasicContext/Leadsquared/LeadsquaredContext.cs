using EHR.Context.Models;
using EHR.Shared.Utils.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EHR.Context.CRM
{
    public class LeadsquaredContext : BasicContext
    {
        private static string baseUrl = "http://api-us11.leadsquared.com/v2/";
        private static string baseFileUrl = "https://files-us11.leadsquared.com/";
        public Leads Leads { get; private set; }
        public Email Email { get; private set; }
        public File File { get; private set; }
        public LeadsquaredContext(IHttpRequest httpRequest):base(httpRequest,baseUrl,Credential.leadsquaredAccessToken)
        {
            // generate all of Drchrono class
            Leads = new Leads(httpRequest);
            Email = new Email(httpRequest);
            File = new File(httpRequest);

        }

    }
}
