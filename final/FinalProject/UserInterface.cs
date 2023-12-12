using System;

public class UserInterface
{
    private Report monthlyReport;
    private Budget monthlyBudget;

    public UserInterface(Report report, Budget budget)
    {
        monthlyReport = report;
        monthlyBudget = budget;
    }

    public void DisplayMainMenu()
    {
        Console.WriteLine("1. Add Income");
        Console.WriteLine("2. Add Expense");
        Console.WriteLine("3. Display Report");
        Console.WriteLine("4. Budget Goals");
        Console.WriteLine("5. Display Budget");
        Console.WriteLine("6. Exit");
    }

    public int GetUserChoice()
    {
        while (true)
        {
            Console.Write("Enter your choice: ");
            string input = Console.ReadLine();

            if (int.TryParse(input, out int choice))
            {
                return choice;
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a valid number.");
            }
        }
    }

    public void AddIncome()
    {
        Console.Write("Enter the income amount: ");
        double amount = double.Parse(Console.ReadLine());
        Console.Write("Enter the reference: ");
        string reference = Console.ReadLine();
        Console.Write("Enter the category: ");
        string category = Console.ReadLine().ToLower();

        monthlyReport.AddTransaction(new Income(amount, reference, category));
        monthlyBudget.AddIncome(new Income(amount, reference, category));
    }

    public void AddExpense()
    {
        Console.Write("Enter the expense amount: ");
        double amount = double.Parse(Console.ReadLine());
        Console.Write("Enter the reference: ");
        string reference = Console.ReadLine();
        Console.Write("Enter the category: ");
        string category = Console.ReadLine().ToLower();

        monthlyReport.AddTransaction(new Expense(amount, reference, category));
        monthlyBudget.AddExpense(new Expense(amount, reference, category));
    }

    public void DisplayReport()
    {
        monthlyReport.GenerateReport();
    }

    public void AddBudgetCategory()
    {
        Console.Write("Enter the category name: ");
        string name = Console.ReadLine();
        Console.Write("Enter the monthly limit for the category: ");
        double limit = double.Parse(Console.ReadLine());

        monthlyBudget.AddCategory(name, limit);

        Console.WriteLine("Budget category added successfully!");
    }

    public void AddRemoveBudgetGoal()
    {
        Console.WriteLine("1. Add Budget Goal");
        Console.WriteLine("2. Remove Budget Goal");

        int choice = GetUserChoice();

        switch (choice)
        {
            case 1:
                AddBudgetCategory();
                break;
            case 2:
                RemoveBudgetCategory();
                break;
            default:
                Console.WriteLine("Invalid choice. Please try again.");
                break;
        }
    }

    public void RemoveBudgetCategory()
    {
        Console.Write("Enter the name of the category to remove: ");
        string categoryToRemove = Console.ReadLine();

        monthlyBudget.RemoveCategory(categoryToRemove);
    }

    public void DisplayBudget()
    {
        monthlyBudget.DisplayBudget();
    }

    public void Exit()
    {
        Console.WriteLine("Exiting the program. Goodbye!");
        Environment.Exit(0);
    }
}