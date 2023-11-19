// Program.cs
using System;

class Program
{
    static void Main()
    {
        GoalTracker goalTracker = new GoalTracker();

        // User sets goals
        SetUserGoals(goalTracker);

        // User records progress
        RecordUserProgress(goalTracker);

        // Display final goals and points
        goalTracker.DisplayGoals();
    }

    static void SetUserGoals(GoalTracker goalTracker)
    {
        Console.WriteLine("Welcome to the Goal Tracker!");
        Console.WriteLine("Let's start by setting your goals.");

        int goalNumber = 1;
        while (true)
        {
            Console.Write($"Enter the name of goal #{goalNumber} (or type 'stop' to finish): ");
            string goalName = Console.ReadLine();

            if (goalName.ToLower() == "stop")
            {
                break;
            }

            int goalPoints;
            while (true)
            {
                Console.Write("Enter the points for the goal: ");
                string input = Console.ReadLine();

                if (int.TryParse(input, out goalPoints))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a valid numeric value for points.");
                }
            }

            bool isSimpleGoal;
            while (true)
            {
                Console.Write("Is this a simple goal? (yes/no): ");
                string input = Console.ReadLine();

                if (input.ToLower() == "yes" || input.ToLower() == "no")
                {
                    isSimpleGoal = input.ToLower() == "yes";
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter 'yes' or 'no'.");
                }
            }

            if (isSimpleGoal)
            {
                goalTracker.AddGoal(new SimpleGoal(goalName, goalPoints));
            }
            else
            {
                bool isEternalGoal;
                while (true)
                {
                    Console.Write("Is this an eternal goal? (yes/no): ");
                    string input = Console.ReadLine();

                    if (input.ToLower() == "yes" || input.ToLower() == "no")
                    {
                        isEternalGoal = input.ToLower() == "yes";
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Invalid input. Please enter 'yes' or 'no'.");
                    }
                }

                if (isEternalGoal)
                {
                    goalTracker.AddGoal(new EternalGoal(goalName, goalPoints));
                }
                else
                {
                    int targetCount;
                    while (true)
                    {
                        Console.Write("Enter the number of times this goal should be completed: ");
                        string input = Console.ReadLine();

                        if (int.TryParse(input, out targetCount))
                        {
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Invalid input. Please enter a valid numeric value for target count.");
                        }
                    }

                    goalTracker.AddGoal(new ChecklistGoal(goalName, goalPoints, targetCount));
                }
            }

            goalNumber++;
        }

        Console.WriteLine("Goals set successfully!\n");
    }

    static void RecordUserProgress(GoalTracker goalTracker)
    {
        Console.WriteLine("Now let's record your progress.");

        while (true)
        {
            goalTracker.DisplayGoals();

            Console.Write("Enter the index of the goal you want to record progress for (or 0 to finish): ");
            int goalIndex;
            while (true)
            {
                string input = Console.ReadLine();

                if (int.TryParse(input, out goalIndex))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a valid numeric value for the goal index.");
                }
            }

            if (goalIndex == 0)
            {
                break;
            }

            goalTracker.RecordEvent(goalIndex - 1);
        }

        Console.WriteLine("Progress recorded successfully!\n");
    }
}