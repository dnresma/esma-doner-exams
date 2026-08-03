using Odev07_StepCounter.Models;

namespace Odev07_StepCounter;

class Program
{
    static void Main(string[] args)
    {
        StepCounter stepCounter = new StepCounter(8000);
        stepCounter.AddSteps(5000);
        Console.WriteLine($"Hedefe kalan: {stepCounter.DailyGoal - stepCounter.Steps}");
        stepCounter.AddSteps(4000);
        Console.WriteLine($"Hedefe kalan: {stepCounter.DailyGoal - stepCounter.Steps}");
        stepCounter.IsGoalReached();
    }
}
