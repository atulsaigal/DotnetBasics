using System;

namespace polymorphism
{

    class OverloadingDemoCLS
    {
        public void demo()
        {
            Console.WriteLine("No Return Type, No Parameters.");
        }
        public void demo(int a)
        {
            Console.WriteLine("No Return Type, One Int Parameter.");
        }
        public void demo(string a)
        {
            Console.WriteLine("No Return Type, One String Parameter.");
        }
        public void demo(string a, int b)
        {
            Console.WriteLine("No Return Type, One String Parameter & One Int Parameter.");
        }

    }






    class Program
    {
        static void Main(string[] args)
        {

            OverloadingDemoCLS demo  = new OverloadingDemoCLS();

            demo.demo("atul");

            demo.demo(20);

            Console.WriteLine("Hello World!");
        }
    }
}
