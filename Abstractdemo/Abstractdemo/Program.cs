using System;

namespace Abstractdemo
{
    abstract class AbsCLSDemo
    {
        public abstract void DemoAbsFun1();

        public abstract void DemoAbsFun2();
        public abstract void DemoAbsFun3();

        public void DemoNormalFun()
        {
            Console.WriteLine("normal function of abstract class is called");
        }
    }

    class ChildCLS : AbsCLSDemo
    {
        public override void DemoAbsFun1()
        {
            Console.WriteLine("normal function of abstract class1 is called");
        }

        public override void DemoAbsFun2()
        {
            Console.WriteLine("normal function of abstract class2 is called");
        }

        public override void DemoAbsFun3()
        {
            Console.WriteLine("normal function of abstract class3 is called");
        }
    }




     class Program
    {
        static void Main(string[] args)
        {
           ChildCLS c = new ChildCLS();
            c.DemoAbsFun1();
            c.DemoAbsFun2();
            c.DemoAbsFun3();
            c.DemoNormalFun();
            Console.ReadKey();
        }
    }
}
