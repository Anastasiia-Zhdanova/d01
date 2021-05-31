using System;
using System.Collections.Generic;
using System.Globalization;
using d01_ex01.Events;

CultureInfo.DefaultThreadCurrentCulture = new CultureInfo("en-US");

List<Task> tasks = new List<Task>();

while (true)
{
    var oper = Console.ReadLine();
    if (oper == "add")
    {
        Console.WriteLine("Введите заголовок");
        var title = Console.ReadLine();
        if (title == "")
        {
            Console.WriteLine("Ошибка ввода. Проверьте входные данные и повторите запрос.");
            continue;
        }
        Console.WriteLine("Введите описание");
        var summary = Console.ReadLine();
        Console.WriteLine("Введите срок");
        var dueDate = Console.ReadLine();

        DateTime dateDate = DateTime.Now;
        DateTime? nulableDate = null;
        if (dueDate != "" && DateTime.TryParse(dueDate, out dateDate) == false)
        {
            Console.WriteLine("Ошибка ввода. Проверьте входные данные и повторите запрос.");
            continue;
        }
        if (dueDate != "")
        {
            nulableDate = dateDate;
        }
        Console.WriteLine("Введите тип");
        var type = Console.ReadLine();
        if (type == "" || Enum.IsDefined(typeof(TaskType), type) == false)
        {
            Console.WriteLine("Ошибка ввода. Проверьте входные данные и повторите запрос.");
            continue;
        }
        var enumType = (TaskType)Enum.Parse(typeof(TaskType), type);
        
        Console.WriteLine("Установите приоритет");
        var priority = Console.ReadLine();
        if (priority != "" && Enum.IsDefined(typeof(TaskPriority), priority) == false)
        {
            Console.WriteLine("Ошибка ввода. Проверьте входные данные и повторите запрос.");
            continue;
        }
        var enumPriority = priority!="" ? (TaskPriority?)Enum.Parse(typeof(TaskPriority), priority) : null;
        var add = new Task(title, summary, enumType, nulableDate, enumPriority);
        tasks.Add(add);
        Console.WriteLine(add);
    }
    else if (oper == "list")
    {
        if (tasks.Count == 0)
        {
            Console.WriteLine("Список задач пока пуст.");
        }
        foreach (var i in tasks)
        {
            Console.WriteLine(i);
        }
    }
    else if (oper == "done")
    {
        Console.WriteLine("Введите заголовок");
        var title = Console.ReadLine();
        if (title == "")
        {
            Console.WriteLine("Ошибка ввода. Задача с таким заголовком не найдена.");
            continue;
        }

        bool foundTask = false;
        foreach (var task in tasks)
        {
            if (task.Title == title)
            {
                task.Done();
                foundTask = true;
            }
        }

        if (foundTask != true)
        {
            Console.WriteLine("Ошибка ввода. Задача с таким заголовком не найдена.");
        }
    }
    else if (oper == "wontdo")
    {
        Console.WriteLine("Введите заголовок");
        var title = Console.ReadLine();
        if (title == "")
        {
            Console.WriteLine("Ошибка ввода. Задача с таким заголовком не найдена.");
            continue;
        }
        
        bool foundTask = false;
        foreach (var task in tasks)
        {
            if (task.Title == title)
            {
                task.WontDo();
                foundTask = true;
            }
        }

        if (foundTask != true)
        {
            Console.WriteLine("Ошибка ввода. Задача с таким заголовком не найдена.");
        }
    }
    else if (oper == "q" || oper == "quit")
    {
        return;
    }
}