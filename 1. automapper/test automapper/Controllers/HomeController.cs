using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace test_automapper.Controllers
{
    public class HomeController : Controller
    {

        public string Index()
        {
            User user = new User { Id = 1, Name = "Ahmad", FakeName="The fake name" };

            UserModel userModel = AutoMapper.Mapper.Map<User, UserModel>(user);

            // This will return the fake name 
            // Because I make that custom in the global.asx file
            return userModel.Name;
        }

    }
}
