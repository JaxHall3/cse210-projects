using System;

public class Fraction
{
    private int numerator;
    private int denominator;

    // Constructors
    public Fraction()
    {
        numerator = 1;
        denominator = 1;
    }

    public Fraction(int top)
    {
        numerator = top;
        denominator = 1;
    }

    public Fraction(int top, int bottom)
    {
        numerator = top;
        if (bottom != 0)
        {
            denominator = bottom;
        }
        else
        {
            throw new ArgumentException("Denominator cannot be set to 0.");
        }
    }

    // Getter and Setter for the numerator
    public int Numerator
    {
        get { return numerator; }
        set { numerator = value; }
    }

    // Getter and Setter for the denominator
    public int Denominator
    {
        get { return denominator; }
        set
        {
            if (value != 0)
            {
                denominator = value;
            }
            else
            {
                throw new ArgumentException("Denominator cannot be set to 0.");
            }
        }
    }

    // Method to return the fractional representation as a string
    public string GetFractionString()
    {
        return $"{numerator}/{denominator}";
    }

    // Method to return the decimal representation as a double
    public double GetDecimalValue()
    {
        return (double)numerator / denominator;
    }
}