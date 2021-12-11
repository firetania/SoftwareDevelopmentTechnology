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
            KeyValuePair<string, int> third = new KeyValuePair<string, int>("Sidorov", 3);
            obj.Add(first);
            obj.Add(second);
            obj.Add(third);
            Console.WriteLine("Add first, second, third");
            obj.Show();

            obj.Remove(third);
            Console.WriteLine("Remove third");
            obj.Show();

            var objCount = obj.Count;
            Console.WriteLine("Count = {0}", objCount);

            var isItemIvanov5 = obj.Contains(first);
            Console.WriteLine("Contains Ivanov 5 = {0}", isItemIvanov5);

            var isKeyIvanov = obj.ContainsKey("Ivanov");
            Console.WriteLine("Contains Ivanov = {0}", isKeyIvanov);

            obj.Clear();
            Console.WriteLine("Clear");
            obj.Show();

            KeyValuePair<string, int>[] array = new KeyValuePair<string, int>[3];
            obj.CopyTo(array, 1);
            KeyValuePair<string, int> example = new KeyValuePair<string, int>("Sokolov", 2);
            array[2] = example;
            Console.WriteLine("Copyto");
            foreach (var element in array)
                Console.WriteLine("Key = {0}, Value = {1}", element.Key, element.Value);
        }
    }
}
