using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace api_wadl_xml_documentation.Controllers
{
    public class ValuesController : ApiController
    {
        //- to add documentation to wadle => add a summary comment before the method you want to add the comment to
        //- to see this documentation 1. go to app properties => build => xml documentation file=>
        //App_Data\{your_app_name}
        //2. go to helppageconfig and uncomment the xmldocumentation line in the code and rename the xml file name


        /// <summary>
        /// This is a sample documentation created by me.
        /// </summary>
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        public string Get(int id)
        {
            return "value";
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
