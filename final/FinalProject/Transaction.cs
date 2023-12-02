using System;

public class Transaction
{
    public decimal Amount { get; set; }
    public DateTime Date { get; set; }
    public string Description { get; set; }

    public virtual decimal CalculateSummary()
    {
        return Amount;
    }
}