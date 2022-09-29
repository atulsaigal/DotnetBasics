using System;

namespace ClassStructure
{

    struct struct_Encapsulation
    {
        public int a;
    }

    class cls_Encapsulation
    {
        public int a;

        public cls_Encapsulation()
        {

        }
    }




    class Program
    {
        static void Main(string[] args)
        {
            struct_Encapsulation cst1 = new struct_Encapsulation();

            struct_Encapsulation cst2 = new struct_Encapsulation();

            struct_Encapsulation cst3 = new struct_Encapsulation();

            struct_Encapsulation cst4 = new struct_Encapsulation();

            struct_Encapsulation cst5 = new struct_Encapsulation();

            cst1.a = 10;

            cst2.a = 15;
            cst3.a = 20;
            cst4.a = 30;
            cst5.a = 40;


            Console.WriteLine("cst1.a:" + cst1.a);

            Console.WriteLine("cst2.a:" + cst2.a);

            Console.WriteLine("cst3.a:" + cst3.a);

            Console.WriteLine("cst4.a:" + cst4.a);

            Console.WriteLine("cst5.a:" + cst5.a);


            cls_Encapsulation clobj1= new cls_Encapsulation();//10
            cls_Encapsulation clobj2 = new cls_Encapsulation();//20
            cls_Encapsulation clobj3 = clobj2;//20
            cls_Encapsulation clobj4 = clobj1;//30
            cls_Encapsulation clobj5 = new cls_Encapsulation();

            clobj1.a= 10;

            clobj2.a= 15;   

            clobj3.a= 20;

            clobj4.a= 30;

            clobj5.a = 50;

            Console.WriteLine("clobj1.a:" + clobj1.a);

            Console.WriteLine("clobj2.a:" + clobj2.a);

            Console.WriteLine("clobj3.a:" + clobj3.a);

            Console.WriteLine("clobj4.a:" + clobj4.a);

            Console.WriteLine("clobj5.a:" + clobj5.a);

            Console.ReadKey();

        }
    }
}
