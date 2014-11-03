using System;

public class ExamResult
{
    public int Grade { get; private set; }
    public int MinGrade { get; private set; }
    public int MaxGrade { get; private set; }
    public string Comments { get; private set; }

    public ExamResult(int grade, int minGrade, int maxGrade, string comments)
    {
        if (grade < 0)
        {
            throw new ArgumentOutOfRangeException("Grade can not be negative number!");
        }
        if (minGrade < 0)
        {
            throw new ArgumentOutOfRangeException("Minimum grade cannot be negative number!");
        }
        if (maxGrade <= minGrade)
        {
            throw new ArgumentException("The maximum grade can not be greater than the minimum grade");
        }
        if (comments == null || comments == "")
        {
            throw new ArgumentNullException("Comments can not be empty!");
        }

        this.Grade = grade;
        this.MinGrade = minGrade;
        this.MaxGrade = maxGrade;
        this.Comments = comments;
    }
}
