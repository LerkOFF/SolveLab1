namespace SolveLabs.Labs.Lab9
{
    public static class Solve2
    {
        public static void Execute()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("=== Задание 2: Проверка корректности скобок ===\n");
            Console.ResetColor();

            while (true)
            {
                Console.WriteLine("\n--- Меню Задания 2 ---");
                Console.WriteLine("1. Проверить выражение");
                Console.WriteLine("0. Назад в Lab9");
                Console.Write("Ваш выбор: ");

                string choice = Console.ReadLine();
                Console.WriteLine();

                if (choice == "0")
                {
                    Console.WriteLine("Возврат в Lab9.");
                    break;
                }

                if (choice == "1")
                {
                    Console.Write("Введите математическое выражение: ");
                    string expression = Console.ReadLine();

                    bool isValid = CheckBrackets(expression);
                    if (isValid)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Выражение корректно.");
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Выражение некорректно.");
                    }
                    Console.ResetColor();
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Неверный выбор. Пожалуйста, попробуйте снова.");
                    Console.ResetColor();
                }

                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine("\nНажмите любую клавишу для продолжения...");
                Console.ResetColor();
                Console.ReadKey();
                Console.Clear();
            }
        }

        /// <summary>
        /// Проверяет корректность расстановки скобок в выражении
        /// </summary>
        /// <param name="expression">Математическое выражение</param>
        /// <returns>True, если корректно, иначе False</returns>
        private static bool CheckBrackets(string expression)
        {
            Stack<char> stack = new Stack<char>();

            foreach (char c in expression)
            {
                if (c == '(')
                {
                    stack.Push(c);
                }
                else if (c == ')')
                {
                    if (stack.Count == 0)
                        return false;
                    stack.Pop();
                }
                // Можно добавить обработку других типов скобок, если необходимо
            }

            return stack.Count == 0;
        }
    }
}
