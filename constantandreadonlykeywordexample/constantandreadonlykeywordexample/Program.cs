using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConstantAndReadOnlyKeyword
{
    class Program
    {
        public const int a = 20;
        readonly int b = 30;
        int c = 10;

        public Program(int n)
        {
            b = n;
        }

        static void Main(string[] args)
        {
            Program P = new Program(30);

            Console.WriteLine(P.b);
            P.c = 100;

            Console.ReadKey();
        }
    }
}
