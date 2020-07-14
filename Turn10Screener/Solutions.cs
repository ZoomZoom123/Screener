using System;
using System.Collections.Generic;
using System.Linq;

namespace Solutions
{
    public class Solution1
    {
        private static List<int> numbers = new List<int> { 1, 1, 2, 2, 4 };
        private static List<int[]> outputIndexes;
        private static List<int[]> outputNumbers;
        private static int myTargetSum = 4;
        private static List<int> subset;
        private static List<int> subindexes;

        public static void ScreenerSolutionNum1()
        {            
            PrintSumCombinations(numbers, myTargetSum);
        }

        public static int PrintSumCombinations(List<int> myNumbers, int myTargetSum)
        {
            Console.WriteLine("The target number is " + myTargetSum + ".");
            string myNumbersArray = String.Join(", ", myNumbers.Select(p=>p.ToString()).ToArray());
            Console.WriteLine("The list of numbers to get to the target number are " + myNumbersArray + ".");

            CombinationsAndChecks(myNumbers.ToArray());

            SolutionOutput();;

            //End
            return 0;
        }

        private static void CombinationsAndChecks(int[] newNumbers)
        {
            // Create lists
            numbers = new List<int>();            
            for (int i = 0; i < newNumbers.Length; i++)
            {
                numbers.Add(newNumbers[i]);
            }
   
            outputIndexes = new List<int[]>();
            outputNumbers = new List<int[]>();
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
                if (subset.Sum() == myTargetSum)
                {
                    // Add combination to list
                    outputIndexes.Add(subindexes.ToArray());
                    outputNumbers.Add(subset.ToArray());
                }
            }
        }

        private static void SolutionOutput()
        {
            // Write output
            Console.WriteLine("\n-----------------------------Output-----------------------------");

            // Loop output
            for (int i = 0; i < outputIndexes.Count; i++)
            {
                Console.WriteLine(string.Join(" ", outputIndexes[i]) + "\n" + myTargetSum.ToString());
            }
            Console.WriteLine("---------------------------------------------------\nPress Enter.");
            Console.ReadKey(true);
            Console.WriteLine("Operation Complete.");
        }
    }

    /*public class Solution2
    {
        private static List<int> numbers;
        private static List<int[]> output_indexes;
        private static List<int[]> output_numbers;
        private static int targetSum;
        private static string[] input;
        private static List<int> subset;
        private static List<int> subindexes;

        public static void ScreenerSolutionNum2()
        {
            PrintSumCombinations(numbers, 25);
        }

        public static int PrintSumCombinations(List<int> numbersList, int targetSum)
        {
            GetSumTarget(targetSum);
            CreateArrayList(numbersList);
            SumUpNumbers();
            CombinationsAndChecks();
            Console.WriteLine("Operation Complete.");
            //End
            return 0;
        }

        private static void GetSumTarget(int targetSum)
        {
            // Get input from user
            Console.Write("The target number is " + targetSum + ".");
        }

        private static int[] CreateArrayList(int length)
        {
            // Create random array lists of integers in a range of 0 to 30
            numbers = new List<int>();
            output_indexes = new int[length];
            output_numbers = new int[length];
            var rand = new Random();
            for (int i = 0; i < length; i++)
            {
                output_numbers[i] = rand.Next(31);
            }
            return output_numbers;
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
            SolutionOutput();
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
    }*/
}