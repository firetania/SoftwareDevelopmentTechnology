using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3
{
    public class CustomDictionary<TKey, TValue>//: ICollection<KeyValuePair<TKey, TValue>>, IEnumerable<KeyValuePair<TKey, TValue>>, IEnumerable
    {
        private int size;
        public int Size 
        {
            get 
            {
                return size;
            } 
        }
        private LinkedList<KeyValuePair<TKey, TValue>>[] items;
        public LinkedList<KeyValuePair<TKey, TValue>>[] Items
        {
            get
            {
                return items;
            }
        }

        public CustomDictionary()
        {
            size = 255;  // ?
            items = new LinkedList<KeyValuePair<TKey, TValue>>[size];
        }

        public CustomDictionary(int size_)
        {
            this.size = size_;
            items = new LinkedList<KeyValuePair<TKey, TValue>>[size];
        }

        public void Insert(KeyValuePair<TKey, TValue> newItem)
        {
            var hash = newItem.Key.GetHashCode() % size;
            size++;
            if (items[hash] == null)
            {
                items[hash] = new LinkedList<KeyValuePair<TKey, TValue>>();
                items[hash].AddLast(newItem);
            }
            else
            {
                items[hash].AddLast(newItem);
            }
        }

        public void Remove(KeyValuePair<TKey, TValue> existingItem)
        {
            var hash = existingItem.Key.GetHashCode() % size;
            items[hash].Remove(existingItem);
        }
        public void Clear()
        {
            size = 0;
            items = new LinkedList<KeyValuePair<TKey, TValue>>[size];
        }
        public bool Contains(KeyValuePair<TKey, TValue> itemToFind)
        {
            var hash = itemToFind.Key.GetHashCode() % size;
            if (items[hash].Contains(itemToFind))
            {
                return true;
            }
            return false;
        }
        public void Show()
        {
            foreach(LinkedList<KeyValuePair<TKey, TValue>> curLst in items)
            {
                foreach (KeyValuePair<TKey, TValue> kvp in curLst)
                {
                    Console.WriteLine("Key = {0}, Value = {1} ", kvp.Key, kvp.Value);
                }
                Console.WriteLine();
            }
        }
    }
}
