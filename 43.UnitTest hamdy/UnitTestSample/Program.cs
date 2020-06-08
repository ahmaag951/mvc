using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestSample
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Sum(3, 4));
            Console.ReadKey();
        }

        public static int Sum(int FirstNumber, int SecondNumber)
        {
            int sum = FirstNumber + SecondNumber;

            // Just to make test case to fail.
            if (FirstNumber < 0)
            {
                sum++;
            }

            return sum;
        }
    }
}
