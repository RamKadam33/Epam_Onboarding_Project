using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject1
{
    partial class CollectionTask
    {
        [Test]
        public void ListArrayListDic_Task1() {

            // List<T> - Generic List (Type-Safe)
            List<int> numberList = new List<int> { 10, 20, 30, 40 };
            numberList.Add(50);
            numberList.Remove(20);

            Console.WriteLine("List<T> Example:");
            foreach (int num in numberList)
            {
                Console.WriteLine(num);
            }

            // ArrayList - Non-Generic Collection (Stores Any Type)
            ArrayList arrayList = new ArrayList();
            arrayList.Add(100);
            arrayList.Add("Hello");
            arrayList.Add(200.5);

            Console.WriteLine("\nArrayList Example:");
            foreach (var item in arrayList)
            {
                Console.WriteLine(item);
            }

            // Dictionary<TKey, TValue> - Key-Value Collection
            Dictionary<int, string> dictionary = new Dictionary<int, string>();
            dictionary.Add(1, "Apple");
            dictionary.Add(2, "Banana");
            dictionary.Add(3, "Cherry");

            Console.WriteLine("\nDictionary Example:");
            foreach (KeyValuePair<int, string> kvp in dictionary)
            {
                Console.WriteLine($"Key: {kvp.Key}, Value: {kvp.Value}");
            }
        

        }


    }
}
