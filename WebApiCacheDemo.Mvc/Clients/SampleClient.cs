using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApiCacheDemo.Mvc.Clients.Interfaces;
using WebApiCacheDemo.Contracts.Samples;
using WebApiCacheDemo.Mvc.Caching;

namespace WebApiCacheDemo.Mvc.Clients
{
    public class SampleClient : RestClient, ISampleClient
    {
        private ICacheService _cache;
        public SampleClient(ICacheService cache)
        {
            _cache = cache;
            BaseUrl = new Uri("http://localhost:58566/");
        }

        public DateNumberObject GetSampleDateAndNumber()
        {
            return _cache.GetOrSet("SampleDateAndNumber", () => GetSampleDateAndNumberUncached(), 30); //Cached for 30 minutes
        }

        public DateNumberObject GetSampleDateAndNumberUncached()
        {
            RestRequest request = new RestRequest("samples/date", Method.GET);
            var response = Execute<DateNumberObject>(request);
            return response.Data;
        }
    }
}