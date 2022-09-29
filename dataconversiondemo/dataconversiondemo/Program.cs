using System;

namespace dataconversiondemo
{ 
     class Program
    {
        public int i = 10;

        public float f = 10.0000f;

        public double d = 10.3333333;

        public decimal dc = 10.222222222222222m;

        public string s = "Atul";

        public object o = 1234;

        static void Main(string[] args)
        
        
        
        {

            Program P =new Program();
            Console.WriteLine("Integer i:" + P.i);
            Console.WriteLine("float f:" + P.f);
            Console.WriteLine("double d:" + P.d);
            Console.WriteLine("decimal dc:" + P.dc);

            int i1 = (int)P.f;
            Console.WriteLine("Converted Integer i1:" + i1);

           
            float f1 = (float)P.i;
            Console.WriteLine("Converted float f1:" + f1);

            
            var v = (int)P.i;
            Console.WriteLine("Converted Implicit Variable v:" + v);

            //Parsing - No Null Value Conversion. Only Numeric Conversion.
            Console.WriteLine("String STR:" + P.s);
            Console.WriteLine("Converted Integer From String:" + Int32.Parse(P.s));

            //Convert - Null Value Converted To ZERO. Also Numeric Conversion.
            Console.WriteLine("Converted Integer From String:" + Convert.ToInt32(P.s));

            //Convert can change null to 0 but parse cant change null.
            P.s = null;
            Console.WriteLine("Converted Integer From String:" + Convert.ToInt32(P.s));

            //TryParse
            P.s = "111";
            int i;
            bool b = Int32.TryParse(P.s, out i);
            Console.WriteLine("Converted Integer From String Is Possible:" + b);
            Console.WriteLine("Converted Integer From String:" + i);

            Object Obj2 = (string)P.s;
            Console.WriteLine("Converted Object From String:" + Obj2);

            Console.WriteLine("Converted String From Object:" + Convert.ToString(P.o));


            // Boxing - Unboxing.
            int i2;
            bool b2 = Int32.TryParse((string)P.s, out i2);


            Console.ReadKey();


        }
    }
}
