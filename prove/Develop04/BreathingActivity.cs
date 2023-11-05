using System; // Import the System namespace, which contains fundamental classes and base types.
using System.Threading; // Import the System.Threading namespace for working with threads and timing.

class BreathingActivity : MindfulnessActivity
{
    public BreathingActivity() : base("Breathing Activity", "Deep Breathing") // Constructor for the BreathingActivity class.
    {
    }

    protected override void Perform()
    {
        int prompts = duration / 8; // Calculate the number of breathing prompts based on the total duration (each cycle consists of 4 phases).
        int remainingTime = duration; // Initialize the remaining time with the total duration.

        for (int i = 0; i < prompts; i++) // Loop through each breathing cycle.
        {
            Console.WriteLine("Breathe in..."); // Prompt the user to breathe in.
            remainingTime -= 2; // Subtract 2 seconds for the "Breathe in" phase.
            ShowCountdown("Time remaining", 2); // Show a countdown for 2 seconds.

            if (remainingTime > 0)
            {
                Console.WriteLine("Hold..."); // Prompt the user to hold their breath.
                remainingTime -= 2; // Subtract 2 seconds for the "Hold" phase.
                ShowCountdown("Time remaining", 2); // Show a countdown for 2 seconds.

                if (remainingTime > 0)
                {
                    Console.WriteLine("Breathe out..."); // Prompt the user to breathe out.
                    remainingTime -= 2; // Subtract 2 seconds for the "Breathe out" phase.
                    ShowCountdown("Time remaining", 2); // Show a countdown for 2 seconds.

                    if (remainingTime > 0)
                    {
                        Console.WriteLine("Hold..."); // Prompt the user to hold their breath again.
                        remainingTime -= 2; // Subtract 2 seconds for the "Hold" phase.
                        ShowCountdown("Time remaining", 2); // Show a countdown for 2 seconds.
                    }
                }
            }
        }
    }
}