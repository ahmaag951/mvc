using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace check_box_list.Models
{
    public class HomeModel
    {
        public List<string> SelectedFruits { get; set; }
        public List<SelectListItem> AvailbleFruits { get; set; } 
    }
}