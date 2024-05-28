using System;
using System.IO;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = "Hello students ;)";
            string text1 = "2 и 30, -4";
            string[] tasks = { Task1(text), Task2(text1) };

            Console.WriteLine(tasks[0]); // Вывод результата первой задачи
            Console.WriteLine(tasks[1]); // Вывод результата второй задачи

            Task3();

            JsonIO jsonIO = new JsonIO();
            jsonIO.HandleJsonFiles(text, tasks[0], tasks[1]);
        }

        // Задание 1
        public static string Task1(string input)
        {
            char[] delimiters = new char[] { ' ', ';', '.', ',', '!', '?' };
            string[] words = SplitString(input, delimiters);
            for (int i = 0; i < words.Length; i++)
            {
                words[i] = char.ToUpper(words[i][0]) + words[i].Substring(1).ToLower();
            }
            return string.Join(", ", words);
        }

        // Задание 2
        public static string Task2(string input)
        {
            char[] delimiters = new char[] { ' ', ';', '.', ',', '!', '?' };
            string[] words = SplitString(input, delimiters);
            List<int> numbers = new List<int>();

            foreach (string word in words)
            {
                if (int.TryParse(word, out int number))
                {
                    numbers.Add(number);
                }
            }

            return string.Join(", ", numbers);
        }

        private static string[] SplitString(string input, char[] delimiters)
        {
            List<string> words = new List<string>();
            int start = 0, end;

            for (int i = 0; i <= input.Length; i++)
            {
                if (i == input.Length || Array.IndexOf(delimiters, input[i]) != -1)
                {
                    end = i;
                    if (end > start)
                    {
                        words.Add(input.Substring(start, end - start));
                    }
                    start = i + 1;
                }
            }

            return words.ToArray();
        }

        // Задание 3
        public static void Task3()
        {
            string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string folderPath = Path.Combine(desktopPath, "Answer");

            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }

            string filePath1 = Path.Combine(folderPath, "cw2_1.json");
            string filePath2 = Path.Combine(folderPath, "cw2_2.json");

            if (!File.Exists(filePath1))
            {
                File.Create(filePath1).Close();
            }

            if (!File.Exists(filePath2))
            {
                File.Create(filePath2).Close();
            }
        }
    }

    // Задание 4
    public class JsonIO
    {
        public void HandleJsonFiles(string input, string task1Output, string task2Output)
        {
            string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string folderPath = Path.Combine(desktopPath, "Answer");
            string filePath = Path.Combine(folderPath, "data.json");

            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }

            var data = new
            {
                Input = input,
                Task1Output = task1Output,
                Task2Output = ParseNumbers(task2Output)
            };
            if (File.Exists(filePath))
            {
                string jsonData = File.ReadAllText(filePath);
                var existingData = JsonConvert.DeserializeObject<object>(jsonData);
                Console.WriteLine(JsonConvert.SerializeObject(existingData, Formatting.Indented));
            }
            else
            {
                string jsonData = JsonConvert.SerializeObject(data, Formatting.Indented);
                File.WriteAllText(filePath, jsonData);
            }
        }

        private List<int> ParseNumbers(string numbersString)
        {
            string[] numberStrings = numbersString.Split(new string[] { ", " }, StringSplitOptions.None);
            List<int> numbers = new List<int>();

            foreach (string numberStr in numberStrings)
            {
                if (int.TryParse(numberStr, out int number))
                {
                    numbers.Add(number);
                }
            }

            return numbers;
        }
    }
}
