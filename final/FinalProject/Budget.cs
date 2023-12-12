public class Budget
{
    private List<Category> categories;

    public Budget()
    {
        categories = new List<Category>();
    }

    public void AddCategory(string name, double limit)
    {
        Category category = new Category(name, limit);
        categories.Add(category);
    }

    public void RemoveCategory(string name)
    {
        Category categoryToRemove = categories.FirstOrDefault(cat => cat.GetName().Equals(name, StringComparison.OrdinalIgnoreCase));

        if (categoryToRemove != null)
        {
            categories.Remove(categoryToRemove);
            Console.WriteLine($"Budget category '{name}' removed successfully!");
        }
        else
        {
            Console.WriteLine($"Budget category '{name}' not found.");
        }
    }

    public void AddExpense(Expense expense)
    {
        GetCategory(expense.GetCategory())?.AddTransaction(expense);
    }

    public void AddIncome(Income income)
    {
        GetCategory(income.GetCategory())?.AddTransaction(income);
    }

    public void DisplayBudget()
    {
        Console.WriteLine("-------- Monthly Budget --------");

        foreach (Category category in categories)
        {
            double goal = category.GetLimit();
            double spent = category.GetTotalExpense();
            double remainingBudget = category.GetRemainingBudget();

            Console.WriteLine($"{category.GetName()}: Goal: {goal:C}, Spent: {spent:C}, Remaining: {remainingBudget:C}");
        }

        Console.WriteLine("--------------------------------");
    }

    private Category GetCategory(string name)
    {
        return categories.FirstOrDefault(cat => cat.GetName().Equals(name, StringComparison.OrdinalIgnoreCase));
    }
}