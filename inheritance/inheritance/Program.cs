using System;


namespace inheritancewithdatahiding
{
   public class datahidingwithinternaldemocls
    {
        public int r;
       
    }


}

namespace inheritance
{

    class parent
    {
        public int p;
        private int m;
        protected int q;
        internal int x;

        public void demoinheritanceprivate()
        {
            m=100;
        }




    }

    class child:parent
    {
        public void demoinheritanceprotected()
        {
            q = 20;
        }
    }





    public class Program
    {
        static void Main(string[] args)
        {
            child c =new child();
            c.demoinheritanceprivate();

            parent p=new parent();
            p.demoinheritanceprivate();

            inheritancewithdatahiding.datahidingwithinternaldemocls democls = new inheritancewithdatahiding.datahidingwithinternaldemocls();
           
            democls.r = 1000;

            Console.WriteLine(democls.r);
            
        }
    }
}
