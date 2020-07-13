using System;
using System.Collections.Generic;
using System.Linq;

namespace Turn10Screener
{
    public class Program
    {
        public static Int32 Main(string[] args)
        {
            // Get input
            Console.Write("What number would you like to target? ");
            int target_sum = Convert.ToInt32(Console.ReadLine());
            Console.Write("What is the list of numbers you would like to use to get to the target number (use spaces)? ");
            string[] input = Console.ReadLine().Split(' ');

            // Create lists
            List<int> numbers = new List<int>();
            List<int[]> output_indexes = new List<int[]>();
            List<int[]> output_numbers = new List<int[]>();

            // Add numbers
            for (int i = 0; i < input.Length; i++)
            {
                numbers.Add(Convert.ToInt32(input[i]));
            }

            // Calculate the number of combinations
            int combinations = (int)(Math.Pow(2, numbers.Count) - 1);

            // Loop all combinations
            for (int i = 0; i < combinations; i++)
            {
                // Create subset lists
                List<int> subset = new List<int>();
                List<int> subindexes = new List<int>();

                // Loop all numbers
                for (int j = 0; j < numbers.Count; j++)
                {
                    if (((i & (1 << j)) >> j) == 1)
                    {
                        // Add the number and the index
                        subset.Add(numbers[j]);
                        subindexes.Add(j);
                    }
                }

                // Check if the target number has been reached
                if (subset.Sum() == target_sum)
                {
                    // Add combination to list
                    output_indexes.Add(subindexes.ToArray());
                    output_numbers.Add(subset.ToArray());
                }
            }

            // Write output
            Console.WriteLine("\n-----------------------------Output-----------------------------");

            // Loop output
            for (int i = 0; i < output_indexes.Count; i++)
            {
                Console.WriteLine(string.Join(" ", output_indexes[i]) + " (" + string.Join(" + ", output_numbers[i]) + " = " + target_sum.ToString() + ")");
            }
            Console.WriteLine("---------------------------------------------------");
            Console.ReadKey();

            //End
            return 0;
        } 
    }
} 
