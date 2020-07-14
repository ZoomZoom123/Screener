using System;
using System.Collections.Generic;
using System.Linq;

namespace Turn10Screener
{
    public class Program
    {
        private static List<int> numbers;
        private static List<int[]> output_indexes;
        private static List<int[]> output_numbers;
        private static int targetSum;
        private static string[] input;
        private static List<int> subset;
        private static List<int> subindexes;

        public static void Main(string[] args)
        {
            PrintSumCombinations(numbers, 25);
        }

        public static int PrintSumCombinations(List<int> numbers, int targetsum)
        {
            GetInput();
            CreateArrayList();
            SumUpNumbers();
            CombinationsAndChecks();
            SolutionOutput();
            Console.WriteLine("Operation Complete.");
            //End
            return 0;
        }

        private static void GetInput()
        {
            // Get input from user
            Console.Write("What number would you like to target? ");
            targetSum = Convert.ToInt32(Console.ReadLine());
            Console.Write("What is the list of numbers you would like to use to get to the target number (use spaces)? ");
            input = Console.ReadLine().Split(' ');
        }

        private static void CreateArrayList()
        {
            // Create lists
            numbers = new List<int>();
            output_indexes = new List<int[]>();
            output_numbers = new List<int[]>();
        }

        private static void SumUpNumbers()
        {
            // Add numbers
            for (int i = 0; i < input.Length; i++)
            {
                numbers.Add(Convert.ToInt32(input[i]));
            }
        }

        private static void CombinationsAndChecks()
        {
            // Calculate the number of possible combinations
            int combinations = (int)(Math.Pow(2, numbers.Count) - 1);

            // Loop all combinations
            for (int i = 0; i < combinations; i++)
            {
                // Create subset lists
                subset = new List<int>();
                subindexes = new List<int>();

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
                if (subset.Sum() == targetSum)
                {
                    // Add combination to list
                    output_indexes.Add(subindexes.ToArray());
                    output_numbers.Add(subset.ToArray());
                }
            }
        }

        private static void SolutionOutput()
        {
            // Write output
            Console.WriteLine("\n-----------------------------Output-----------------------------");

            // Loop output
            for (int i = 0; i < output_indexes.Count; i++)
            {
                Console.WriteLine(string.Join(" ", output_indexes[i]) + " (" + string.Join(" + ", output_numbers[i]) + " = " + targetSum.ToString() + ")");
            }
            Console.WriteLine("---------------------------------------------------\nPress Enter.");
            Console.ReadKey();
        }
    }
}
