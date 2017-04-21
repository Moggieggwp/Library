using System.Web.Http;

namespace Library.Controllers.Api
{
    public class DefaultController : ApiController
    {
        [HttpGet]
        public string Get1()
        {
            return "value";
        }

        [HttpPost]
        public void Post1([FromBody]string value)
        {
        }
    }
}
