using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;

namespace wadl_web_api.Controllers
{
    public class DefaultController : ApiController
    {
        //Usage: url/Help
        // GET api/<controller>
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // if you want to execulde method from wadl
        [ApiExplorerSettings(IgnoreApi = true)]
        public string Get(int id)
        {
            return "value";
        }

        // GET api/<controller>/5
        public string NewMethod(int name)
        {
            return "value";
        }

        //// POST api/<controller>
        //public void Post([FromBody]string value)
        //{
        //}

        //// PUT api/<controller>/5
        //public void Put(int id, [FromBody]string value)
        //{
        //}

        //// DELETE api/<controller>/5
        //public void Delete(int id)
        //{
        //}
    }
}