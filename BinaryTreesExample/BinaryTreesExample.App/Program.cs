using BinaryTreesExample.Lib;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace BinaryTreesExample.App
{
    class Program
    {
        static void Main(string[] args)
        {
            // n.b. this isn't actually random, it's a PRNG https://en.wikipedia.org/wiki/Pseudorandom_number_generator 
            // if you give the random constructor a parameter, it will deterministically produce the same 
            // string of random digits.
            Random r = new Random();

            // generate a list of 100 numbers (that's the Range(1, 100) bit) 
            // between 1 and 1000 (that's the r.Next bit) 
            IList<int> numbers = Enumerable.Range(1, 100).Select(i => r.Next(1, 1000)).ToList();
            BinaryTree bt = new BinaryTree();

            foreach (int i in numbers)
                bt.Add(i);

            Console.WriteLine(bt.Depth);

            // make some assertions that we think should be true 
            Debug.Assert(numbers.Count == bt.Count, "count is wrong");

            Debug.Assert(numbers.Sum() == bt.Sum, "sum is wrong");

            // this is known as an interpolated string, with the $ indicating that any 
            // {} will contain an actual variable. 
            Console.WriteLine($"The tree has {bt.Count} items.");

            Console.ReadKey();
        }
    }
}
