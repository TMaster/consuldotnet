using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Consul.Interfaces;

namespace Consul.Utilities
{
    /// <summary>
    /// Basic implementation of <see cref="IConsulClientFactory"/>
    /// </summary>
    /// <remarks>
    /// This basic structure provide a working <see cref="ConsulClient"/>.
    /// If you wish to change the following settings, please inhrit from the base class and override the necessary settings.
    /// </remarks>
    public  class BaseConsulClientFactory : IConsulClientFactory
    {
        virtual public ConsulClientConfiguration CreateConsulConfiguration()
        {
            return new ConsulClientConfiguration();
        }

        /// <summary>
        /// Creates new instance of <see cref="HttpClient"/>
        /// </summary>
        /// <remarks>
        /// Please note, the HttpClient must accept the "application/json" content, if you override this method please make sure you call the base method or add the header manually.
        /// </remarks>
        /// <returns></returns>
        virtual public HttpClient CreateHttpClient()
        {
            var httpClient = new HttpClient(CreateHttpHandler())
            {
                Timeout = TimeSpan.FromMinutes(15)
            
            };

            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

           httpClient.DefaultRequestHeaders.Add("Keep-Alive","true");

            return httpClient;

        }

        //Other entities should not have access to this nethod, the CreateHttpClient only should call this method.
        virtual protected WebRequestHandler CreateHttpHandler()
        {
            return new WebRequestHandler();
        }
    }
}
