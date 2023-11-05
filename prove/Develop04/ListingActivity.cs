using System; // Import the System namespace, which contains fundamental classes and base types.

class ListingActivity : MindfulnessActivity
{
    private readonly string[] listingPrompts = new string[]
    {
        "Who are people that you appreciate?",
        "What are personal strengths of yours?",
        "Who are people that you have helped this week?",
        "When have you felt the Holy Ghost this month?",
        "Who are some of your personal heroes"
    };

    public ListingActivity() : base("Listing Activity", "Reflect on the Good Things in Your Life") // Constructor for the ListingActivity class.
    {
    }

    protected override void Perform()
    {
        string randomPrompt = listingPrompts[new Random().Next(listingPrompts.Length)]; // Select a random listing prompt.

        Console.WriteLine(randomPrompt); // Display the selected listing prompt.
        Console.WriteLine("Take a few seconds to think about it...");
        base.ShowCountdown("Starting in", 5); // Show a countdown before starting the activity.

        int itemCount = 0;
        while (duration > 0)
        {
            Console.Write("Enter an item (or 'done' to finish): ");
            string item = Console.ReadLine();

            if (item.ToLower() == "done")
                break;

            itemCount++;
            duration--;
        }

        Console.WriteLine($"You listed {itemCount} items."); // Display the total number of listed items.
    }
}