using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApiCacheDemo.Mvc.Clients.Interfaces;
using WebApiCacheDemo.Contracts.Samples;

namespace WebApiCacheDemo.Mvc.Clients
{
    public class SampleClient : RestClient, ISampleClient
    {
        public SampleClient()
        {
            BaseUrl = new Uri("http://localhost:58566/");
        }

        public DateNumberObject GetSampleDateAndNumber()
        {
            RestRequest request = new RestRequest("samples/date", Method.GET);
            var response = Execute<DateNumberObject>(request);
            return response.Data;
        }
    }
}