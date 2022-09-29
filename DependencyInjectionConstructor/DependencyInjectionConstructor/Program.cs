using System;

namespace DependencyInjectionConstructor
{
    public interface I1
    {
        void Demo();
    }


    class child1 : I1
    {

        public void Demo()
        {
            Console.WriteLine("Demo Function Called of Child1 Class - Constructor Injection.");
        }
    }

    class child2 : I1
    {
        public void Demo()
        {
            Console.WriteLine("Demo Function Called of Child2 Class - Constructor Injection.");
        }
    }


    public class ConstructorInjection
    {
        private I1 _i1;

        public ConstructorInjection(I1 _i1)
        {
            this._i1 = _i1;
        }
        public void Demo()
        {
            _i1.Demo();
        }
    }




    internal class Program
    {
    static void Main(string[] args)
    {
        ConstructorInjection cs = null;

        cs = new ConstructorInjection(new child1());

        cs.Demo();

    }

    }
}
