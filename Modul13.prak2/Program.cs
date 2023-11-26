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
        static void example1() {
            List<int> numbers = new List<int> { 3, 1, 4, 1, 5, 9, 2, 6, 5, 3, 5 };
            var distinctNumbers = numbers.Distinct().ToList();
            distinctNumbers.Sort();
            int secondMax = distinctNumbers.Count >= 2 ? distinctNumbers[distinctNumbers.Count - 2] : -1;
            int index = secondMax != -1 ? numbers.IndexOf(secondMax) : -1;
            Console.WriteLine("Второе максимальное значение: " + secondMax);
            Console.WriteLine("Позиция второго максимального значения: " + index);
            numbers.RemoveAll(n => n % 2 != 0);
            Console.WriteLine("Список после удаления нечетных элементов: " + string.Join(", ", numbers));
        }
        static void example2() {
            List<double> numbers = new List<double> { 1.5, 3.2, 2.8, 4.6, 5.1 };
            double average = numbers.Average();
            var aboveAverage = numbers.Where(n => n > average).ToList();
            Console.WriteLine("Среднее арифметическое: " + average);
            Console.WriteLine("Элементы больше среднего: " + string.Join(", ", aboveAverage));
        }
        static void example3() {
            string sourceFilePath = @"C:\temp\source.txt"; 
            string destinationFilePath = @"C:\temp\destination.txt";  

            try
            {
                List<string> lines = File.ReadAllLines(sourceFilePath).ToList();

                lines.Reverse();

                File.WriteAllLines(destinationFilePath, lines);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Произошла ошибка: " + ex.Message);
            }
        }
        static void example4() {
            string filePath = @"C:\temp\employees.txt";  

            try
            {
                var employees = File.ReadAllLines(filePath).Select(line => new Employee(line)).ToList();

                var lowerSalaryEmployees = employees.Where(e => e.Salary < 10000);
                var higherSalaryEmployees = employees.Where(e => e.Salary >= 10000);

                foreach (var employee in lowerSalaryEmployees.Concat(higherSalaryEmployees))
                {
                    Console.WriteLine(employee);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Произошла ошибка: " + ex.Message);
            }
        }
        static void example5() {
            CDCatalog catalog = new CDCatalog();

            CD cd1 = new CD("Исполнитель 1");
            cd1.AddSong("Песня 1");
            cd1.AddSong("Песня 2");
            catalog.AddCD("CD1", cd1);

            CD cd2 = new CD("Исполнитель 2");
            cd2.AddSong("Песня 3");
            catalog.AddCD("CD2", cd2);

            catalog.PrintCatalog();

            Console.WriteLine("\nПоиск по исполнителю 'Исполнитель 1':");
            catalog.SearchByArtist("Исполнитель 1");

            Console.WriteLine("\nСодержимое CD1:");
            catalog.PrintCD("CD1");

            cd1.RemoveSong("Песня 1");
            catalog.RemoveCD("CD2");

            Console.WriteLine("\nКаталог после изменений:");
            catalog.PrintCatalog();
        }
        static void Main()
        {
            example1();
            example2();
            example3();
            example4();
            example5();
            Console.ReadKey();
        }

    }
}
