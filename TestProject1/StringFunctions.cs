using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject1
{
    internal class StringFunctions
    {

        [Test]
        public void stringMethods_advance_task1()
        {
            //String Concatenation
            string str1 ="Ram";
            string str2 = "Kadam";
            string concat = str1 + " " + str2;  
            string concatMethod = string.Concat(str1, " ", str2); 
            Console.WriteLine($"Concatenation: {concat}");
            Console.WriteLine($"Concat Method: {concatMethod}");

            //String Navigation
            Console.WriteLine($"First Character: {str1[0]}");
            Console.WriteLine($"Last Character: {str1[str1.Length - 1]}");

            //String Comparison
            string caseSensitive = "Hello";
            string caseInsensitive = "hello";
            Console.WriteLine($"Equals (Case-Sensitive): {caseSensitive.Equals(caseInsensitive)}");
            Console.WriteLine($"Equals (Ignore Case): {caseSensitive.Equals(caseInsensitive, StringComparison.OrdinalIgnoreCase)}");
            Console.WriteLine($"Compare: {string.Compare(caseSensitive, caseInsensitive, StringComparison.OrdinalIgnoreCase)}");

            //Substring Extraction
            string text = "Welcome to EPAM";
            string subText = text.Substring(11, 4); // Extract EPAM
            Console.WriteLine($"Substring: {subText}");

            // Case Conversion
            Console.WriteLine($"Upper Case: {text.ToUpper()}");
            Console.WriteLine($"Lower Case: {text.ToLower()}");

            //Searching in Strings
            Console.WriteLine($"Contains 'EPAM': {text.Contains("EPAM")}");
            Console.WriteLine($"StartsWith 'Welcome': {text.StartsWith("Welcome")}");
            Console.WriteLine($"EndsWith 'EPAM': {text.EndsWith("EPAM")}");

            // Replace & Modify
            string replaced = text.Replace("EPAM", "People");
            Console.WriteLine($"Replaced: {replaced}");

            // Trimming Spaces
            string spaced = "   Hello World!   ";
            Console.WriteLine($"Trimmed: '{spaced.Trim()}'");

            // Splitting Strings
            string fruits = "Apple, Banana, Mango";
            string[] fruitArray = fruits.Split(", ");
            Console.WriteLine("Fruits:");
            foreach (var fruit in fruitArray)
            {
                Console.WriteLine(fruit);
            }

            //Joining Strings
            string joined = string.Join(" - ", fruitArray);
            Console.WriteLine($"Joined: {joined}");

            //Reversing a String
            string reversed = new string(text.Reverse().ToArray());
            Console.WriteLine($"Reversed: {reversed}");

            //Checking for Empty or Null
            string emptyStr = "";
            Console.WriteLine($"IsNullOrEmpty: {string.IsNullOrEmpty(emptyStr)}");
            Console.WriteLine($"IsNullOrWhiteSpace: {string.IsNullOrWhiteSpace("   ")}");

            //String Interpolation
            string name = "KadamRam";
            int age = 34;
            Console.WriteLine($"Interpolated: My name is {name} and I am {age} years old.");
        }
    }
}
