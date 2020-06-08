using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public class GroupUserProxy : EntityBase<GroupUser>
    {
        public bool IsUserInGroup(string user, string group)
        {
            return Items.Where(r => r.User.Username == user && r.Group.Name == group).FirstOrDefault() != null;
        }
    }
}
