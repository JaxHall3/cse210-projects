public class Income : Transaction
{
    private string category;

    // Constructor
    public Income(double amount, string reference, string category)
        : base(amount, reference)
    {
        this.category = category.ToLower();
    }

    public string GetCategory()
    {
        return category;
    }
}