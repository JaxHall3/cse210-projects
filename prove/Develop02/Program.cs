using System;
using System.Collections.Generic;
using System.IO;

class Journal
{
    private List<string> prompts = new List<string>();
    private List<string> responses = new List<string>();
    private List<string> dates = new List<string>();

    public void AddEntry(string prompt, string response)
    {
        prompts.Add(prompt);
        responses.Add(response);
        dates.Add(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
    }

    public void DisplayEntries()
    {
        for (int i = 0; i < prompts.Count; i++)
        {
            Console.WriteLine($"Date: {dates[i]}\nPrompt: {prompts[i]}\nResponse: {responses[i]}\n");
        }
    }

    public void SaveToFile(string fileName)
    {
        using (StreamWriter writer = new StreamWriter(fileName))
        {
            for (int i = 0; i < prompts.Count; i++)
            {
                writer.WriteLine($"{dates[i]}|{prompts[i]}|{responses[i]}");
            }
        }
    }

    public void LoadFromFile(string fileName)
    {
        prompts.Clear();
        responses.Clear();
        dates.Clear();

        using (StreamReader reader = new StreamReader(fileName))
        {
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                string[] parts = line.Split('|');
                if (parts.Length == 3)
                {
                    dates.Add(parts[0]);
                    prompts.Add(parts[1]);
                    responses.Add(parts[2]);
                }
            }
        }
    }
}

class PromptGenerator
{
    private List<string> predefinedPrompts = new List<string>
    {
        "Who was the most interesting person I interacted with today?",
        "What was the best part of my day?",
        "How did I see the hand of the Lord in my life today?",
        "What was the strongest emotion I felt today?",
        "If I had one thing I could do over today, what would it be?"
    };

    public string GetRandomPrompt()
    {
        Random random = new Random();
        int index = random.Next(predefinedPrompts.Count);
        return predefinedPrompts[index];
    }
}

class Program
{
    static void Main(string[] args)
    {
        Journal journal = new Journal();
        PromptGenerator promptGenerator = new PromptGenerator();

        while (true)
        {
            Console.WriteLine("1. Write a new entry");
            Console.WriteLine("2. Display the journal");
            Console.WriteLine("3. Save the journal to a file");
            Console.WriteLine("4. Load the journal from a file");
            Console.WriteLine("5. Exit");
            Console.Write("Select an option: ");

            int choice = Convert.ToInt32(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    string prompt = promptGenerator.GetRandomPrompt();
                    Console.WriteLine($"Prompt: {prompt}");
                    Console.Write("Enter your response: ");
                    string response = Console.ReadLine();
                    journal.AddEntry(prompt, response);
                    Console.WriteLine("Entry added.");
                    break;

                case 2:
                    journal.DisplayEntries();
                    break;

                case 3:
                    Console.Write("Enter a filename to save the journal: ");
                    string saveFileName = Console.ReadLine();
                    journal.SaveToFile(saveFileName);
                    Console.WriteLine("Journal saved to file.");
                    break;

                case 4:
                    Console.Write("Enter a filename to load the journal: ");
                    string loadFileName = Console.ReadLine();
                    journal.LoadFromFile(loadFileName);
                    Console.WriteLine("Journal loaded from file.");
                    break;

                case 5:
                    Environment.Exit(0);
                    break;

                default:
                    Console.WriteLine("Invalid option. Please try again.");
                    break;
            }
        }
    }
}
