using System;
using System.Collections.Generic;

namespace NumberListAnalyzer
{
    class Program{
        static void Main(string[]args)
        {
            List<int> numbers = new List<int>();

            Console.WriteLine("Enter a list of numbers, type 0 when finished.");

            while (true)
            {
                Console.Write("Enter number: ");
                int input = Convert.ToInt32(Console.ReadLine());

                if (input == 0)
                    break;
                numbers.Add(input);
            }
            if (numbers.Count == 0)
            {
                Console.WriteLine("NO numbers entered.");
            }
            else
            {
                int sum = 0;
                int max = numbers[0];
                
                foreach (int num in numbers)
                {
                    sum += num;

                    if (num > max)
                    {
                        max = num;
                    }
                }

                double average = (double)sum / numbers.Count;

                Console.WriteLine($"The sum is: {sum}");
                Console.WriteLine($"The average is: {average}");
                Console.WriteLine($"The largest number is: {max}");
            }
        }
    }
}