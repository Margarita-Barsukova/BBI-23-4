
using System;
using System.Collections.Generic;
using System.Text.Json;

struct Task
{
    public string Text { get; }

    public Task(string text)
    {
        Text = text;
    }

    public override string ToString()
    {
        return $"Task: {Text}";
    }
}

static class JsonHelper
{
    public static string Serialize<T>(T obj)
    {
        return JsonSerializer.Serialize(obj);
    }

    public static T Deserialize<T>(string json)
    {
        return JsonSerializer.Deserialize<T>(json);
    }
}

class Program
{
    static void Main()
    {
        string text = "Hello students ;)";
        Task[] tasks = { new Task(text), new Task(text) };

        Console.WriteLine(tasks[0]);
        Console.WriteLine(tasks[1]);

      
        string serializedTasks = JsonHelper.Serialize(tasks);
        Console.WriteLine(serializedTasks);

        Task[] deserializedTasks = JsonHelper.Deserialize<Task[]>(serializedTasks);
        foreach (var task in deserializedTasks)
        {
            Console.WriteLine(task);
        }
    }
} 





