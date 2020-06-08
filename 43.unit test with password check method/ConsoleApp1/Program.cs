using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Program
    {
        static void Main(string[] args)
        {


            Console.WriteLine(CheckPassword("P@ssw0rd22"));
            Console.Read();
        }

        public static bool CheckPassword(string password)
        {
            /*  ^(?=(.*\d){2})(?=.*[a-z])(?=.*[A-Z])(?=.*[^a-zA-Z\d]).{8,}$
             two digits anywhere
             an upper-lower case letter
             there is anything except letter or digit
             8 or more characters */

            string pat = @"^(?=(.*\d){2})(?=.*[a-z])(?=.*[A-Z])(?=.*[^a-zA-Z\d]).{8,}$";
            Regex r = new Regex(pat);

            return r.Match(password).Success;
        }
    }
}
