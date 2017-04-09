using System.Collections.Generic;
using System.Web.Http;

namespace TestApi2.Controllers
{
    [ServiceRequestActionFilter]
    public class ValuesController : ApiController
    {
        // GET api/values 
        public string Get()
        {
            return "Response from Test API 2";
        }
    }
}
