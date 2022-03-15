using System;
using Course.Entities.Enums;
using Course.Entities;
using System.Globalization;

namespace Course
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter department's name: ");
            string deptName = Console.ReadLine(); //departamento

            Console.WriteLine("Enter worker data:");
            Console.Write("Name: ");
            string name = Console.ReadLine();

            Console.Write("Level (Junior/MidLevel/Senior): ");
            WorkerLevel level = Enum.Parse<WorkerLevel>(Console.ReadLine()); //enum

            Console.Write("Base salary: ");
            double baseSalary = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture); // salario base

            Departament dept = new Departament(deptName);
            Worker worker = new Worker(name, level, baseSalary, dept);
            
            Console.Write("How many contracts to this worker? ");
            int n = int.Parse(Console.ReadLine());

            for(int i = 1; i <= n; i++)
            {
                Console.WriteLine($"Enter #{i} contract data:");
                Console.Write("Date (DD/MM/YYYY): ");
                DateTime date = DateTime.Parse(Console.ReadLine()); //data de contrato

                Console.Write("Value per hour: "); //valor por hora
                double valuePerHour = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

                Console.Write("Duration (hours): "); //Quantidade de horas
                int hours = int.Parse(Console.ReadLine());

                HourContract hourContract = new HourContract(date, valuePerHour, hours); // instanciando um contrato
                worker.AddContract(hourContract); // adicionando um contrato ao um trabalhador

            }

            Console.Write("Enter month and year to calculate income (MM/YYYY): ");
            string monthAndYear = Console.ReadLine(); //Ler mes e ano
            int month = int.Parse(monthAndYear.Substring(0, 2)); // fazendo uma subString para pegar o mes
            int year = int.Parse(monthAndYear.Substring(3)); // fazendo uma subString para pegar o ano

            Console.WriteLine("Name: " + worker.Name);

            Console.WriteLine("Departament: " + worker.Departament.Name);

            Console.WriteLine($"Income for {monthAndYear}: {worker.Income(year,month)}");


        }
    }
}
