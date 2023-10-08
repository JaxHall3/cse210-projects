internal class Program
{
    private static void Main(string[] args)
    {
        // Create a new job instance named job1.
        Job job1 = new Job("ABC Inc.", "Software Engineer", 2015, 2018);

        // Set the member variables using dot notation.
        job1._company = "XYZ Corp"; // Updating the company for job1

        // Verify that you can display the company of this job.
        Console.WriteLine("Company for job1: " + job1._company);

        // Create a second job, set its variables.
        Job job2 = new Job("DEF Ltd.", "Data Analyst", 2019, 2021);

        // Display the company for the second job.
        Console.WriteLine("Company for job2: " + job2._company);

        // Test the Display method of the Job class.
        job1.Display();
        job2.Display();
    }
}
