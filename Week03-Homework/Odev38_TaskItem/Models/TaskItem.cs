using System;
using System.Text;

namespace Odev38_TaskItem.Models;

public class TaskItem
{
    public TaskItem(string? title, string? assignedTo, DateTime dueDate)
    {
        Title = title;
        AssignedTo = assignedTo;
        DueDate = dueDate;
        Priority ="Normal";
    }

    public TaskItem(string? title, string? assignedTo, string? priority, DateTime dueDate, bool isCompleted)
    {
        Title = title;
        AssignedTo = assignedTo;
        Priority = priority;
        DueDate = dueDate;
        IsCompleted = isCompleted;
    }

    public string? Title { get; set; }
    public string? AssignedTo { get; set; }
    public string? Priority { get; set; }
    public DateTime DueDate { get; set; }
    public bool IsCompleted { get; set; }
}
