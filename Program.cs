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
            obj.Show();
        }
    }
}
