public class Transaction
{
    // Attributes
    protected double amount;
    protected string reference;

    // Constructor
    public Transaction(double amount, string reference)
    {
        this.amount = amount;
        this.reference = reference;
    }

    // Getters
    public double GetAmount()
    {
        return amount;
    }

    public string GetReference()
    {
        return reference;
    }
}