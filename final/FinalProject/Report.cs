using System;
using System.Collections.Generic;
using System.Linq;

public class Report
{
    private List<Transaction> transactions;

    public Report()
    {
        transactions = new List<Transaction>();
    }

    public void AddTransaction(Transaction transaction)
    {
        transactions.Add(transaction);
    }

    public void GenerateReport()
    {
        Console.WriteLine("-------- Monthly Report --------");

        foreach (Transaction transaction in transactions)
        {
            string sign = (transaction is Income) ? "+" : "-";
            if (transaction is Expense)
            {
                sign = "-";
            }

            Console.WriteLine($" {sign} {(transaction.GetAmount()):C} ({transaction.GetCategory()})");
        }

        double total = CalculateTotal();
        string totalSign = (total >= 0) ? "+" : "-";
        Console.WriteLine($"Total: {totalSign} {(total):C}");

        if (total < 0)
        {
            Console.WriteLine("Warning!: You are negative this month. Change goals/make adjustments.");
        }
        else
        {
            Console.WriteLine("You are in the positive!");
        }

        Console.WriteLine("--------------------------------");
    }

    public void RemoveTransaction(Transaction transactionToRemove)
    {
    Transaction transaction = transactions.FirstOrDefault(t =>
        t is Transaction && t.GetReference().Equals(transactionToRemove.GetReference(), StringComparison.OrdinalIgnoreCase));

    if (transaction != null)
    {
        transactions.Remove(transaction);
        Console.WriteLine($"Transaction '{transaction.GetReference()}' removed successfully!");
    }
    else
    {
        Console.WriteLine($"Transaction '{transactionToRemove.GetReference()}' not found in the report.");
    }
    }

    private double CalculateTotal()
    {
        double totalIncome = transactions.OfType<Income>().Sum(income => income.GetAmount());
        double totalExpense = transactions.OfType<Expense>().Sum(expense => expense.GetAmount());
        return totalIncome - totalExpense;
    }

    public List<Income> GetIncomes()
    {
        return transactions.OfType<Income>().ToList();
    }

    public List<Expense> GetExpenses()
    {
        return transactions.OfType<Expense>().ToList();
    }
}