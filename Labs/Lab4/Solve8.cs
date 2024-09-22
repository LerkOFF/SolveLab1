using System.Text;

namespace SolveLabs.Labs.Lab4
{
    public static class Solve8
    {
        public static void Execute()
        {
            while (true)
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("\n=== Задание 8: Шифрование и Расшифровка Строк ===");
                Console.ResetColor();
                Console.WriteLine("Выберите алгоритм шифрования:");
                Console.WriteLine("1. Шифр Вернама (One-Time Pad)");
                Console.WriteLine("2. Шифр Цезаря");
                Console.WriteLine("3. Шифр XOR");
                Console.WriteLine("0. Возврат в главное меню");
                Console.Write("Введите номер алгоритма (0-3): ");

                string choice = Console.ReadLine();

                if (choice == "0")
                    break;

                Console.Write("Введите текст для шифрования/расшифровки: ");
                string text = Console.ReadLine();

                Console.Write("Выберите операцию:\n1. Шифрование\n2. Расшифровка\nВведите номер операции (1-2): ");
                string operationChoice = Console.ReadLine();

                bool encrypt;
                if (operationChoice == "1")
                    encrypt = true;
                else if (operationChoice == "2")
                    encrypt = false;
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Некорректный выбор операции.");
                    Console.ResetColor();
                    continue;
                }

                string key = string.Empty;

                switch (choice)
                {
                    case "1":
                        Console.Write("Введите ключ (должен быть той же длины, что и текст): ");
                        key = Console.ReadLine();
                        if (key.Length != text.Length)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Длина ключа должна совпадать с длиной текста.");
                            Console.ResetColor();
                            continue;
                        }
                        string vernamResult = VernamCipher(text, key);
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine($"Результат: {vernamResult}");
                        Console.ResetColor();
                        break;

                    case "2":
                        Console.Write("Введите сдвиг (целое число): ");
                        if (!int.TryParse(Console.ReadLine(), out int shift))
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Некорректный ввод сдвига.");
                            Console.ResetColor();
                            continue;
                        }
                        string caesarResult = CaesarCipher(text, shift, encrypt);
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine($"Результат: {caesarResult}");
                        Console.ResetColor();
                        break;

                    case "3":
                        Console.Write("Введите ключ (может быть короче текста): ");
                        key = Console.ReadLine();
                        string xorResult = XorCipher(text, key);
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine($"Результат: {xorResult}");
                        Console.ResetColor();
                        break;

                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Некорректный выбор алгоритма.");
                        Console.ResetColor();
                        break;
                }

                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine("\nНажмите любую клавишу для продолжения...");
                Console.ResetColor();
                Console.ReadKey();
                Console.Clear();
            }
        }

        // Шифр Вернама (One-Time Pad)
        private static string VernamCipher(string text, string key)
        {
            StringBuilder result = new StringBuilder();

            for (int i = 0; i < text.Length; i++)
            {
                char encryptedChar = (char)(text[i] ^ key[i]);
                result.Append(encryptedChar);
            }

            return result.ToString();
        }

        // Шифр Цезаря
        private static string CaesarCipher(string text, int shift, bool encrypt)
        {
            if (!encrypt)
                shift = -shift;

            StringBuilder result = new StringBuilder();

            foreach (char c in text)
            {
                if (char.IsLetter(c))
                {
                    char offset = char.IsUpper(c) ? 'A' : 'a';
                    char encryptedChar = (char)(((c + shift - offset) % 26 + 26) % 26 + offset);
                    result.Append(encryptedChar);
                }
                else
                {
                    result.Append(c);
                }
            }

            return result.ToString();
        }

        // Шифр XOR
        private static string XorCipher(string text, string key)
        {
            StringBuilder result = new StringBuilder();
            int keyLength = key.Length;

            for (int i = 0; i < text.Length; i++)
            {
                char encryptedChar = (char)(text[i] ^ key[i % keyLength]);
                result.Append(encryptedChar);
            }

            return result.ToString();
        }
    }
}
