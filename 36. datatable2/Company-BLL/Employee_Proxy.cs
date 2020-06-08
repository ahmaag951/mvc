using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Company_DAL;

namespace Company_BLL
{
    public class Employee_Proxy : EntityBase<Employee>
    {
        public Employee GetById(int id)
        {
            return Items.Where(r => r.id == id).FirstOrDefault();
        }

        public object GetByIdJson(int id)
        {
            var t = Items.Where(r => r.id == id).Select(x => new
            {
                id = x.id,
                name = x.name,
                age = x.age,
                country = (x.Country == null ? "" : x.Country.Name),
                countryId = x.countryId,
                email = x.email,
                isDeleted = x.isDeleted

            }).FirstOrDefault();

            return t;
        }

        

        public IEnumerable<Employee> GetAllEmployees()
        {
            return Items.Where(r => r.isDeleted != true).ToList();
        }

        public IEnumerable<Employee> GetAllEmployeesWithDeleted()
        {
            return Items;
        }
    }
}
