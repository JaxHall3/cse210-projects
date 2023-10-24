public class WritingAssignment : Assignment
{
    public string _title;

    public WritingAssignment(string studentName, string topic, string title)
        : base(studentName, topic)
        {
            _title = title;
        }

    public string GetWritingInformation()
    {
        return $"{_title} by {_GetStudentName()}";
    }

    public string _GetStudentName()
    {
        return GetSummary().Split(" - ")[0];
    }
}