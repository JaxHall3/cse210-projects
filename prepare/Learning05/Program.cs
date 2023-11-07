using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        List<Shape> shapes = new List<Shape>();

        shapes.Add(new Square("Red", 5));
        shapes.Add(new Rectangle("Green", 4, 6));
        shapes.Add(new Circle("Blue", 3));

        foreach (var shape in shapes)
        {
            Console.WriteLine($"Shape: {shape.GetType().Name}, Color: {shape.Color}, Area: {shape.GetArea():F2}");
        }
    }
}