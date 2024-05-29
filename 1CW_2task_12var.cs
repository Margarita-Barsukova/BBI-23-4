// See https://aka.ms/new-console-template for more information
//2 номер 
using System;

abstract class Company
{
    public string Name { get; private set; }
    public Employee[] Employees { get; private set; }

    public Company(string name, Employee[] employees)
    {
        Name = name;
        Employees = employees;
    }

    public double CalculateAverageSalary()
    {
        double totalSalary = 0;
        foreach (var employee in Employees)
        {
            totalSalary += employee.Salary;
        }
        return totalSalary / Employees.Length;
    }

    public abstract bool CanHire(Employee employee);

    public void PrintInfo()
    {
        Console.WriteLine($"Company: {Name}");
        Console.WriteLine("Employees:");
        foreach (var employee in Employees)
        {
            Console.WriteLine(employee.ToString());
        }
        Console.WriteLine($"Average Salary: {CalculateAverageSalary():F2}");
        Console.WriteLine();
    }
}

class Employee
{
    public string Name { get; private set; }
    public int Age { get; private set; }
    public double Salary { get; private set; }
    public int Experience { get; private set; }

    public Employee(string name, int age, double salary, int experience)
    {
        Name = name;
        Age = age;
        Salary = salary;
        Experience = experience;
    }

    public override string ToString()
    {
        return $"{Name}, Age: {Age}, Salary: {Salary:F2}, Experience: {Experience} years";
    }
}

class ITCompany : Company
{
    public ITCompany(string name, Employee[] employees) : base(name, employees) { }

    public override bool CanHire(Employee employee)
    {
        return employee.Age <= 35;
    }
}

class IndustrialCompany : Company
{
    public IndustrialCompany(string name, Employee[] employees) : base(name, employees) { }

    public override bool CanHire(Employee employee)
    {
        return employee.Experience >= 5;
    }
}

class CompanyComparer : IComparer<Company>
{
    public int Compare(Company x, Company y)
    {
        if (x == null || y == null) return 0;
        return y.CalculateAverageSalary().CompareTo(x.CalculateAverageSalary());
    }
}

class Program
{
    static void Main()
    {
        Employee[] employees = new Employee[]
        {
            new Employee("John Doe", 30, 50000, 3),
            new Employee("Jane Smith", 40, 60000, 7),
            new Employee("Emily Davis", 25, 55000, 2),
            new Employee("Michael Brown", 50, 65000, 10),
            new Employee("Sarah Wilson", 28, 70000, 5)
        };

        ITCompany[] itCompanies = new ITCompany[]
        {
            new ITCompany("ITCompany A", employees),
            new ITCompany("ITCompany B", employees),
            new ITCompany("ITCompany C", employees),
            new ITCompany("ITCompany D", employees),
            new ITCompany("ITCompany E", employees)
        };

        IndustrialCompany[] industrialCompanies = new IndustrialCompany[]
        {
            new IndustrialCompany("IndustrialCompany A", employees),
            new IndustrialCompany("IndustrialCompany B", employees),
            new IndustrialCompany("IndustrialCompany C", employees),
            new IndustrialCompany("IndustrialCompany D", employees),
            new IndustrialCompany("IndustrialCompany E", employees)
        };

        SortCompanies(itCompanies);
        SortCompanies(industrialCompanies);

        Console.WriteLine("IT Companies Sorted by Average Salary:");
        foreach (var company in itCompanies)
        {
            company.PrintInfo();
        }

        Console.WriteLine("Industrial Companies Sorted by Average Salary:");
        foreach (var company in industrialCompanies)
        {
            company.PrintInfo();
        }

        Company[] allCompanies = new Company[itCompanies.Length + industrialCompanies.Length];
        itCompanies.CopyTo(allCompanies, 0);
        industrialCompanies.CopyTo(allCompanies, itCompanies.Length);
        SortCompanies(allCompanies);

        Console.WriteLine("All Companies Sorted by Average Salary:");
        foreach (var company in allCompanies)
        {
            company.PrintInfo();
        }
    }

    static void SortCompanies(Company[] companies)
    {
        for (int i = 0; i < companies.Length - 1; i++)
        {
            for (int j = i + 1; j < companies.Length; j++)
            {
                if (companies[j].CalculateAverageSalary() > companies[i].CalculateAverageSalary())
                {
                    var temp = companies[i];
                    companies[i] = companies[j];
                    companies[j] = temp;
                }
            }
        }
    }
}




