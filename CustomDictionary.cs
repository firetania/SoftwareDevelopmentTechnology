using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3
{
    public class CustomDictionary<TKey, TValue>: ICollection<KeyValuePair<TKey, TValue>>, IEnumerable<KeyValuePair<TKey, TValue>>, IEnumerable
    {
        private int size;
        private int count;
        private LinkedList<KeyValuePair<TKey, TValue>>[] items;
        public ICollection<TKey> keys;
        public ICollection<TValue> values;
        public int Size 
        {
            get 
            {
                return size;
            } 
        }
        public LinkedList<KeyValuePair<TKey, TValue>>[] Items
        {
            get
            {
                return items;
            }
        }

        public bool IsReadOnly
        {
            get
            {
                return false;
            }
        }
        public int Count
        {
            get
            {
                return count;
            }
        }
        public ICollection<TKey> Keys
        {
            get
            {
                return keys;
            }
        }
        public ICollection<TValue> Values
        {
            get
            {
                return values;
            }
        }
        public CustomDictionary()
        {
            size = 4;
            count = 0;
            items = new LinkedList<KeyValuePair<TKey, TValue>>[size];
            for (int i = 0; i < items.Length; i++)
            {
                items[i] = new LinkedList<KeyValuePair<TKey, TValue>>();
            }
            keys = new List<TKey>();
            values = new List<TValue>();
        }

        public CustomDictionary(int size_)
        {
            this.size = size_;
            count = 0;
            items = new LinkedList<KeyValuePair<TKey, TValue>>[size];
            for (int i = 0; i < items.Length; i++)
            {
                items[i] = new LinkedList<KeyValuePair<TKey, TValue>>();
            }
            keys = new List<TKey>();
            values = new List<TValue>();
        }

        public TValue this[TKey key]
        {
            get
            {
                int hash = Math.Abs(key.GetHashCode()) % items.Length;

                if (keys.Contains(key))
                {

                    foreach (var item in items[hash])
                    {
                        if (key.Equals(item.Key))
                        {
                            return item.Value;
                        }
                    }
                    return default;
                }
                else
                {
                    throw new KeyNotFoundException($"No key {key} in the table");
                }
            }
            set
            {
                int hash = Math.Abs(key.GetHashCode()) % items.Length;
                KeyValuePair<TKey, TValue> newItem = new KeyValuePair<TKey, TValue>(key, value);
                if (keys.Contains(key))
                {
                    
                    foreach (var item in items[hash])
                    {
                        if (key.Equals(item.Key))
                        {
                            items[hash].Remove(item);
                            items[hash].AddLast(newItem);
                            break;
                        }
                    }
                }
                else 
                {
                    Add(newItem);
                }
            }
        }

        public void Add(KeyValuePair<TKey, TValue> newItem)
        {
            var hash = Math.Abs(newItem.Key.GetHashCode()) % items.Length;
            
            foreach(var element in items[hash])
            {
                if (element.Key.Equals(newItem.Key))
                {
                    throw new ArgumentOutOfRangeException("An element with the same key has already been added.");
                }
            }

            count++;
            items[hash].AddLast(newItem);
            keys.Add(newItem.Key);
            values.Add(newItem.Value);
        }

        public bool Remove(KeyValuePair<TKey, TValue> existingItem)
        {
            var hash = Math.Abs(existingItem.Key.GetHashCode()) % items.Length;
            foreach (var item in items[hash])
            {
                if (existingItem.Key.Equals(item.Key))
                {
                    items[hash].Remove(existingItem);
                    count--;
                    keys.Remove(existingItem.Key);
                    values.Remove(existingItem.Value);
                    return true;
                }
            }
            return false;
        }
        public void Clear()
        {
            items = new LinkedList<KeyValuePair<TKey, TValue>>[size];
            for (int i = 0; i < items.Length; i++)
            {
                items[i] = new LinkedList<KeyValuePair<TKey, TValue>>();
            }
            keys.Clear();
            values.Clear();
            count = 0;
        }
        public bool Contains(KeyValuePair<TKey, TValue> itemToFind)
        {
            var hash = Math.Abs(itemToFind.Key.GetHashCode()) % items.Length;
            if (items[hash].Contains(itemToFind))
            {
                return true;
            }
            return false;
        }
        public bool ContainsKey(TKey keyToFind)
        {
            return keys.Contains(keyToFind);
        }
        public void CopyTo(KeyValuePair<TKey, TValue>[] array, int arrayIndex)
        {
            if (arrayIndex < 0)
                throw new ArgumentOutOfRangeException("arrayIndex < 0");

            if (array == null)
                throw new ArgumentNullException("No elements in array");

            if (count > array.Length - arrayIndex - 1)
                throw new ArgumentException("Not enough space in array");
            
            for (int index = arrayIndex; index < size; ++index)
            {
                int curID = 0;
                foreach (KeyValuePair<TKey, TValue> curItem in items[index])
                {
                    array[curID] = curItem;
                    curID++;
                }
            }
        }
        public void Show()
        {
            foreach(LinkedList<KeyValuePair<TKey, TValue>> curLst in items)
            {
                if (curLst.Count() > 0)
                {
                    foreach (KeyValuePair<TKey, TValue> kvp in curLst)
                    {
                        Console.WriteLine("Key = {0}, Value = {1} ", kvp.Key, kvp.Value);
                    }
                    Console.WriteLine();
                }
            }
        }

        public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator()
        {
            foreach (LinkedList<KeyValuePair<TKey, TValue>> curLst in items)
            {
                foreach (KeyValuePair<TKey, TValue> kvp in curLst)
                {
                    yield return kvp;
                }
            }
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
