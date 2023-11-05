using System; // Import the System namespace, which contains fundamental classes and base types.

class Program
{
    static void Main(string[] args)
    {
        while (true) // Start an infinite loop, which can be exited by the user selecting option 4.
        {
            Console.WriteLine("Welcome to the Mindfulness App!"); // Display a welcome message.
            Console.WriteLine("Choose an activity:"); // Prompt the user to choose an activity.
            Console.WriteLine("1. Breathing Activity");
            Console.WriteLine("2. Reflection Activity");
            Console.WriteLine("3. Listing Activity");
            Console.WriteLine("4. Quit");

            string choice = Console.ReadLine(); // Read the user's choice as a string.

            MindfulnessActivity activity = null; // Initialize a variable to store the selected mindfulness activity.

            switch (choice)
            {
                case "1":
                    activity = new BreathingActivity(); // Create a new instance of BreathingActivity when user selects option 1.
                    break;

                case "2":
                    activity = new ReflectionActivity(); // Create a new instance of ReflectionActivity when user selects option 2.
                    break;

                case "3":
                    activity = new ListingActivity(); // Create a new instance of ListingActivity when user selects option 3.
                    break;

                case "4":
                    Console.WriteLine("Goodbye!"); // Display a goodbye message.
                    Environment.Exit(0); // Terminate the application with a code of 0 (usually indicates a successful exit).
                    break;

                default:
                    Console.WriteLine("Invalid choice. Please select a valid option."); // Display a message for an invalid choice.
                    break;
            }

            if (activity != null)
            {
                activity.PerformActivity(); // If a valid activity is selected, call the PerformActivity method of the chosen activity.
            }
        }
    }
}