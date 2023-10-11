using System;

class Program
{
    static void Main()
    {
        // Create instances using different constructors.
        Fraction fraction1 = new Fraction();
        Fraction fraction2 = new Fraction(5);
        Fraction fraction3 = new Fraction(3,4);
        Fraction fraction4 = new Fraction(1,3);

        Console.WriteLine("Fraction 1 - Fractional Representation: " + fraction1.GetFractionString());
        Console.WriteLine("Fraction 1 - Decimal Representation: " + fraction1.GetDecimalValue());

        Console.WriteLine("Faction 2 - Fractional Representation: " + fraction2.GetFractionString());
        Console.WriteLine("Fraction 2 - Decimal Representation: " + fraction2.GetDecimalValue());

        Console.WriteLine("Fraction 3 - Fractional Representation " + fraction3.GetFractionString());
        Console.WriteLine("Fraction 3 - Decimal Representation " + fraction3.GetDecimalValue());

        Console.WriteLine("Fraction 4 - Fractional Representation: " + fraction4.GetFractionString());
        Console.WriteLine("Fraction 4 - Decimal Representation: " + fraction4.GetDecimalValue());
    }
}