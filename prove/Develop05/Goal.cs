// Goal.cs
using System;

class Goal
{
    private string name;
    private int value;
    private bool completed;

    public Goal(string name, int value)
    {
        this.name = name;
        this.value = value;
        completed = false;
    }

    public virtual void Complete()
    {
        completed = true;
    }

    public int GetValue()
    {
        return completed ? value : 0;
    }

    public bool IsCompleted()
    {
        return completed;
    }

    public string GetName()
    {
        return name;
    }

    public override string ToString()
    {
        return $"[{(completed ? "X" : " ")}] {name} - Score: {GetValue()}";
    }
}