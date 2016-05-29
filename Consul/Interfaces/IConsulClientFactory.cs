using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Consul.Interfaces
{

    /// <summary>
    /// Intializes the building blocks to create a dully functioning <see cref="ConsulClient"/>
    /// </summary>
    public interface IConsulClientFactory
    {
        
        ConsulClientConfiguration CreateConsulConfiguration();

        HttpClient CreateHttpClient();

    }
}
