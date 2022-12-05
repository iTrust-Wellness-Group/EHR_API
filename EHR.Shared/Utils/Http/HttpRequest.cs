﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.Net.Http;

namespace EHR.Shared.Utils.Http
{
    public class HttpRequest : IHttpRequest, IDisposable
    {
        private readonly TimeSpan _timeout = TimeSpan.FromSeconds(90);
        private HttpClient? _httpClient;
        private HttpClientHandler? _httpClientHandler;
        private string _baseUrl = "";
        private string _token = "";
        private const string MediaTypeJson = "application/json";

        public string BaseUrl
        {
            set
            {
                _baseUrl = NormalizeBaseUrl(value);
            }
        }
        public string Token
        {
            set
            {
                this._token = value;
            }
        }

        public async Task<string> PostAsync(string url, object input)
        {
            EnsureHttpClientCreated();

            using (var requestContent = new StringContent(ConvertToJsonString(input), Encoding.UTF8, MediaTypeJson))
            {
                using (var response = await _httpClient!.PostAsync(url, requestContent))
                {
                    response.EnsureSuccessStatusCode();
                    return await response.Content.ReadAsStringAsync();
                }
            }
        }

        public async Task<TResult> PostAsync<TResult>(string url, object input)
        {
            var strResponse = await PostAsync(url, input);

            return JsonConvert.DeserializeObject<TResult>(strResponse, new JsonSerializerSettings
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver()
            })!;
        }

        public async Task<TResult> GetAsync<TResult>(string url)
        {
            var strResponse = await GetAsync(url);

            return JsonConvert.DeserializeObject<TResult>(strResponse, new JsonSerializerSettings
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver()
            })!;
        }

        public async Task<string> GetAsync(string url)
        {
            EnsureHttpClientCreated();

            using (var response = await _httpClient!.GetAsync(url))
            {
                response.EnsureSuccessStatusCode();
                return await response.Content.ReadAsStringAsync();
            }
        }

        public async Task<string> PutAsync(string url, object input)
        {
            return await PutAsync(url, new StringContent(JsonConvert.SerializeObject(input), Encoding.UTF8, MediaTypeJson));
        }

        public async Task<string> PutAsync(string url, HttpContent content)
        {
            EnsureHttpClientCreated();

            using (var response = await _httpClient.PutAsync(url, content))
            {
                response.EnsureSuccessStatusCode();
                return await response.Content.ReadAsStringAsync();
            }
        }

        public async Task<string> DeleteAsync(string url)
        {
            EnsureHttpClientCreated();

            using (var response = await _httpClient.DeleteAsync(url))
            {
                response.EnsureSuccessStatusCode();
                return await response.Content.ReadAsStringAsync();
            }
        }

        public void Dispose()
        {
            _httpClientHandler?.Dispose();
            _httpClient?.Dispose();
        }

        private void CreateHttpClient()
        {
            _httpClientHandler = new HttpClientHandler
            {
                AutomaticDecompression = DecompressionMethods.Deflate | DecompressionMethods.GZip,
            };

            _httpClient = new HttpClient(_httpClientHandler, false)
            {
                Timeout = _timeout
            };

            if (!string.IsNullOrWhiteSpace(_baseUrl))
            {
                _httpClient.BaseAddress = new Uri(_baseUrl);
            }

            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(MediaTypeJson));
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _token);
        }

        private void EnsureHttpClientCreated()
        {
            if (_httpClient == null)
            {
                CreateHttpClient();
            }
        }

        private static string ConvertToJsonString(object obj)
        {
            if (obj == null)
            {
                return string.Empty;
            }

            return JsonConvert.SerializeObject(obj, new JsonSerializerSettings
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver()
            });
        }

        private static string NormalizeBaseUrl(string url)
        {
            return url.EndsWith("/") ? url : url + "/";
        }
    }
}
