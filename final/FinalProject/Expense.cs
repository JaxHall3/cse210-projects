public class Expense : Transaction
{
    private string category;

    // Constructor
    public Expense(double amount, string reference, string category)
        : base(amount, reference)
    {
        this.category = category.ToLower();
    }

    public string GetCategory()
    {
        return category;
    }
}