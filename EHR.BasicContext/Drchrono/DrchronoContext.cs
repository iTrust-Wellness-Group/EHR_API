using EHR.Context.Models;
using EHR.Shared.Utils.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EHR.Context.Drchrono
{
    public class DrchronoContext : BasicContext
    {
        private static string baseUrl = "https://drchrono.com/api/";
        public Patient Patient { get; private set; }


        public DrchronoContext(IHttpRequest httpRequest):base(httpRequest,baseUrl,Credential.drchronoAccessToken)
        {
            // generate all of Drchrono class
            Patient = new Patient(httpRequest); 
        }
    }
}
