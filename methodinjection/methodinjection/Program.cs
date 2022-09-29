using System;

namespace methodinjection
{
    public interface I3
    {
        void demo3();
    }

    public class serviceclass : I3
    {
        public void demo3()
        {
            Console.WriteLine("serviceclass");

        }
    }

    public class clientclass : I3
    {

        private I3 _i3;

        public void Demo(I3 _i3)
        {
            this._i3 = _i3;
            Console.WriteLine("Client Class Method Statement Called.");
            this._i3.demo3();

        }

        public void demo3()
        {

        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            clientclass cs = new clientclass();
            cs.Demo(new clientclass());
        } 


    }
}
