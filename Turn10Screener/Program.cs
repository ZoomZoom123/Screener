using System;
using System.Collections.Generic;
using System.Linq;

namespace Turn10Screener
{
    public class SumCombinations
    {
        public static Int32 Main(string[] args)
        {
            // Get input
            int target_sum = Convert.ToInt32(Console.ReadLine());
            string[] input = Console.ReadLine().Split(' ');

            // Create lists
            List<Int32> numbers = new List<Int32>();
            List<Int32[]> output_indexes = new List<Int32[]>();
            List<Int32[]> output_numbers = new List<Int32[]>();

            // Add numbers
            for (int i = 0; i < input.Length; i++)
            {
                numbers.Add(Convert.ToInt32(input[i]));
            }

            // Calculate the number of combinations
            Int32 combinations = (Int32)(Math.Pow(2, numbers.Count) - 1);

            // Loop all combinations
            for (int i = 0; i < combinations; i++)
            {
                // Create subset lists
                List<Int32> subset = new List<Int32>();
                List<Int32> subindexes = new List<Int32>();

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

                // Check if the target sum has been reached
                if (subset.Sum() == target_sum)
                {
                    // Add a combination
                    output_indexes.Add(subindexes.ToArray());
                    output_numbers.Add(subset.ToArray());
                    //break;
                }
            }

            // Write output
            Console.WriteLine("\nOutput");
            Console.WriteLine("---------------------------------------------------");

            // Loop output
            for (int i = 0; i < output_indexes.Count; i++)
            {
                Console.WriteLine(string.Join(" ", output_indexes[i]) + " (" + string.Join(" + ", output_numbers[i]) + " = " + target_sum.ToString() + ")");
            }

            Console.WriteLine("---------------------------------------------------");

            // Pause the program
            Console.ReadKey();

            // Return success
            return 0;

        } // End of the Main method

    } // End of the class

} // End of the namespace
