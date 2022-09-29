using System;
using System.Collections.Generic;

using System.Linq;
using System.Text;
using System.Collections;

namespace CollectionAndNonCollectionGenerics
{
     class Program
    {
        static void Main(string[] args)
        {
              
            ArrayList arrylist = new ArrayList();
            Queue q = new Queue();  
            Stack S = new Stack();


            arrylist.Add("Atul Saigal");
            arrylist.Add(20);

            foreach (Object o in arrylist)
            {
                Console.WriteLine(o);
            }

            q.Enqueue("akshay");
            q.Enqueue("9");

            foreach (Object o in q)
            {
                Console.WriteLine(o);
            }

            S.Push("Rajendra");
            S.Push(19);



            foreach (Object o in S)
            {
                Console.WriteLine(o);
            }

            List<string> list = new List<string>();
            list.Add("Atul Saigal");
            list.Add("Akshay Saigal");

            foreach (string s  in list)
            {
                Console.WriteLine(s);
            }

            Console.ReadKey();


        }
    }
}