public class Income : Transaction
{
    public override decimal CalculateSummary()
    {
        return Amount;
    }
}