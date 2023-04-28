using System.Diagnostics;

namespace Lab3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Stopwatch sw = new Stopwatch();
            MinimumArrayValue minValue = new MinimumArrayValue(10);
            
            sw.Start();
            int minimum_value = minValue.Run();
            sw.Stop();

            Console.WriteLine($"Finished 'MinimumArrayValue.Run()' in: {sw.Elapsed} seconds.");
            Console.WriteLine($"Den aktuella arrayen är: {minValue.GetArray()}.\nDet minsta värdet är {minimum_value}");
            
            Console.WriteLine();

            sw = new Stopwatch();
            sw.Start();
            MultiplicationTable.CreateMultiplicationTable();
            sw.Stop();
            Console.WriteLine($"Finished 'CreateMultiplicationTable' in: {sw.Elapsed} seconds.");

            Console.WriteLine();

            string str = "A man, a plan, a canal, Panama!";
            sw = new Stopwatch();
            sw.Start();
            string isPalindrome = PalindromeAlgorithm.IsPalindrome(str) ? "Yes" : "No";
            sw.Stop();
            Console.WriteLine($"Finished 'IsPalindrome' in: {sw.Elapsed} seconds.");
            Console.WriteLine($"Is '{str}' a Palindrome?: Judges says {isPalindrome}");

            Console.ReadLine();
        }
    }
}