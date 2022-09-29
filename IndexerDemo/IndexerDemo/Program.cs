using System;

namespace IndexerDemo
{

    class DataStore<t>
    {
        private t[] store;
        public DataStore()
        {
            store = new t[10];
        }

        public DataStore(int length)
        {
            store = new t[length];
        }
        public t this[int index]
        {
            get
            {
                if (index < 0 && index >= store.Length)
                    throw new IndexOutOfRangeException("Index out of range");

                return store[index];
            }

            set
            {
                if (index < 0 || index >= store.Length)
                    throw new IndexOutOfRangeException("Index out of range");

                store[index] = value;
            }
        }


        public int length
        {
            get { return store.Length; }
        }
    }

    class DataStore2<type>
    {
        private type[] arrtype;

        public DataStore2()
        {
            arrtype = new type[10];
        }

        public DataStore2(int length)
        {
            arrtype = new type[length];
        }

        public type this[int index]
        {
            get
            {
                if (index < 0 && index >= arrtype.Length)
                    throw new IndexOutOfRangeException("Index out of range");

                return arrtype[index];
            }
            set
            {
                if (index < 0 && index >= arrtype.Length)
                    throw new IndexOutOfRangeException("Index out of range");

                arrtype[index] = value;
                    ;

            }
        }
        public int Length
        {
            get
            {
                return arrtype.Length;
            }
        }


    }

    








    internal class Program
    {
        static void Main(string[] args)
        {

            DataStore<int> grades = new DataStore<int>();
            grades[0] = 20;
            grades[1] = 25;
            grades[2] = 30;
            grades[3] = 35;
            grades[4] = 40;
            grades[5] = 45;
            grades[6] = 50;
            grades[7] = 55;
            grades[8] = 60;
            grades[9] = 65;

            for (int i = 0; i < grades.length; i++)
                Console.WriteLine(grades[i]);

            DataStore<string> names = new DataStore<string>(5);
            names[0] = "Atul";
            names[1] = "shlok";
            names[2] = "ulka";
            names[3] = "rudra";
            names[4] = "Abhishek";

            for (int i = 0; i < names.length; i++)
                Console.WriteLine(names[i]);


            DataStore2<float> FloatDemo = new DataStore2<float>(3);
            FloatDemo[0] = 10.10f;
            FloatDemo[1] = 20.20f;
            FloatDemo[2] = 30.30f;

            for (int i = 0; i < FloatDemo.Length; i++)
                Console.WriteLine(FloatDemo[i]);

            DataStore2<bool> BoolDemo = new DataStore2<bool>(4);
            BoolDemo[0] = true;
            BoolDemo[1] = false;
            BoolDemo[2] = true;
            BoolDemo[3] = true;

            for (int i = 0; i < BoolDemo.Length; i++)
                Console.WriteLine(BoolDemo[i]);


            Console.ReadKey();

        }
    }
}
