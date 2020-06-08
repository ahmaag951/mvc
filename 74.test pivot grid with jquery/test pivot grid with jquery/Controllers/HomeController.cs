using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace test_pivot_grid_with_jquery.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult GetJsonDataCustomers()
        {
            var data = new List<Question>
            {
                //new Question{ QuestionName = "QuestionID", Answer = "1"},
                //new Question{ QuestionName = "QuestionID", Answer = "2"},
                //new Question{ QuestionName = "QuestionID", Answer = "3"},
                //new Question{ QuestionName = "QuestionID", Answer = "4"},
                //new Question{ QuestionName = "QuestionID", Answer = "5"},
                //new Question{ QuestionName = "QuestionID", Answer = "6"},
                //new Question{ QuestionName = "QuestionID", Answer = "7"},
                //new Question{ QuestionName = "QuestionID", Answer = "8"},
                //new Question{ QuestionName = "QuestionID", Answer = "9"},

                new Question{ QuestionName = "Age", Answer = "30", QuestionID = "1"},
                new Question{ QuestionName = "Age", Answer = "30", QuestionID = "2"},
                new Question{ QuestionName = "Age", Answer = "11", QuestionID = "3"},

                new Question{ QuestionName = "City", Answer = "Cairo", QuestionID = "4"},
                new Question{ QuestionName = "City", Answer = "Cairo", QuestionID = "5"},
                new Question{ QuestionName = "City", Answer = "Alex", QuestionID = "6"},

                new Question{ QuestionName = "Gender", Answer = "true", QuestionID = "7"},
                new Question{ QuestionName = "Gender", Answer = "true", QuestionID = "8"},
                new Question{ QuestionName = "Gender", Answer = "false", QuestionID = "9"},



                //new Question{ QuestionID="1", City= "Cairo", Age="30", Gender = "true" },
                //new Question{ QuestionID="2", City= "Cairo", Age="30", Gender = "true" },
                //new Question{ QuestionID="3", City= "Alex", Age="11", Gender = "false" },
            };

            
                var columnsNames = data.Select(r => r.QuestionName).Distinct().ToList();

                List<List<string>> list = new List<List<string>>();
                foreach (var item in columnsNames)
                {
                    list.Add(data.Where(r => r.QuestionName == item).Select(r => r.Answer).ToList());
                }

                var model = new ExpandoObject() as IDictionary<string, Object>;

                //var modelsList = new List<dynamic>();

                for (int i = 0; i < columnsNames.Count; i++)
                {
                    
                    model.Add(columnsNames[i], list[i]);

                }
                
            return Json(data, JsonRequestBehavior.AllowGet);
        }
    }

    //public class Question
    //{
    //    public string QuestionID { get; set; }
    //    public string City { get; set; }
    //    public string Age { get; set; }
    //    public string Gender { get; set; }
    //}
    public class Question
    {
        public string QuestionID { get; set; }
        public string QuestionName { get; set; }
        public string Answer { get; set; }
    }
}