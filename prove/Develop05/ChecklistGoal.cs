// ChecklistGoal.cs
using System;

class ChecklistGoal : Goal
{
    private int targetCount;
    private int currentCount;

    public ChecklistGoal(string name, int value, int targetCount) : base(name, value)
    {
        this.targetCount = targetCount;
        currentCount = 0;
    }

    public override void Complete()
    {
        currentCount++;
        base.Complete();
        Console.WriteLine($"You recorded progress for the checklist goal: {GetName()} and earned {GetValue()} points.");

        if (currentCount == targetCount)
        {
            Console.WriteLine($"Congratulations! You completed the checklist goal: {GetName()} and earned a bonus of {GetValue()} points.");
        }
    }

    public override string ToString()
    {
        return $"[{(IsCompleted() ? "X" : " ")}] {GetName()} - Completed {currentCount}/{targetCount} times - Score: {GetValue()}";
    }
}