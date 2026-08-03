using System;

namespace Odev07_StepCounter.Models;

public class StepCounter
{
    public StepCounter(int dailyGoal)
    {
        DailyGoal = dailyGoal;
        Steps = steps;
    }
    private int dailyGoal;
    private int steps;
    public int DailyGoal 
    { 
        get { return dailyGoal; } 
        set
        {
            dailyGoal = 8000;
        } 
    }
    public int Steps 
    { 
        get { return steps; } 
        set 
        { 
            if(value < 0)
            {
                throw new ArgumentException("Adım sayısı negatif olamaz!");
            }
            steps = value; 
        } 
    }
  
   
    public void AddSteps(int count)
    {
        if(count > 0)
        {
            Steps += count;
            Console.WriteLine($"{count} adım eklendi. Toplam adım sayısı:{Steps} Hedefe kalan:{dailyGoal - steps}");
            Console.WriteLine("*******************");
            
        }
    }
    public bool IsGoalReached()
    {
        if (Steps >= dailyGoal)
        {
            Console.WriteLine($"{dailyGoal} hedefine ulaşıldı.");
            return true;
        }
        else
        {
            Console.WriteLine($"Henüz hedefe ulaşılamadı. Kalan:{dailyGoal - Steps}");
            return false;
        }
    }
}
