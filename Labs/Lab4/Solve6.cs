using System.Text.RegularExpressions;

namespace SolveLabs.Labs.Lab4
{
    public static class Solve6
    {
        public static void Execute()
        {
            Console.Write("Введите выражение вида '15 + 36 = 51': ");
            string input = Console.ReadLine();

            if (string.IsNullOrEmpty(input))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Ввод не должен быть пустым.");
                Console.ResetColor();
                return;
            }

            // Регулярное выражение для разбора выражения
            string pattern = @"^\s*(-?\d+)\s*([+\-*/])\s*(-?\d+)\s*=\s*(-?\d+)\s*$";
            Match match = Regex.Match(input, pattern);

            if (match.Success)
            {
                string operand1Str = match.Groups[1].Value;
                string operatorStr = match.Groups[2].Value;
                string operand2Str = match.Groups[3].Value;
                string resultStr = match.Groups[4].Value;

                // Парсинг в целочисленные переменные
                if (int.TryParse(operand1Str, out int operand1) &&
                    int.TryParse(operand2Str, out int operand2) &&
                    int.TryParse(resultStr, out int sum))
                {
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine("\nРазобранные компоненты:");
                    Console.ResetColor();
                    Console.WriteLine($"Операнд 1: {operand1}");
                    Console.WriteLine($"Оператор: {operatorStr}");
                    Console.WriteLine($"Операнд 2: {operand2}");
                    Console.WriteLine($"Сумма: {sum}");
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Ошибка при преобразовании чисел.");
                    Console.ResetColor();
                }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Введено некорректное выражение.");
                Console.ResetColor();
            }
        }
    }
}
