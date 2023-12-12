using System;
using System.Collections.Generic;
using System.Linq;

public class Category
{
    private string name;
    private double limit;
    private double totalExpense;
    private List<Transaction> transactions;

    public Category(string name, double limit)
    {
        this.name = name;
        this.limit = limit;
        transactions = new List<Transaction>();
    }

    public string GetName()
    {
        return name.ToUpper();
    }

    public double GetLimit()
    {
        return limit;
    }

    // Calculate the total income for this category
    public double GetTotalIncome()
    {
        return transactions.OfType<Income>().Sum(income => income.GetAmount());
    }

    // Calculate the total expense for this category
    public double GetTotalExpense()
    {
        return transactions.OfType<Expense>().Sum(expense => expense.GetAmount());
    }

    public void AddTransaction(Transaction transaction)
    {
        transactions.Add(transaction);

        // Update total expense when an expense is added
        if (transaction is Expense expense)
        {
            totalExpense += expense.GetAmount();
        }
    }

    public double GetRemainingBudget()
    {
        return GetLimit() - totalExpense;
    }
}