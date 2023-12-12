using System;

public class BudgetTrackerApp
{
    private Report monthlyReport;
    private Budget monthlyBudget;
    private UserInterface ui;

    public BudgetTrackerApp()
    {
        monthlyReport = new Report();
        monthlyBudget = new Budget();
        ui = new UserInterface(monthlyReport, monthlyBudget);
    }

    public void Run()
    {
        while (true)
        {
            ui.DisplayMainMenu();
            int choice = ui.GetUserChoice();

            switch (choice)
            {
                case 1:
                    ui.AddIncome();
                    break;
                case 2:
                    ui.AddExpense();
                    break;
                case 3:
                    ui.DisplayReport();
                    break;
                case 4:
                    ui.AddRemoveBudgetGoal();
                    break;
                case 5:
                    ui.DisplayBudget();
                    break;
                case 6:
                    ui.Exit();
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }
    }
}