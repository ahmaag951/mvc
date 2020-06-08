using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace HttpResponseMessage_and_IHttpActionResult.Controllers
{
    public class ValuesController : ApiController
    {
        // the old way
        public HttpResponseMessage Get()
        {
            if (true)
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Data not found");
            return Request.CreateResponse(new string[] { "value1", "value2" });
        }

        // the new way in api 2, simpler and clearer and easier for unit testing
        public IHttpActionResult Get(int id)
        {
            if (true)
                return NotFound();
            return Ok(new string[] { "value1", "value2" });
        }

        // POST api/values
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
