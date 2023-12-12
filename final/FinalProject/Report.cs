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
            string sign = (transaction.GetAmount() >= 0) ? "+" : "-";
            Console.WriteLine($"  {sign} {Math.Abs(transaction.GetAmount()):C} ({transaction.GetReference()})");
        }

        double total = CalculateTotal();
        string totalSign = (total >= 0) ? "+" : "-";
        Console.WriteLine($"Total: {totalSign} {Math.Abs(total):C}");

        if (total < 0)
        {
            Console.WriteLine("You are negative this month. Change goals/make adjustments.");
        }
        else
        {
            Console.WriteLine("You are in the positive!");
        }

        Console.WriteLine("--------------------------------");
    }

    private double CalculateTotal()
    {
        double totalIncome = transactions.OfType<Income>().Sum(income => income.GetAmount());
        double totalExpense = transactions.OfType<Expense>().Sum(expense => expense.GetAmount());
        return totalIncome - totalExpense;
    }
}