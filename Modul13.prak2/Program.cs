using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace Modul13.prak2
{
    internal class Program
    {
        static void Main()
        {
            List<int> numbers = new List<int> { 1, 5, 3, 7, 2, 8, 6 };

            // Находим второе максимальное значение
            int secondMax = numbers.OrderByDescending(n => n).Distinct().Skip(1).FirstOrDefault();
            int secondMaxIndex = numbers.IndexOf(secondMax);

            Console.WriteLine($"Второе максимальное значение: {secondMax} на позиции {secondMaxIndex}");

            // Удаляем все нечетные элементы
            numbers.RemoveAll(n => n % 2 != 0);
            Console.WriteLine("Список после удаления нечетных элементов: " + string.Join(", ", numbers));
            var employees = File.ReadAllLines("employees.txt").Select(line => new Employee(line)).ToList();
            var sortedEmployees = employees.Where(e => e.Salary < 10000)
                                           .Concat(employees.Where(e => e.Salary >= 10000));

            foreach (var employee in sortedEmployees)
            {
                Console.WriteLine($"{employee.FullName}, Зарплата: {employee.Salary}");
            }
            Catalog catalog = new Catalog();
            catalog.AddCD("CD1", new List<string> { "Song1", "Song2" });
            catalog.AddSong("CD1", "Song3");
            catalog.RemoveSong("CD1", "Song2");

            catalog.PrintCatalog();
            Console.ReadKey();
        }

    }
}
