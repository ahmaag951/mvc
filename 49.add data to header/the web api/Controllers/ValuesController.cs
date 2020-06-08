using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace the_web_api.Controllers
{
    public class ValuesController : ApiController
    {
        // GET api/values
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        public string Get(int? id)
        {
            if (id == null)
            {
                id = 0;
            }

            var re = Request;
            var headers = re.Headers;
            string token = "";
            if (headers.Contains("MyCustomData"))
            {
                token = headers.GetValues("MyCustomData").First();
            }

            return "id: " + id.ToString() + "\n and this value is from the header: " + token;
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