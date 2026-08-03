using System;

namespace Odev05_GradeBook.Models;

public class GradeBook
{
    public GradeBook(string studentName)
    {
        StudentName = studentName;
        ExamCount = 0;
        TotalScore = 0;
    }
    private string studentName = string.Empty;
    private int examCount;
    private int totalScore;
    public string StudentName 
    { 
        get { return studentName; } 
        set { studentName = value; } 
    }
    public int ExamCount 
    { 
        get { return examCount;}
        private set { examCount = value; }
    }
    public int TotalScore 
    { 
        get { return totalScore;} 
        private set { totalScore = value; }
    }

    public void AddExamScore(int score)
    {
        if(score < 0 || score > 100)
        {
            throw new ArgumentOutOfRangeException("Not 0-100 arasında olmalıdır!");
        }
        else
        {
            TotalScore += score;
            ExamCount++;
            Console.WriteLine($"{StudentName} isimli öğrenci için {score} notu eklendi. Toplam {ExamCount} adet notu girilmiştir.");
        }
    }
    public double GetAverage(int score1, int score2, int score3, int score4)
    {
        if(ExamCount == 0)
        {
            return 0;
        }
        else
        {
            Console.WriteLine($"{StudentName} isimli öğrencinin ortalaması:{(TotalScore/ExamCount)}");
            return TotalScore/ExamCount;
            
            
        }
    }
}
