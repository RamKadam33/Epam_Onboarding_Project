using System;
using System.Collections;
using System.Collections.Generic;
namespace TestProject1
{
    public class CustomCollection<T> : IEnumerable<T>
    {
        private List<T> items = new List<T>();

        public void Add(T item)
        {
            items.Add(item);
        }

        public IEnumerator<T> GetEnumerator()
        {
            foreach (var item in items)
            {
                yield return item;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }

    partial class CollectionTask
    {
        [Test]
        public void CustomeCollection()
        {
            CustomCollection<string> myCollection = new CustomCollection<string>();

            myCollection.Add("Apple");
            myCollection.Add("Banana");
            myCollection.Add("Cherry");

            foreach (var item in myCollection)
            {
                Console.WriteLine(item);
            }
        }
    }
}
