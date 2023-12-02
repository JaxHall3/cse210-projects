using System;
using System.Collections.Generic;
using System.Linq;

public class Budget
{
    private List<Income> incomes;
    private List<Expense> expenses;

    public Budget()
    {
        incomes = new List<Income>();
        expenses = new List<Expense>();
    }

    public void AddIncome(Income income)
    {
        incomes.Add(income);
    }

    public void AddExpense(Expense expense)
    {
        expenses.Add(expense);
    }

    public decimal CalculateBudgetSummary()
    {
        decimal incomeSummary = incomes.Sum(income => income.CalculateSummary());
        decimal expenseSummary = expenses.Sum(expense => expense.CalculateSummary());

        return incomeSummary + expenseSummary;
    }
}