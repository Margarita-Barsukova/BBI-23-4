//1 уровень 
using System;
using System.Collections.Generic;
using System.Linq;

// Определение структуры Runner
struct Runner
{
    private string _lastName;
    private string _group;
    private string _teacherLastName;
    private double _result; // Время в секундах

    public Runner(string lastName, string group, string teacherLastName, double result)
    {
        _lastName = lastName;
        _group = group;
        _teacherLastName = teacherLastName;
        _result = result;
    }

    // Метод для вывода информации о бегуне
    public void DisplayInfo()
    {
        string normative = _result <= 120 ? "Выполнен" : "Не выполнен";
        Console.WriteLine($"{_lastName,-10}\t{_group,-10}\t{_teacherLastName,-12}\t{_result,-10}\t{normative}");
    }

    // Методы доступа для полей, если они понадобятся вне структуры
    public double GetResult() => _result;
}

// Абстрактный класс для забега
abstract class Race
{
    protected List<Runner> runners;

    public Race(List<Runner> runners)
    {
        this.runners = runners;
    }

    public abstract void ConductRace();
    public abstract void DisplayResults();
}

// Класс для забега на 100м
class Race100m : Race
{
    public Race100m(List<Runner> runners) : base(runners) { }

    public override void ConductRace()
    {
        // Сортировка участников по результату
        runners = runners.OrderBy(r => r.GetResult()).ToList();
    }

    public override void DisplayResults()
    {
        Console.WriteLine("Результаты забега на 100м:");
        Console.WriteLine("Фамилия\t\tГруппа\t\tПреподаватель\tРезультат\tНорматив");
        foreach (var runner in runners)
        {
            runner.DisplayInfo();
        }
    }
}

// Класс для забега на 500м
class Race500m : Race
{
    public Race500m(List<Runner> runners) : base(runners) { }

    public override void ConductRace()
    {
        // Сортировка участников по результату
        runners = runners.OrderBy(r => r.GetResult()).ToList();
    }

    public override void DisplayResults()
    {
        Console.WriteLine("Результаты забега на 500м:");
        Console.WriteLine("Фамилия\t\tГруппа\t\tПреподаватель\tРезультат\tНорматив");
        foreach (var runner in runners)
        {
            runner.DisplayInfo();
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Список участников
        List<Runner> runners100m = new List<Runner>
        {
            new Runner("Иванова", "Группа 1", "Петров", 15),
            new Runner("Петрова", "Группа 1", "Иванов", 13),
            new Runner("Смирнова", "Группа 2", "Сидоров", 12),
            new Runner("Кузнецова", "Группа 2", "Попов", 14),
            new Runner("Соколова", "Группа 1", "Михайлов", 10),
        };

        List<Runner> runners500m = new List<Runner>
        {
            new Runner("Попова", "Группа 2", "Алексеев", 135),
            new Runner("Лебедева", "Группа 1", "Федоров", 120),
            new Runner("Козлова", "Группа 2", "Николаев", 145),
            new Runner("Новикова", "Группа 1", "Волков", 118),
            new Runner("Морозова", "Группа 2", "Соловьёв", 132),
        };

        // Создание объектов забегов
        Race race100m = new Race100m(runners100m);
        Race race500m = new Race500m(runners500m);

        // Проведение забегов
        race100m.ConductRace();
        race500m.ConductRace();
        // Вывод результатов
        race100m.DisplayResults();
        race500m.DisplayResults();
    }
}



//2 уровень 
using System;
using System.Collections.Generic;
using System.Linq;

// Определение класса Person, представляющего человека
class Person
{
    protected string _firstName;  // Имя человека
    protected string _lastName;   // Фамилия человека

    // Конструктор для инициализации имени и фамилии человека
    public Person(string firstName, string lastName)
    {
        _firstName = firstName;
        _lastName = lastName;
    }

    // Свойство для получения полного имени
    public string FullName => $"{_lastName} {_firstName}";
}

// Определение класса Student, представляющего учащегося, наследующегося от Person
class Student : Person
{
    private static int _idCounter = 0; // Счетчик для генерации уникальных идентификаторов
    private int _studentId;            // Идентификатор студента
    private int[] _grades;             // Массив оценок студента

    // Конструктор для инициализации имени, фамилии, оценок и генерации уникального идентификатора
    public Student(string firstName, string lastName, int[] grades) : base(firstName, lastName)
    {
        _studentId = ++_idCounter;
        _grades = grades;
    }

