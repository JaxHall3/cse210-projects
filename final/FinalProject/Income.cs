public class Income : Transaction
{
    private new string category;

    // Constructor
    public Income(double amount, string reference, string category) : base(amount, reference, category)
    {
        this.category = category.ToLower();
    }

    public new string GetCategory()
    {
        return category;
    }
}