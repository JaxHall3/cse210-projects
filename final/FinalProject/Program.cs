using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("Budget/Money Tracker Program");

        // Example usage:
        Budget budget = new Budget();

        Console.Write("Enter income amount: ");
        decimal incomeAmount = decimal.Parse(Console.ReadLine());
        Income income = new Income { Amount = incomeAmount, Date = DateTime.Now, Description = "Salary" };
        budget.AddIncome(income);

        Console.Write("Enter expense amount: ");
        decimal expenseAmount = decimal.Parse(Console.ReadLine());
        Console.Write("Enter expense category: ");
        string expenseCategory = Console.ReadLine();
        Expense expense = new Expense { Amount = expenseAmount, Date = DateTime.Now, Description = "Expense", Category = expenseCategory };
        budget.AddExpense(expense);

        decimal budgetSummary = budget.CalculateBudgetSummary();
        Console.WriteLine($"Current Budget Summary: {budgetSummary:C}");
    }
}