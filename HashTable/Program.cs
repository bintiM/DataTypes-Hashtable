using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace HashTable
{
    class Program
    {
        static void Main(string[] args)
        {
            
            
            int max = 5000000;

            int search = max/2;

            Stopwatch stopWatch = new Stopwatch();

            Hashtable h = new Hashtable(max);

            randomPerson[] a = new randomPerson[max];

            for (int i = 0; i < max; i++)
            {
                a[i] = new randomPerson();
            }

            for (int i = 0; i < max; i++)
            {
                h.Add(a[i].fullname, i);
            }

            

            string searchname = a[search].fullname;

            Console.WriteLine("Hashtable element Nr. " + h[searchname] + " (Name: " + searchname + ")");
            Console.WriteLine("Array element Nr. " + search + " (Name: " + searchname + ")");

            stopWatch.Start();
            int foundHashTableValue = (int) h[searchname];
            stopWatch.Stop();

            Console.WriteLine("Hashtable fand: "+ foundHashTableValue +" dauerte: \t\t" + stopWatch.Elapsed);

            int foundArrayValue = 0;
            stopWatch.Restart();
            for (int i = 0; i < max; i++)
            {
                if (a[i].fullname == searchname)
                {
                    foundArrayValue = i;
                    break;
                }
            }
            stopWatch.Stop();

            Console.WriteLine("Array fand: " + foundArrayValue + " dauerte: \t\t" + stopWatch.Elapsed);


        }

    }

    class randomPerson
    {
        public string prename;
        public string surname;

        public randomPerson()
        {
            prename = RandomString(4);
            surname = RandomString(8);            
        }

        public string fullname
        {
            get { return prename + " " + surname; }
        }

        private static Random random = new Random();
        public static string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }
}