    // Метод для расчета среднего балла студента
    public double CalculateAverageGrade() => _grades.Average();

    // Метод для проверки наличия двойки среди оценок
    public bool HasFailingGrade() => _grades.Contains(2);

    // Свойство для получения идентификатора студента
    public int StudentId => _studentId;

    // Метод для вывода информации о студенте
    public void DisplayInfo()
    {
        Console.WriteLine($"ФИО: {FullName}, ИД: {_studentId}, Средний балл: {CalculateAverageGrade():F2}");
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Список студентов с оценками
        List<Student> students = new List<Student>
        {
            new Student("Иван", "Иванов", new int[] {5, 4, 3}),
            new Student("Петр", "Петров", new int[] {2, 3, 4}),
            new Student("Мария", "Сидорова", new int[] {4, 5, 5}),
            new Student("Анна", "Смирнова", new int[] {5, 5, 5})
        };

        // Фильтрация студентов, сдавших все экзамены, и сортировка по среднему баллу
        var successfulStudents = students.Where(s => !s.HasFailingGrade())
                                          .OrderByDescending(s => s.CalculateAverageGrade())
                                          .ToList();

        Console.WriteLine("Список студентов, успешно сдавших экзамены:");
        foreach (var student in successfulStudents)
        {
            student.DisplayInfo();
        }
    }
}


//3 уровень 
using System;
using System.Collections.Generic;
using System.Linq;

// Базовый класс для футбольных команд
abstract class FootballTeam
{
    public string Name { get; private set; }
    public int Points { get; private set; }
    public string Gender { get; private set; }

    protected FootballTeam(string name, int points, string gender)
    {
        Name = name;
        Points = points;
        Gender = gender;
    }

    public void DisplayInfo()
    {
        Console.WriteLine($"{Name} ({Gender}) - Очки: {Points}");
    }
}

// Класс для женских футбольных команд
class WomenFootballTeam : FootballTeam
{
    public WomenFootballTeam(string name, int points)
        : base(name, points, "женская команда") { }
}

// Класс для мужских футбольных команд
class MenFootballTeam : FootballTeam
{
    public MenFootballTeam(string name, int points)
        : base(name, points, "мужская команда") { }
}

class Program
{
    static void Main(string[] args)
    {
        // Список женских футбольных команд
        List<FootballTeam> womenTeams = new List<FootballTeam>
        {
            new WomenFootballTeam("Команда W1", 10),
            new WomenFootballTeam("Команда W2", 12),
            new WomenFootballTeam("Команда W3", 8),
            new WomenFootballTeam("Команда W4", 15),
            new WomenFootballTeam("Команда W5", 7),
            new WomenFootballTeam("Команда W6", 13),
            new WomenFootballTeam("Команда W7", 9),
            new WomenFootballTeam("Команда W8", 11),
            new WomenFootballTeam("Команда W9", 6),
            new WomenFootballTeam("Команда W10", 14),
            new WomenFootballTeam("Команда W11", 5),
            new WomenFootballTeam("Команда W12", 16),
        };

        // Список мужских футбольных команд
        List<FootballTeam> menTeams = new List<FootballTeam>
        {
            new MenFootballTeam("Команда M1", 11),
            new MenFootballTeam("Команда M2", 9),
            new MenFootballTeam("Команда M3", 17),
            new MenFootballTeam("Команда M4", 8),
            new MenFootballTeam("Команда M5", 12),
            new MenFootballTeam("Команда M6", 7),
            new MenFootballTeam("Команда M7", 15),
            new MenFootballTeam("Команда M8", 10),
            new MenFootballTeam("Команда M9", 13),
            new MenFootballTeam("Команда M10", 6),
            new MenFootballTeam("Команда M11", 14),
            new MenFootballTeam("Команда M12", 18),
        };

        // Отбор 6 лучших женских команд
        var topWomenTeams = womenTeams.OrderByDescending(team => team.Points).Take(6).ToList();

        // Отбор 6 лучших мужских команд
        var topMenTeams = menTeams.OrderByDescending(team => team.Points).Take(6).ToList();

        // Объединение списков лучших команд и сортировка итогового списка
        var topTeams = topWomenTeams.Concat(topMenTeams)
                                    .OrderByDescending(team => team.Points)
                                    .ToList();

        // Вывод итогового списка команд
        Console.WriteLine("Топ 12 футбольных команд:");
        foreach (var team in topTeams)
        {
            team.DisplayInfo();
        }
    }
}
