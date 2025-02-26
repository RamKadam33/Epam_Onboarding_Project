using System;
using System.Text;

namespace TestProject1
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }
        [Test]
        public void TestArray_AdvanceDotnet_Task12_13()
        {

            string[] addressParts = { "Ram", "Kadam", "At", "Kotharul", "Tq", "Majalgaon", "Dist", "Beed", "Kadam" };

            Console.WriteLine("Original Array: " + string.Join(", ", addressParts));

            //Sorting
            string[] sortedArray = (string[])addressParts.Clone();
            Array.Sort(sortedArray);
            Console.WriteLine("\nSorted Array: " + string.Join(", ", sortedArray));

            //Reverse
            string[] reversedArray = (string[])addressParts.Clone();
            Array.Reverse(reversedArray);
            Console.WriteLine("\nReversed Array: " + string.Join(", ", reversedArray));

            //Finding Index
            int firstIndex = Array.IndexOf(addressParts, "Kadam");
            int lastIndex = Array.LastIndexOf(addressParts, "Kadam");
            Console.WriteLine($"\nFirst occurrence of 'Kadam': Index {firstIndex}");
            Console.WriteLine($"Last occurrence of 'Kadam': Index {lastIndex}");

            //Removing Duplicates
            string[] distinctArray = addressParts.Distinct().ToArray();
            Console.WriteLine("\nArray Without Duplicates: " + string.Join(", ", distinctArray));

            //Finding Elements with 'K'
            string[] startsWithK = Array.FindAll(addressParts, x => x.StartsWith("K"));
            Console.WriteLine("\nWords starting with 'K': " + string.Join(", ", startsWithK));

            // Checking Existence of 'Beed'
            bool exists = addressParts.Contains("Beed");
            Console.WriteLine($"\nDoes 'Beed' exist in the array? {exists}");

            //Copying Array
            string[] copiedArray = new string[addressParts.Length];
            Array.Copy(addressParts, copiedArray, addressParts.Length);
            Console.WriteLine("\nCopied Array: " + string.Join(", ", copiedArray));

            //Resizing Array
            Array.Resize(ref addressParts, 12);
            addressParts[9] = "New Entry 1";
            addressParts[10] = "New Entry 2";
            addressParts[11] = "New Entry 3";
            Console.WriteLine("\nResized Array: " + string.Join(", ", addressParts));

            // Clearing Specific Elements
            Array.Clear(addressParts, 2, 2); // Clears 2 elements from index 2
            Console.WriteLine("\nArray After Clearing Elements (Index 2-3): " + string.Join(", ", addressParts));

        }
        [Test]
        public void TestStringBulder_AdvanceDotnet_Task11()
        {
           
            StringBuilder sb = new StringBuilder("Ram Kadam");
            Console.WriteLine(sb.ToString());
            // Append the address details
            sb.Append(" At Kotharul");
            sb.Append(", Tq Majalgaon");
            sb.Append(", Dist Beed");
            Console.WriteLine(sb.ToString());
            // Insert additional information 
            sb.Insert(0, "Name: ");
            Console.WriteLine(sb.ToString());
            sb.Insert(sb.Length, " (Maharashtra, India)");
            Console.WriteLine(sb.ToString());

            // Replace a word
            sb.Replace("Tq", "Taluka");                      
            Console.WriteLine(sb.ToString());
            sb.Remove(0,5);
            Console.WriteLine(sb.ToString());
            // Display Length & Capacity
            Console.WriteLine("Length: " + sb.Length);
            Console.WriteLine("Capacity: " + sb.Capacity);
        }
        [Test]
        public void EqualsAndReferenceTest_AdvanceDotnet_Task10()
        {
            Person person1 = new Person("Ram", 30);
            Person person2 = new Person("Ram", 30);
            Person person3 = person1; 

            // == Checks Reference Equality
            Console.WriteLine("person1 == person2: " + (person1 == person2)); // False
            Console.WriteLine("person1 == person3: " + (person1 == person3)); // True

            // 'Equels' Checkes Value Equality
            Console.WriteLine("person1.Equals(person2): " + person1.Equals(person2)); // True
            Console.WriteLine("person1.Equals(person3): " + person1.Equals(person3)); // True
        }
    }
    public class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }

        public Person(string name, int age)
        {
            Name = name;
            Age = age;
        }

    }
}