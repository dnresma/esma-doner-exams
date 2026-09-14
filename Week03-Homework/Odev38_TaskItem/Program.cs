using Odev38_TaskItem.Models;

namespace Odev38_TaskItem;

class Program
{
    static void Main(string[] args)
    {
        TaskItem taskItem1 = new TaskItem("H1 etiket değişimi", "Esma Döner", DateTime.Now.AddDays(5));

        TaskItem taskItem2 = new TaskItem("index.html navbar düzenlemesi", "Nazlı Onur","Yüksek", DateTime.Now.AddDays(10), false);

        TaskItem taskItem3 = new TaskItem("personal.html footer düzenlenmesi", "Kerem Türk","Yüksek", DateTime.Now.AddDays(7), false);

        TaskItem[] taskitems = {taskItem1, taskItem2, taskItem3};

        foreach (var items in taskitems)
        {
            if (items.Priority == "Yüksek")
            {
                Console.WriteLine($"Başlık: {items.Title}");
                Console.WriteLine($"Atandığı kişi: {items.AssignedTo}");
                Console.WriteLine($"Son tarih: {items.DueDate}");
                Console.WriteLine($"Öncelik: {items.Priority}");
                Console.WriteLine($"Durum: {items.IsCompleted}");
                Console.WriteLine("-----------------------------");
            }
        }
    }
}
