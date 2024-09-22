using System.Text;
using System.Text.RegularExpressions;

namespace SolveLabs.Labs.Lab4
{
    public static class Solve9
    {
        // Список ключевых слов C# для проверки
        private static readonly HashSet<string> csharpKeywords = new HashSet<string>
        {
            "abstract","as","base","bool","break","byte","case","catch","char","checked",
            "class","const","continue","decimal","default","delegate","do","double","else",
            "enum","event","explicit","extern","false","finally","fixed","float","for",
            "foreach","goto","if","implicit","in","int","interface","internal","is","lock",
            "long","namespace","new","null","object","operator","out","override","params",
            "private","protected","public","readonly","ref","return","sbyte","sealed","short",
            "sizeof","stackalloc","static","string","struct","switch","this","throw","true",
            "try","typeof","uint","ulong","unchecked","unsafe","ushort","using","virtual",
            "void","volatile","while"
        };

        public static void Execute()
        {
            while (true)
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("\n=== Задание 9: Удаление Недопустимых Имен Переменных ===");
                Console.ResetColor();
                Console.Write("Введите текст: ");
                string input = Console.ReadLine();

                if (string.IsNullOrEmpty(input))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Текст не должен быть пустым.");
                    Console.ResetColor();
                    continue;
                }

                // Способ 1: Обработка строки как массива символов
                string result1 = RemoveInvalidVariableNames_Array(input);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\nРезультат (Обработка как массива символов):");
                Console.ResetColor();
                Console.WriteLine(result1);

                // Способ 2: Использование методов классов string и StringBuilder
                string result2 = RemoveInvalidVariableNames_Methods(input);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\nРезультат (Использование методов классов string и StringBuilder):");
                Console.ResetColor();
                Console.WriteLine(result2);

                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine("\nНажмите любую клавишу для продолжения или 'Esc' для выхода...");
                Console.ResetColor();
                var key = Console.ReadKey();
                if (key.Key == ConsoleKey.Escape)
                    break;
                Console.Clear();
            }
        }

        // Способ 1: Обработка строки как массива символов
        private static string RemoveInvalidVariableNames_Array(string input)
        {
            List<string> validWords = new List<string>();
            StringBuilder wordBuilder = new StringBuilder();
            bool isWord = false;

            foreach (char c in input)
            {
                if (char.IsLetterOrDigit(c) || c == '_')
                {
                    wordBuilder.Append(c);
                    isWord = true;
                }
                else
                {
                    if (isWord)
                    {
                        string word = wordBuilder.ToString();
                        if (IsValidVariableName(word))
                            validWords.Add(word);
                        wordBuilder.Clear();
                        isWord = false;
                    }
                }
            }

            // Проверка последнего слова
            if (isWord)
            {
                string word = wordBuilder.ToString();
                if (IsValidVariableName(word))
                    validWords.Add(word);
            }

            // Формирование новой строки
            StringBuilder result = new StringBuilder();
            wordBuilder.Clear();
            int validIndex = 0;

            foreach (char c in input)
            {
                if (char.IsLetterOrDigit(c) || c == '_')
                {
                    wordBuilder.Append(c);
                }
                else
                {
                    if (wordBuilder.Length > 0)
                    {
                        string word = wordBuilder.ToString();
                        if (IsValidVariableName(word))
                        {
                            result.Append(word);
                        }
                        wordBuilder.Clear();
                    }
                    result.Append(c);
                }
            }

            // Проверка последнего слова
            if (wordBuilder.Length > 0)
            {
                string word = wordBuilder.ToString();
                if (IsValidVariableName(word))
                    result.Append(word);
            }

            return result.ToString();
        }

        // Способ 2: Использование методов классов string и StringBuilder
        private static string RemoveInvalidVariableNames_Methods(string input)
        {
            // Разделение текста на слова, сохраняя разделители
            string pattern = @"(\b\w+\b)";
            StringBuilder result = new StringBuilder();
            int lastIndex = 0;

            foreach (Match match in Regex.Matches(input, pattern))
            {
                // Добавление разделителей перед словом
                result.Append(input.Substring(lastIndex, match.Index - lastIndex));

                string word = match.Value;
                if (IsValidVariableName(word))
                    result.Append(word);

                lastIndex = match.Index + match.Length;
            }

            // Добавление оставшейся части строки
            if (lastIndex < input.Length)
                result.Append(input.Substring(lastIndex));

            return result.ToString();
        }

        // Проверка, является ли слово допустимым именем переменной в C#
        private static bool IsValidVariableName(string word)
        {
            if (string.IsNullOrEmpty(word))
                return false;

            // Проверка первого символа
            if (!(char.IsLetter(word[0]) || word[0] == '_'))
                return false;

            // Проверка остальных символов
            for (int i = 1; i < word.Length; i++)
            {
                if (!(char.IsLetterOrDigit(word[i]) || word[i] == '_'))
                    return false;
            }

            // Проверка, не является ли слово ключевым словом C#
            if (csharpKeywords.Contains(word))
                return false;

            return true;
        }
    }
}
