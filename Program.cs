using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3
{
    class Program
    {
        static void Main()
        {
            CustomDictionary<string, int> obj = new CustomDictionary<string, int>();
            KeyValuePair<string, int> first = new KeyValuePair<string, int>("Ivanov", 5);
            KeyValuePair<string, int> second = new KeyValuePair<string, int>("Petrov", 4);
            obj.Insert(first);
            //obj.Show();
            foreach (LinkedList<KeyValuePair<string, int>> curLst in obj.Items)
            {
                foreach (KeyValuePair<string, int> kvp in curLst)
                {
                    Console.WriteLine("Key = {0}, Value = {1} ", kvp.Key, kvp.Value);
                }
                Console.WriteLine();
            }
        }
    }
}
