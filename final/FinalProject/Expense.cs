public class Expense : Transaction
{
    public string Category { get; set; }

    public override decimal CalculateSummary()
    {
        return -Amount;
    }
}