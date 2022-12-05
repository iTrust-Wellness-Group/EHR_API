using AWS.SecrectManager;
using AWS;
using EHR.Shared.Utils.Http;
using EHR.Context.Models;

namespace EHR.Context
{
    public class BasicContext
    {
        private readonly IHttpRequest _httpRequest;
        private static DateTime? _expiretime;

        public BasicContext(IHttpRequest httpRequest, string baseUrl, Credential credential)
        {
            _httpRequest = httpRequest;
            _httpRequest.BaseUrl = baseUrl;
            if (_expiretime == null || DateTime.Now.Date > _expiretime.Value.Date)
            {
                ContextCredential contextCredential = this.GetCredentialByType(credential);
                if(!String.IsNullOrEmpty(contextCredential.Expire))
                {
                    _expiretime = this.UnixTimeStampToDateTime(double.Parse(contextCredential.Expire));
                }

            }
        }

        public ContextCredential GetCredentialByType(Credential credential)
        {
            var contextCredential = SecretsManager.GetSecret<ContextCredential>(credential.ToString())!;
            this._httpRequest.Credential = credential.ToString();
            this._httpRequest.Token = contextCredential.AccessToken;
            this._httpRequest.SecretKey = contextCredential.SecretKey;
            return contextCredential;
        }

        private DateTime UnixTimeStampToDateTime(double unixTimeStamp)
        {
            // Unix timestamp is seconds past epoch
            DateTime dateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
            dateTime = dateTime.AddSeconds(unixTimeStamp).ToLocalTime();
            return dateTime;
        }
    }
}