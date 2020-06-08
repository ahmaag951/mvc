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

        public IEnumerable<Employee> GetAllEmployees()
        {
            return Items.Where(r => r.isDeleted != true);
        }

        public IEnumerable<Employee> GetAllEmployeesWithDeleted()
        {
            return Items;
        }
    }
}
