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



class Program

{

    static void Main(string[] args)

    {

        // Список участниц

        // Список участниц

        List<Runner> runners = new List<Runner>

        {

            new Runner("Иванова", "Группа 1", "Петров", 115),

            new Runner("Петрова", "Группа 1", "Иванов", 130),

            new Runner("Смирнова", "Группа 2", "Сидоров", 125),

            new Runner("Кузнецова", "Группа 2", "Попов", 140),

            new Runner("Соколова", "Группа 1", "Михайлов", 110),

            new Runner("Попова", "Группа 2", "Алексеев", 135),

            new Runner("Лебедева", "Группа 1", "Федоров", 120),

            new Runner("Козлова", "Группа 2", "Николаев", 145),

            new Runner("Новикова", "Группа 1", "Волков", 118),

            new Runner("Морозова", "Группа 2", "Соловьёв", 132),

        };



        // Сортировка участниц по результату

        var sortedRunners = runners.OrderBy(r => r.GetResult()).ToList();



        Console.WriteLine("Фамилия\tГруппа\tПреподаватель\tРезультат\tНорматив");

        foreach (var runner in sortedRunners)

        {

            runner.DisplayInfo();

        }



        // Подсчёт участниц, выполнивших норматив

        int normativePassed = sortedRunners.Count(r => r.GetResult() <= 120);

        Console.WriteLine($"\nСуммарное количество участниц, выполнивших норматив: {normativePassed}");

    }

}



using System;

using System.Collections.Generic;

using System.Linq;



struct Team

{

    private string _name;

    private int _points;



    public Team(string name, int points)

    {

        _name = name;

        _points = points;

    }



    public int Points

    {

        get { return _points; }

    }



    public void DisplayInfo()

    {

        Console.WriteLine($"{_name} - Очки: {_points}");

    }

}



class Program

{

    static void Main(string[] args)

    {

        // Список команд первой группы

        List<Team> groupOne = new List<Team>

        {

            new Team("Команда A1", 10),

            new Team("Команда A2", 12),

            new Team("Команда A3", 8),

            new Team("Команда A4", 15),

            new Team("Команда A5", 7),

            new Team("Команда A6", 13),

            new Team("Команда A7", 9),

            new Team("Команда A8", 11),

            new Team("Команда A9", 6),

            new Team("Команда A10", 14),

            new Team("Команда A11", 5),

            new Team("Команда A12", 16),

        };



        // Список команд второй группы

        List<Team> groupTwo = new List<Team>

        {

            new Team("Команда B1", 11),

            new Team("Команда B2", 9),

            new Team("Команда B3", 17),

            new Team("Команда B4", 8),

            new Team("Команда B5", 12),

            new Team("Команда B6", 7),

            new Team("Команда B7", 15),

            new Team("Команда B8", 10),

            new Team("Команда B9", 13),

            new Team("Команда B10", 6),

            new Team("Команда B11", 14),

            new Team("Команда B12", 18),

        };



        // Отбор 6 лучших команд из каждой группы

        var topTeamsFromGroupOne = groupOne.OrderByDescending(team => team.Points).Take(6).ToList();

        var topTeamsFromGroupTwo = groupTwo.OrderByDescending(team => team.Points).Take(6).ToList();



        // Объединение списков лучших команд обеих групп и сортировка итогового списка

        var teamsInSecondStage = topTeamsFromGroupOne

            .Concat(topTeamsFromGroupTwo)

            .OrderByDescending(team => team.Points)

            .ToList();



        Console.WriteLine("Команды, прошедшие во второй этап соревнований:");

        foreach (var team in teamsInSecondStage)

        {

            team.DisplayInfo();

        }

    }

}


using System;

using System.Collections.Generic;

using System.Linq;



struct Student

{

    private string _name;

    private int[] _grades;



    public Student(string name, int[] grades)

    {

        _name = name;

        _grades = grades;

    }



    // Метод для расчета среднего балла

    public double CalculateAverageGrade() => _grades.Average();



    // Метод для проверки наличия двойки среди оценок

    public bool HasFailingGrade() => _grades.Contains(2);



    // Метод для вывода информации о студенте

    public void DisplayInfo()

    {

        Console.WriteLine($"{_name} - Средний балл: {CalculateAverageGrade():F2}");

    }

}



class Program

{

    static void Main(string[] args)

    {

        // Список студентов с оценками

        List<Student> students = new List<Student>

        {

            new Student("Иванов Иван", new int[] {5, 4, 3}),

            new Student("Петров Петр", new int[] {2, 3, 4}),

            new Student("Сидорова Мария", new int[] {4, 5, 5}),

            new Student("Смирнова Анна", new int[] {5, 5, 5})

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

