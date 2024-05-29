using System; // Подключение пространства имен System, содержащего базовые типы и функциональность для взаимодействия с операционной системой
using System.Collections.Generic; // Подключение пространства имен System.Collections.Generic, предоставляющего обобщенные коллекции, такие как List
using System.Linq; // Подключение пространства имен System.Linq, предоставляющего методы для запросов к коллекциям (LINQ)

// Определение структуры Runner для хранения информации об участнике марафона
struct Runner
{
    private string lastName; // Фамилия участника  
    private string group; // Группа, к которой принадлежит участник
    private string teacherLastName; // Фамилия преподавателя
    private double result; // Результат участника (время в секундах)
    public double Result { get { return result; } set { result = value; } }//публичный метод для поля резалт чтобы получить или присвоить значение вне структуры 

    // Конструктор для инициализации полей структуры
    public Runner(string lastName, string group, string teacherLastName, double result)
    {
        this.lastName = lastName; // Инициализация фамилии
        this.group = group; // Инициализация группы
        this.teacherLastName = teacherLastName; // Инициализация фамилии преподавателя
        this.result = result; // Инициализация результата (времени)
    } 
    public void Display()
    {
        Console.WriteLine($"Фамилия: {lastName}, Группа: {group}, Преподаватель: {teacherLastName}, Результат: {result}");
    }
    public static void InsertionSort(Runner[] arr)
    {
        for (int i = 1; i < arr.Length; i++)
        {
            Runner val = arr[i];// берем элемент начиная со второго 
             for (int j = i - 1; j >= 0;)// идем влево от выбранного элемента 
            {
                if (val.Result < arr[j].Result)// проверяется меньше ли выбранный эжлемент текущего 
                {
                    arr[j + 1] = arr[j];//меняет пока меньше текущего(3 строки)
                    j--;
                    arr[j + 1] = val;
                }
                else
                {
                    break;// переход к следующему 
                }
            }
        }
    }
}

class Program // Определение класса Program
{
    static void Main(string[] args) // Главный метод программы
    {
        // Список участников марафона с их результатами
        Runner[] runners = new Runner[]
        {
            new Runner("Иванова", "Группа 1", "Петров", 130), // Создание и добавление участника марафона в список
            new Runner("Петрова", "Группа 1", "Иванов", 115), // Создание и добавление участника марафона в список
            // Можно добавить больше участников здесь
        };

        Runner.InsertionSort(runners);

        // Вывод заголовка таблицы с информацией об участниках
        Console.WriteLine("Фамилия\tГруппа\tПреподаватель\tРезультат\tНорматив");

        // Цикл для вывода информации о каждом участнике марафона
        foreach (var runner in runners)
        {
            // Определение выполнен ли норматив по времени для текущего участника
            string normative = runner.Result <= 120 ? "Выполнен" : "Не выполнен";
            // Вывод информации о текущем участнике, включая его фамилию, группу, преподавателя, результат и выполнение норматива
            runner.Display();
        }

        // Подсчет количества участников, выполнивших норматив
        int normativePassed = runners.Count(r => r.Result <= 120);
        // Вывод общего количества участников, выполнивших норматив
        Console.WriteLine($"\nСуммарное количество участников, выполнивших норматив: {normativePassed}");
    }
}
