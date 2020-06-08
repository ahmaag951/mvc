using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test_automated_code_test
{
    public class Class1
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName {
            get {
                return FirstName + ", " + LastName;
            }        
        }

    }
}
