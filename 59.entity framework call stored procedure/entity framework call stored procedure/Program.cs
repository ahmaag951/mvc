using System;
using System.Collections.Generic;
using System.Data.Objects;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace entity_framework_call_stored_procedure
{
    class Program
    {
        static void Main(string[] args)
        {
            CompanyEntities db = new CompanyEntities();
            // if the stored procedure doesn't take parameters you wont have any problems
            // after you add it to the model you will be able to use it immediatly

            // if you want to delete a stored procedure 
            // open the edmx file => go to model browser => then delete it from 
            // stored/functions and function imports
            List<UspGetAllCountries_Result> countries = db.UspGetAllCountries().ToList();

            foreach (var item in countries)
            {
                Console.WriteLine(item.Name);
            }
            Console.WriteLine("---------------------------");
            // stored procedure with parameters
            var country = db.UspGetCountry(1).FirstOrDefault();
            if (country != null)
            {
                Console.WriteLine(country);
            }
            Console.WriteLine("---------------------------");

            Console.ReadKey();
        }
    }
}
