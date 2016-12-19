using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApiCacheDemo.Contracts.Samples;

namespace WebApiCacheDemo.Mvc.Clients.Interfaces
{
    public interface ISampleClient : IRestClient
    {
        DateNumberObject GetSampleDateAndNumber();

        DateNumberObject GetSampleDateAndNumberUncached();
    }
}