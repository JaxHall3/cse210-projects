using System;
using System.Collections.Generic;
using System.Linq;

class Scripture
{
    private string reference;
    private List<string> words;
    private int hiddenWords;

    public Scripture(string reference, string text)
    {
        this.reference = reference;
        words = text.Split(' ').ToList();
        hiddenWords = 0;
    }

    public bool IsComplete()
    {
        return hiddenWords == words.Count;
    }

    public void HideWords(int numToHide)
    {
        for (int i = 0; i < numToHide; i++)
        {
            int index = new Random().Next(words.Count);
            if (words[index] != "_____") // Ensure not hiding already hidden words
            {
                words[index] = "_____";
                hiddenWords++;
            }
        }
    }

    public void Display()
    {
        Console.Clear();
        Console.WriteLine($"{reference}:\n{string.Join(" ", words)}");
    }
}

class Reference
{
    private string reference;

    public Reference(string referenceStr)
    {
        reference = referenceStr;
    }

    public override string ToString()
    {
        return reference;
    }
}

class Program
{
    static void Main(string[] args)
    {
        string referenceStr = "John 3:16";
        string scriptureText = "For God so loved the world that he gave his one and only Son, that whoever believes in him shall not perish but have eternal life.";

        Reference reference = new Reference(referenceStr);
        Scripture scripture = new Scripture(referenceStr, scriptureText);

        while (!scripture.IsComplete())
        {
            Console.Write("Press Enter to reveal more words or type 'quit' to exit: ");
            string userInput = Console.ReadLine();

            if (userInput.ToLower() == "quit")
                break;

            scripture.HideWords(5); // Adjust the number of words to reveal
            scripture.Display();
        }

        Console.WriteLine("Program ended.");
    }
}