using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
//using System.Web.Mvc;
using System.Web.Mvc;
using web_api_calls_stored_procedure.dto;
using web_api_calls_stored_procedure.Models;

namespace web_api_calls_stored_procedure.Controllers
{
    public class CountryController : ApiController
    {
        private CompanyEntities db;

        public CountryController()
        {
            db = new CompanyEntities();
        }

        // GET api/<controller>
        //[Route("api/Country/GetAllCountries")]
        public IEnumerable<CountryDto> GetAllCountries()
        {
            var countries = db.UspGetAllCountries().Select(r => new CountryDto()
            {
                Id = r.Id,
                Name = r.Name
            });
            return countries;
        }

        // GET api/<controller>/5
        public string GetCountry(int id)
        {
            return "value";
        }

        //// POST api/<controller>
        //public void AddCountry([FromBody]string value)
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