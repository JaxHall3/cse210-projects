using System;

class Program
{
    static void Main()
    {
        // Ask the user for their grade percentage
        Console.Write("Enter your grade percentage: ");
        double gradePercentage = Convert.ToDouble(Console.ReadLine());

        // Initialize the letter grade variable
        string letter = "";

        // Determine the letter grade based on the percentage
        if (gradePercentage >= 90)
        {
            letter = "A";
        }
        else if (gradePercentage >= 80)
        {
            letter = "B";
        }
        else if (gradePercentage >= 70)
        {
            letter = "C";
        }
        else if (gradePercentage >= 60)
        {
            letter = "D";
        }
        else
        {
            letter = "F";
        }

        // Check if the user passed the course and display a message
        if (gradePercentage >= 70)
        {
            Console.WriteLine($"Your letter grade is {letter}. Congratulations, you passed the course!");
        }
        else
        {
            Console.WriteLine($"Your letter grade is {letter}. Keep working hard for next time!");
        }
    }
}