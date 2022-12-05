using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EHR.Context.Models
{
    public class ContextCredential
    {
        public string AccessToken { get; set; }
        public string Expire { get; set; }
    }
    public enum Credential
    {
        drchronoAccessToken,
        goHighLevelAccessToken
    }
}
