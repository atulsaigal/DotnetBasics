using System;

namespace DependencyInjectionProperty
{
    public interface I2
    {
        void demopropertyinjection(string msg);
        
    }

    class LogwriterClass : I2
    {
        public void demopropertyinjection(string msg)
        {
            Console.WriteLine();
        }

      

    }

    class LogwriterClass2 : I2
    {
        public void demopropertyinjection(string msg)
        {
            Console.WriteLine();
        }



    }

    class PropertyInjectionClass
    {
        I2 _i2 = null;
        public void demopropertyinjectionFunctionOfClass(I2 _i2, string msg)
        {
            this._i2 = _i2;
            _i2.demopropertyinjection(string msg);
        }
    }


    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
}
