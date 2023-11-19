// GoalTracker.cs
using System;
using System.Collections.Generic;

class GoalTracker
{
    private List<Goal> goals = new List<Goal>();

    public void AddGoal(Goal goal)
    {
        goals.Add(goal);
    }

    public void RecordEvent(int goalIndex)
    {
        if (goalIndex >= 0 && goalIndex < goals.Count)
        {
            goals[goalIndex].Complete();
        }
        else
        {
            Console.WriteLine("Invalid goal index.");
        }
    }

    public void DisplayGoals()
    {
        Console.WriteLine("\nCurrent Goals:");
        foreach (var goal in goals)
        {
            Console.WriteLine(goal);
        }

        int totalScore = CalculateTotalScore();
        Console.WriteLine($"\nTotal Score: {totalScore}\n");
    }

    private int CalculateTotalScore()
    {
        int totalScore = 0;
        foreach (var goal in goals)
        {
            totalScore += goal.GetValue();
        }
        return totalScore;
    }
}