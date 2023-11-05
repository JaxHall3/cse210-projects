using System; // Import the System namespace, which contains fundamental classes and base types.

class ReflectionActivity : MindfulnessActivity
{
    private readonly string[] reflectionPrompts = new string[]
    {
        "Think of a time when you stood up for someone else.",
        "Think of a time when you did something really difficult.",
        "Think of a time when you helped someone in need.",
        "Think of a time when you did something truly selfless."
    };

    private readonly string[] reflectionQuestions = new string[]
    {
        "Why was this experience meaningful to you?",
        "Have you ever done anything like this before?",
        "How did you get started?",
        "How did you feel when it was complete?",
        "What made this time different than other times when you were not as successful?",
        "What is your favorite thing about this experience?",
        "What could you learn from this experience that applies to other situations?",
        "What did you learn about yourself through this experience?",
        "How can you keep this experience in mind in the future?"
    };

    public ReflectionActivity() : base("Reflection Activity", "Recognize Your Strength and Resilience") // Constructor for the ReflectionActivity class.
    {
    }

    protected override void Perform()
    {
        string randomPrompt = reflectionPrompts[new Random().Next(reflectionPrompts.Length)]; // Select a random reflection prompt.

        Console.WriteLine(randomPrompt); // Display the selected reflection prompt.
        Console.WriteLine("Take a few seconds to think about it...");
        base.ShowCountdown("Starting in", 5); // Show a countdown before starting the activity.

        int questionIndex = 0;
        while (duration > 0)
        {
            Console.WriteLine("Press Enter to continue or type 'exit' to return to the main menu...");
            string userInput = Console.ReadLine();

            if (userInput.ToLower() == "exit")
            {
                Console.WriteLine("Returning to the main menu...");
                break;
            }

            Console.Clear(); // Clear the screen for a cleaner display.

            if (questionIndex < reflectionQuestions.Length)
            {
                Console.WriteLine(reflectionQuestions[questionIndex]); // Display a reflection question.
                Console.WriteLine("Take a few seconds to think about it...");
                base.ShowSpinner(5); // Show a spinner animation.
                questionIndex++;
                duration--;
            }
            else
            {
                Console.WriteLine("You've completed the reflection activity.");
                break;
            }
        }
    }
}