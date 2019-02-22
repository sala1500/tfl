using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using Newtonsoft.Json;
using RoadStatus.Code.Contracts;

namespace RoadStatus.Code.Concretes
{
    public class ApiReader : IApiReader
    {
        public IEnumerable<T> Get<T>(string apiPath)
        {
            using (var client = new HttpClient())
            {
                var request = new HttpRequestMessage(HttpMethod.Get, apiPath);
                request.Headers.Add("Accept", "application/json");
                var response = client.SendAsync(request);

                var content = response.Result.Content.ReadAsStringAsync().Result;
                var status = response.Result.StatusCode;
                var reasonPhrase = response.Result.ReasonPhrase;

                request.Dispose();
                response.Dispose();

                if (status == HttpStatusCode.OK)
                {
                    return JsonConvert.DeserializeObject<List<T>>(content);
                }
                else if (status == HttpStatusCode.NotFound)
                {
                    throw new KeyNotFoundException(reasonPhrase);
                }
                else
                {
                    throw new Exception($"Unexpected Status Code: {status}; {reasonPhrase}");
                }
            }
        }
    }
}