// EternalGoal.cs
using System;

class EternalGoal : Goal
{
    public EternalGoal(string name, int value) : base(name, value) { }

    // Eternal goals are never truly completed
    public override void Complete()
    {
        base.Complete();
        Console.WriteLine($"You recorded progress for the eternal goal: {GetName()} and earned {GetValue()} points.");
    }
}