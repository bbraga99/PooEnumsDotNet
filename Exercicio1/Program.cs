using Exercicio1.Entities;
using Exercicio1.Entities.Enums;
using System;
using System.Globalization;

namespace Course
{
    class Program
    {
        public static void Main(string[] args)
        {
            Console.Write("Enter department's name: ");
            string? deptName = Console.ReadLine();

            Console.WriteLine("Enter worker data: ");
            Console.Write("Name: ");
            string? name = Console.ReadLine();
            Console.Write("Level: ");
            WorkerLevel level = Enum.Parse<WorkerLevel>(Console.ReadLine());
            Console.Write("Base Salary: ");
            double baseSalary = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

            Department dept = new(deptName);
            Worker worker = new(name,level,baseSalary,dept);

            Console.WriteLine("How many contracts to this worker?");
            int qtd = int.Parse(Console.ReadLine());

            for(int i = 0; i < qtd; i++)
            {
                Console.WriteLine($"Enter #{i+1} contract data: ");
                Console.Write("Date(DD/MM/YYYY): ");
                DateTime date = DateTime.Parse(Console.ReadLine());
                Console.Write("Value per hour: ");
                double value = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                Console.Write("Duration (hours): ");
                int duration = int.Parse(Console.ReadLine());

                HourContract hourContract = new HourContract(date,value,duration);
                worker.AddContract(hourContract);   
            }

            Console.WriteLine("Enter month and year to calculate income(MM/YYYY");
            string monthAndYear = Console.ReadLine();
            int month = int.Parse(monthAndYear.Substring(0, 2));
            int year = int.Parse(monthAndYear.Substring(3));
            Console.WriteLine($"Name: {worker.Name} ");
            Console.WriteLine($"Department: {worker.Department.Name}");
            Console.WriteLine($"Income: {worker.Income(year, month)}");
        }
    }
}   