public class Expense : Transaction
{
    public Expense(double amount, string reference = "", string category = "") : base(amount, reference, category)
    {
    }
}