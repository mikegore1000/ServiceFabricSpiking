using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;
using Microsoft.ServiceFabric.Services.Client;

namespace TestApi.Controllers
{
    [ServiceRequestActionFilter]
    public class NamingController : ApiController
    {
        public async Task<string> Get()
        {
            var resolver = ServicePartitionResolver.GetDefault();
            var resolved = await resolver.ResolveAsync(
                new Uri("fabric:/ServiceFabricSpiking/TestApi"),
                new ServicePartitionKey(), 
                CancellationToken.None
            );

            return resolved.Endpoints.First().Address;
        }
    }
}
