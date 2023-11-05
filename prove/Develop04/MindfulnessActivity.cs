using System; // Import the System namespace, which contains fundamental classes and base types.
using System.Threading; // Import the System.Threading namespace for working with threads and timing.

abstract class MindfulnessActivity
{
    protected string name;
    protected string description;
    protected int duration;

    public MindfulnessActivity(string name, string description)
    {
        this.name = name;
        this.description = description;
    }
    
    public void PerformActivity()
    {
        Console.WriteLine($"{name} - {description}"); // Display the name and description of the activity.
        Console.WriteLine("Set the duration (in seconds):");
        duration = int.Parse(Console.ReadLine()); // Read the duration in seconds from the user.

        CommonStartingMessage(); // Call a common starting message method.
        Perform(); // Call the abstract method to perform the specific activity.
        CommonEndingMessage(); // Call a common ending message method.
    }

    protected void CommonStartingMessage()
    {
        Console.WriteLine("Prepare to begin..."); // Display a preparation message.
        ShowCountdown("Starting in", 3); // Show a countdown before starting.
    }

    protected void CommonEndingMessage()
    {
        Console.WriteLine("You've done a good job!"); // Display a completion message.
        Console.WriteLine($"You have completed the {name} in {duration} seconds."); // Display activity completion details.
        ShowCountdown("Returning to the menu in", 3); // Show a countdown before returning to the menu.
    }

    protected void ShowCountdown(string message, int seconds)
    {
        for (int i = seconds; i > 0; i--)
        {
            Console.WriteLine($"{message} {i}..."); // Display a countdown message.
            Thread.Sleep(1000); // Pause for one second.
        }
    }

    protected void ShowSpinner(int duration)
    {
        string[] spinners = { "/", "-", "\\", "|" };
        for (int i = 0; i < duration; i++)
        {
            Console.Write($"\r{spinners[i % 4]}"); // Display a spinning animation.
            Thread.Sleep(1000); // Pause for one second.
        }
    }

    protected abstract void Perform(); // Define an abstract method that must be implemented by subclasses.
}