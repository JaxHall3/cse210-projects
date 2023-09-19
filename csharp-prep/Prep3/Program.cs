using System;

class Program
{
    static void Main()
    {
        Random random = new Random();
        int magicNumber = random.Next(1,101);
        
        Console.WriteLine("Welcome to the Guess My Number game!");
        Console.WriteLine("I've picked a mgic number between 1 and 100. Try to guess it.");

        int userGuess;
        do
        {
            Console.Write("Enter your guess: ");
            userGuess = int.Parse(Console.ReadLine());

            if (userGuess < magicNumber)
            {
                Console.WriteLine("Higher");
            }
            else if (userGuess > magicNumber)
            {
                Console.WriteLine("Lower");
            }
            else
            {
                Console.WriteLine("You guessed it!");
            }
        } while (userGuess != magicNumber);

        Console.WriteLine("Congratulations! You've guessed the magic number.");
    }
}