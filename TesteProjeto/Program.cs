using System;
using System.Globalization;
using TesteProjeto.Repository;
using TesteProjeto.Repository.Enum;

namespace TesteProjeto
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("ENTER DEPARTAMENT'S NAME: ");
            string depName = Console.ReadLine();

            Console.WriteLine("\nENTER WORKER DATA");
            Console.Write("NAME: ");
            string name = Console.ReadLine();

            Console.Write("LEVEL (Ex: Junior, MidLevel, Senior): ");
            WorkerLevel level = Enum.Parse<WorkerLevel>(Console.ReadLine());

            Console.Write("BASE SALARY R$ ");
            double baseSalary = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

            Department dept = new Department(depName);
            Worker worker = new Worker(name, level, baseSalary, dept);

            Console.Write("\nHOW MANY CONTACTS TO THIS WORKER? ");
            int n = int.Parse(Console.ReadLine());

            for (int i = 1; i <= n; i++)
            {
                Console.WriteLine($"ENTER #{i} CONTACT DATA: ");
                Console.Write("DATE (Ex: DD/MM/YYYY): ");
                DateTime date = DateTime.Parse(Console.ReadLine());

                Console.Write("VALUE PE HOUR: ");
                double valuePeHour = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

                Console.Write("DURATION (HOURS) ");
                int hours = int.Parse(Console.ReadLine());

                HourContact contact = new HourContact(date, valuePeHour, hours);
                worker.AddContact(contact);
            }

            Console.WriteLine("\nENTER MONTH AND YEAR TO CALCULATE INCOME (MM/YYYY): ");
            string monthAndYear = Console.ReadLine();
            int month = int.Parse(monthAndYear.Substring(0, 2));
            int year = int.Parse(monthAndYear.Substring(3));

            Console.WriteLine("Name: " + worker.Name
                     + "\nDepartament: " + worker.Department.Name
                     + "\nIncome for " + monthAndYear + ": " + worker.Income(year, month));
        }
    }
}
