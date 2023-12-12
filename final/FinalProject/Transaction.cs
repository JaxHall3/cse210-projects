public class Transaction
{
    protected double amount;
    protected string reference;
    protected string category;

    public Transaction(double amount, string reference = "", string category = "")
    {
        this.amount = amount;
        this.reference = reference;
        this.category = category.ToLower();
    }

    public double GetAmount()
    {
        return amount;
    }

    public string GetReference()
    {
        return reference;
    }

    public string GetCategory()
    {
        return category;
    }
}