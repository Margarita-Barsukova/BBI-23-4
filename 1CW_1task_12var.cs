// See https://aka.ms/new-console-template for more information
//1 номер 
using System;

namespace EmployeeApp
{
    struct Employee
    {
        public string Name { get; }
        public int Id { get; }
        public int Age { get; }
        public int YearOfJoining { get; }
        public double Salary { get; }

        private static int nextId = 1;

        public Employee(string name, int age, int yearOfJoining, double salary)
        {
            Name = name;
            Id = nextId++;
            Age = age;
            YearOfJoining = yearOfJoining;
            Salary = salary;
        }

        public void PrintInfo()
        {
            Console.WriteLine($"ID: {Id}, Name: {Name}, Age: {Age}, Year Of Joining: {YearOfJoining}, Salary: {Salary}");
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Employee[] employees = new Employee[5];

            employees[0] = new Employee("John Doe", 30, 2015, 50000);
            employees[1] = new Employee("Jane Smith", 28, 2016, 52000);
            employees[2] = new Employee("Jim Brown", 35, 2010, 55000);
            employees[3] = new Employee("Jake White", 40, 2005, 60000);
            employees[4] = new Employee("Jill Black", 32, 2013, 53000);

            Console.WriteLine("ID\tName\t\tAge\tYear Of Joining\tSalary");

            foreach (Employee employee in employees)
            {
                employee.PrintInfo();
            }
        }
    }
}















