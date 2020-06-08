using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public class EmployeeProxy : EntityBase<Employee>
    {
        public IEnumerable<Employee> GetEmployees(Employee employee) {
            Expression<Func<Employee, bool>> predicate = BuildPredicate(employee);

            return SearchBy(predicate);
        }

        public Expression<Func<Employee, bool>> BuildPredicate(Employee model)
        {
            bool flag = false;
            Expression<Func<Employee, bool>> predicate;
            predicate = PredicateBuilder.True<Employee>();

            if (!string.IsNullOrEmpty(model.email))
            {
                predicate = predicate.And(s => s.email.Contains(model.email));
            }

            if (!string.IsNullOrEmpty(model.name))
            {
                predicate = predicate.And(s => s.name.Contains(model.name));
            }

            if (model.age != null)
            {
                predicate = predicate.And(s => s.age == model.age);
            }

            //if (!string.IsNullOrEmpty(model.Country.Name))
            //{
            //    predicate = predicate.And(s => s.Country.Name.Contains(model.Country.Name));
            //}
            //if (model.CreationDate != null)
            //{
            //    predicate = predicate.And(s => s.CreationDate.GetValueOrDefault().Date == model.CreationDate.GetValueOrDefault().Date);
            //}
            return predicate;
        }


    }
}
