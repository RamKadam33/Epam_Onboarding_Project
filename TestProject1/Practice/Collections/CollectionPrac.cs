using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace TestProject1.Practice.Collections
{
    class CollectionPrac
    {
        [Test]
        public  void llist()
        {
            // default constructor creates an empty list
            List<int> list = new List<int>();
            list.Add(30);
            list.Add(10);
            list.Add(20);
            Console.WriteLine("Default Constructor: ");
            foreach (var item in list)
            {
                Console.WriteLine(item);
            }

            // Construnctors from IEnumerable
            int[] num = { 10, 20 };
            List<int> enumerableList = new List<int>(num);
            Console.WriteLine("Constructor with IEnumerable: ");
            foreach (var item in enumerableList)
            {
                Console.WriteLine(item);
            }

            // Constructor with Initial Capacity 
            List<int> Clist = new List<int>(2);
            Clist.Add(10);
            Clist.Add(20);
            Console.WriteLine("Constructor with Initial Capacity: ");
            foreach (var item in Clist)
            {
                Console.WriteLine(item);
            }

            //Sorting
            List<int> l = new List<int>();

            // Adding elements to List
            l.Add(2);
            l.Add(1);
            l.Add(5);
            l.Add(3);
            l.Add(50);

            // Without sorted List
            Console.WriteLine("UnSorted List:");

            foreach (int a in l) Console.Write(a + ", ");
            Console.WriteLine();

            // using sort method
            l.Sort();

            Console.WriteLine("Sorted List:");
            foreach (int a in l) Console.Write(a + ", ");


        }
        [Test]
        public void SortedList()//like sorted dictionary key should be uniuqe 
        {    //generic
            // Creating a SortedList
            SortedList<int, string> slg = new SortedList<int, string>();

            // Adding key-value pairs
            slg.Add(3, "Three");
            slg.Add(1, "One");
            slg.Add(2, "Two");
            slg.Add(4, "Two");

            // Displaying elements in sorted by key
            foreach (var item in slg)
            {
                Console.WriteLine($"Key: {item.Key}, Value: {item.Value}");
            }

            // Non-generic
            // Using SortedList class
            SortedList sl = new SortedList();

            // Adding key-value pairs in 
            // SortedList using Add() method
            sl.Add(1.02, "This");
            sl.Add(1.07, "Is");
            sl.Add(1.04, "SortedList");
            
            foreach (DictionaryEntry pair in sl)
            {
                Console.WriteLine("{0} and {1}",
                pair.Key, pair.Value);
            }
            Console.WriteLine();

            // Creating another SortedList
            // using Object Initializer Syntax
            // to initialize sortedlist
            SortedList my_slist2 = new SortedList()
            {
                                { "b.09", 234 },
                                { "b.11", 395 },
                                { "b.01", 405 },
                                { "b.67", 100 }};
            foreach (DictionaryEntry pair in my_slist2)     //way to call
            {
                Console.WriteLine("{0} and {1}",
                pair.Key, pair.Value);
            }
        }
        [Test]
        public void hashset() // like list but unique and unordered
        {
            // Create a HashSet 
            HashSet<int> hs = new HashSet<int> {1,6,3,5 };

            // Add elements to the HashSet
            hs.Add(20);
            hs.Add(10);
            hs.Add(30);
            hs.Add(10);

            // Display elements in the HashSet
            Console.WriteLine("Elements in the HashSet: ");
            foreach (int number in hs)
                Console.WriteLine(number);

            HashSet<string> set1 = new HashSet<string>();

            // Add the elements in HashSet
            // Using Add method
            set1.Add("C");
            set1.Add("C++");
            set1.Add("C#");
            set1.Add("Java");
            set1.Add("Ruby");
            Console.WriteLine("Elements of set1:");

            // Accessing elements of HashSet
            // Using foreach loop
            foreach (var val in set1)
            {
                Console.WriteLine(val);
            }

            // Creating another HashSet
            // using collection initializer
            // to initialize HashSet
            HashSet<int> set2 = new HashSet<int>() { 1, 2, 3 };

            // Display elements of set2
            Console.WriteLine("Elements of set2:");
            foreach (var value in set2)
            {
                Console.WriteLine(value);
            }

            Console.WriteLine("Elements (Before Removal): "+ set1.Count);
            // Remove an element
            set1.Remove("C++");
            // After removal
            Console.WriteLine("Elements (After Removal): "+ set1.Count);


            HashSet<int> sset1 = new HashSet<int> { 1, 2, 3, 5 };
            HashSet<int> sset2 = new HashSet<int> { 3, 4, 5 };

            // Union of two sets
            sset1.UnionWith(sset2);
            Console.WriteLine("After Union: "+ string.Join(", ", sset1));

            // Intersection of two sets
            sset1.IntersectWith(sset2);
            Console.WriteLine("After Intersection: " + string.Join(", ", sset1));
            sset1.IntersectWith(new HashSet<int> { 3, 5 });
            Console.WriteLine("After Intersection: "+ string.Join(", ", sset1));

            // Difference of sets
            sset1.ExceptWith(new HashSet<int> { 5 });
            Console.WriteLine("After Difference: "+ string.Join(", ", sset1));

        }
        [Test]
        public void sortedset() //like ordered hashset
        {
            SortedSet<int> num = new SortedSet<int> { 7, 1, 2, 8, 1, 4 };
            // Adding elements
            num.Add(6);
            // Adding duplicate (will not be added)
            num.Add(2);
            //Displaying elements
            Console.WriteLine("SortedSet elements:");
            foreach (int ele in num)
                Console.Write(ele + " ");
            Console.WriteLine("Accessing using foreach loop:");
            foreach (int ele in num)
                Console.Write(ele + " ");
            //Accessing elements using ForEach loop
            Console.WriteLine("Accessing using ForEach loop:");
            num.ToList().ForEach(ele => Console.Write(ele + " "));




            SortedSet<int> set = new SortedSet<int>();
            // Add the elements in SortedSet
            // Using Add method
            set.Add(1);
            set.Add(2);
            set.Add(3);
            set.Add(4);

            // After using Remove method
            Console.WriteLine("Total number of elements " +
                "present in set:{0}", set.Count);

            // Remove element from SortedSet
            // Using Remove method
            set.Remove(1);

            // Before using Remove method
            Console.WriteLine("Total number of elements " +
                "present in set:{0}", set.Count);

            // Remove all elements from SortedSet
            // Using Clear method
            set.Clear();
            Console.WriteLine("Total number of elements " +
                "present in set:{0}", set.Count);


            if (set.Contains(1))
                Console.WriteLine("Element is available.");

            else
                Console.WriteLine("Element is not available.");
        }
        [Test]
        public void Dictionary()
        {
            Dictionary<int, string> sub = new Dictionary<int, string>();

            // Adding elements
            sub.Add(1, "C#");
            sub.Add(2, "Javascript");
            sub.Add(3, "Dart");

            // Displaying dictionary
            foreach (var ele in sub)
            {
                Console.WriteLine($"Key: {ele.Key}, Value: {ele.Value}");
            }
            foreach (KeyValuePair<int, string> ele in sub)
            {
                Console.WriteLine("key: {0} and value: {1}", ele.Key, ele.Value);
            }
            sub.Remove(1);

            Console.WriteLine("\nAfter Remove() method:");
            foreach (KeyValuePair<int, string> ele in sub)
            {
                Console.WriteLine("key: {0}, Value: {1}", ele.Key, ele.Value);
            }

            // Using ContainsKey() to check if the key exists
            if (sub.ContainsKey(1))
                Console.WriteLine("Key is found...!!");
            else
                Console.WriteLine("Key is not found...!!");

            // Using ContainsValue() to check if the value exists
            if (sub.ContainsValue("to"))
                Console.WriteLine("Value is found...!!");
            else
                Console.WriteLine("Value is not found...!!");



            //similar in non-generic
            // Create a new Hashtable
            Hashtable ht = new Hashtable();

            // Add key-value pairs to the Hashtable
            ht.Add("One", 1);
            ht.Add("Two", 2);
            ht.Add("Three", 3);

            Console.WriteLine("Hashtable elements:");
            foreach (DictionaryEntry e in ht)
            {
                Console.WriteLine($"{e.Key}: {e.Value}");
            }
        }
        [Test]
        public void linkedlist()
        {

            // Creating a linked l of integers
            LinkedList<int> l = new LinkedList<int>();

            // Adding elements to the LinkedList using AddLast()
            l.AddLast(10);
            l.AddLast(20);
            l.AddLast(30);
            l.AddLast(40);
            l.AddLast(50);
            LinkedListNode<int> node = l.Find(50);


            Console.WriteLine("List of numbers:");

            // Accessing and displaying the elements using
            // foreach loop
            foreach (int num in l) { Console.WriteLine(num); }

            if (node != null)  
            {
                l.AddBefore(node, 45);
                l.AddAfter(node, 45);
            }
            foreach (int num in l) { Console.WriteLine("after before {0}",num); }

            l.Remove(l.First);
            Console.WriteLine(
                "\nAfter Removing the First Element: "
                + string.Join(" ", l));

            // Removing a specific element (20) using Remove(T)
            l.Remove(20);
            Console.WriteLine("\nAfter Removing Number 20: "
                              + string.Join(" ", l));

            // Removing the first element using RemoveFirst()
            l.RemoveFirst();
            Console.WriteLine(
                "\nAfter Removing the First Element Again: "
                + string.Join(" ", l));

            // Removing the last element using RemoveLast()
            l.RemoveLast();
            Console.WriteLine(
                "\nAfter Removing the Last Element: "
                + string.Join(" ", l));

            // Clearing the entire linkedlist
            l.Clear();
            Console.WriteLine(
                "\nNumber of elements in the list after clearing: "
                + l.Count);

            Console.WriteLine(
                "The element 20 is present in the LinkedList: "
                        + l.Contains(20));




           
        }
        [Test]
        public void stack()
        {
            // Create a new stack
            Stack<int> s = new Stack<int>();

            // Push elements onto the stack
            s.Push(1);
            s.Push(2);
            s.Push(3);
            s.Push(4);

            // Pop elements from the stack
            while (s.Count > 0)
            {
                Console.WriteLine(s.Pop());
            }
        }
        [Test]
        public void queue()
        {
            Queue<int> q = new Queue<int>();

            // Enqueue elements into the queue
            q.Enqueue(1);
            q.Enqueue(2);
            q.Enqueue(3);
            q.Enqueue(4);

            // Dequeue elements from the queue
            while (q.Count > 0)
            {
                Console.WriteLine(q.Dequeue());
            }
        }
    }
}
