// SimpleGoal.cs
using System;

class SimpleGoal : Goal
{
    public SimpleGoal(string name, int value) : base(name, value) { }

    public override void Complete()
    {
        base.Complete();
        Console.WriteLine($"Congratulations! You completed the simple goal: {GetName()} and earned {GetValue()} points.");
    }
}