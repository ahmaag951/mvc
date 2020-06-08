using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess;

namespace BusinessLogic
{
    public class UserProxy : EntityBase<User>
    {
        public bool IsUserExists(User user)
        {
            return Items.Where(r => r.Username == user.Username && r.Password == user.Password).FirstOrDefault() != null;
        }

    }
}
