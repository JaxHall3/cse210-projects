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
        Console.WriteLine("Budget Tracker/Goals");
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
        Console.Write("Enter the reference (optional): ");
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
        Console.Write("Enter the reference (optional): ");
        string reference = Console.ReadLine();
        Console.Write("Enter the category: ");
        string category = Console.ReadLine().ToLower();

        monthlyReport.AddTransaction(new Expense(amount, reference, category));
        monthlyBudget.AddExpense(new Expense(amount, reference, category));
    }

    public void DisplayReport()
    {
        do
        {
            monthlyReport.GenerateReport();

            Console.WriteLine("1. Back to Main Menu");
            Console.WriteLine("2. Remove Transaction");

            int choice = GetUserChoice();

            switch (choice)
            {
                case 1:
                    // Back to the main menu
                    return;
                case 2:
                    RemoveTransaction();
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        } while (true);
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
        do
        {
            Console.WriteLine("1. Add Budget Goal");
            Console.WriteLine("2. Remove Budget Goal");
            Console.WriteLine("3. View Current Budget Goals");
            Console.WriteLine("4. Back to Main Menu");

            int choice = GetUserChoice();

            switch (choice)
            {
                case 1:
                    AddBudgetCategory();
                    break;
                case 2:
                    RemoveBudgetCategory();
                    break;
                case 3:
                    ViewCurrentBudgetGoals();
                    break;
                case 4:
                    // Back to the main menu
                    return;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        } while (true);
    }

    public void ViewCurrentBudgetGoals()
    {
        Console.WriteLine("-------- Current Budget Goals --------");

        foreach (Category category in monthlyBudget.GetCategories())
        {
            Console.WriteLine($"{category.GetName()}: {category.GetLimit():C}");
        }

        Console.WriteLine("--------------------------------------");

        Console.WriteLine("1. Add Budget Goal");
        Console.WriteLine("2. Remove Budget Goal");
        Console.WriteLine("3. View Current Budget Goals");
        Console.WriteLine("4. Return to Menu");

        int choice = GetUserChoice();

        switch (choice)
        {
            case 1:
                AddBudgetCategory();
                break;
            case 2:
                RemoveBudgetCategory();
                break;
            case 3:
                ViewCurrentBudgetGoals();
                break;
            case 4:
                // Back to the main menu
                return;
            default:
                Console.WriteLine("Invalid choice. Please try again.");
                break;
        }
    }

    public void RemoveTransaction()
    {
        Console.Write("Enter the reference of the transaction to remove: ");
        string reference = Console.ReadLine();

        Transaction transactionToRemove = new Transaction(0, reference);

        monthlyReport.RemoveTransaction(transactionToRemove);

        // Display the updated report
        monthlyReport.GenerateReport();
    }

    public void RemoveBudgetCategory()
    {
        Console.Write("Enter the name of the category to remove: ");
        string categoryToRemove = Console.ReadLine();

        monthlyBudget.RemoveCategory(categoryToRemove);
    }

    private bool ShouldDisplayReference(Category category)
    {
        int count = monthlyReport.GetExpenses().Count(exp => exp.GetCategory().Equals(category.GetName(), StringComparison.OrdinalIgnoreCase)) + monthlyReport.GetIncomes().Count(inc => inc.GetCategory().Equals(category.GetName(), StringComparison.OrdinalIgnoreCase));

        return count > 1;
    }

    public void DisplayBudget()
    {
        Console.WriteLine("-------- Monthly Budget --------");

        foreach (Category category in monthlyBudget.GetCategories())
        {
            double goal = category.GetLimit();
            double spent = 0; // Initialize spent to zero
            double remainingBudget = goal; // Initialize remaining to the goal amount

            // Display associated incomes
            foreach (Income income in monthlyReport.GetIncomes())
            {
                if (income.GetCategory().Equals(category.GetName(), StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine($"   Income: {income.GetAmount():C}" + (ShouldDisplayReference(category) ? $" - {income.GetReference()}" : ""));
                }
            }

            // Display associated expenses
            foreach (Expense expense in monthlyReport.GetExpenses())
            {
                if (expense.GetCategory().Equals(category.GetName(), StringComparison.OrdinalIgnoreCase))
                {
                    spent += expense.GetAmount(); // Accumulate the total spent
                    Console.WriteLine($"   Expense: {expense.GetAmount():C}" + (ShouldDisplayReference(category) ? $" - {expense.GetReference()}" : ""));
                }
            }

            remainingBudget -= spent; // Calculate remaining as goal minus spent

            // Display remaining with a warning if negative
            Console.Write($"{category.GetName()}: Goal: {goal:C}, Spent: {spent:C}, Remaining: ");
            if (remainingBudget < 0 && spent > goal)
            {
                Console.ForegroundColor = ConsoleColor.Red; // Set text color to red
                Console.Write($"-{remainingBudget:C} (Warning!: Overdraft)");
                Console.ResetColor(); // Reset text color
            }
            else
            {
                Console.Write($"{remainingBudget:C}");
            }

            if (ShouldDisplayReference(category))
            {
                // Display reference for Category if applicable
                Console.Write($" ({category.GetReference()})");
            }

            Console.WriteLine();
        }

        Console.WriteLine("--------------------------------");
    }

// Helper method to determine if the reference should be displayed
private bool ShouldDisplayReference(Transaction transaction)
{
    int count = monthlyReport.GetExpenses().Count(exp => exp.GetCategory().Equals(transaction.GetCategory(), StringComparison.OrdinalIgnoreCase))
              + monthlyReport.GetIncomes().Count(inc => inc.GetCategory().Equals(transaction.GetCategory(), StringComparison.OrdinalIgnoreCase));

    return count > 1 && (transaction is Income || transaction is Expense);
}

    public void Exit()
    {
        Console.WriteLine("Thanks for using the Program. Goodbye!");
        Environment.Exit(0);
    }
}