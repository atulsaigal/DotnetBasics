using System;

namespace interfacedemo
{

    interface Idemo1
    {
        void DemoAbs1();

        void DemoAbs2();
        void DemoAbs3();
        void DemoAbs4();

    }

    interface Idemo2
    { 
        void DemoAbs1();

        void DemoAbs2();
        void DemoAbs3();
        void DemoAbs4();

    }

    class ChildCls : Idemo1, Idemo2
    {
        void Idemo1.DemoAbs1()
        {
            Console.WriteLine("Idemo1.DemoAbs1() Method Called.");
        }

         void Idemo1.DemoAbs2()
        {
            Console.WriteLine("Idemo1.DemoAbs2() Method Called.");
        }

         void Idemo1.DemoAbs3()
        {
            Console.WriteLine("Idemo1.DemoAbs3() Method Called.");
        }

         void Idemo1.DemoAbs4()
        {
            Console.WriteLine("Idemo1.DemoAbs4() Method Called.");
        }

        void Idemo2.DemoAbs1()
        {
            Console.WriteLine("Idemo2.DemoAbs1() Method Called.");
        }

        void Idemo2.DemoAbs2()
        {
            Console.WriteLine("Idemo2.DemoAbs2() Method Called.");
        }

        void Idemo2.DemoAbs3()
        {
            Console.WriteLine("Idemo2.DemoAbs3() Method Called.");
        }

        void Idemo2.DemoAbs4()
        {
            Console.WriteLine("Idemo2.DemoAbs4() Method Called.");
        }


    }






    internal class Program
    {
        static void Main(string[] args)
        {
           Idemo1 I1 = new ChildCls();
            I1.DemoAbs1();
            I1.DemoAbs2();
                
            I1.DemoAbs3();
            I1.DemoAbs4();

            Idemo2 I2 = new ChildCls();
            I2.DemoAbs1();
            I2.DemoAbs2();
            I2.DemoAbs3();
            I2.DemoAbs4();

            Console.ReadKey();

        }
    }
}
