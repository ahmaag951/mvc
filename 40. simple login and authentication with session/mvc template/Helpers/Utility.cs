using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using DataAccess;

namespace mvc_template.Helpers
{
    public class Utility
    {

        public static User CurrentUser
        {
            get
            {
                // Session ends but user still loged in
                if (HttpContext.Current.Session["User"] == null && HttpContext.Current.User.Identity.IsAuthenticated)
                {
                    FormsAuthentication.SignOut();
                    return new User();
                }

                return (User)HttpContext.Current.Session["User"];
            }
            set { HttpContext.Current.Session["User"] = value; }
        }


    }
}