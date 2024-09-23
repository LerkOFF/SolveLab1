namespace SolveLabs.Labs.Lab9
{
    public static class Solve3
    {
        public static void Execute()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("=== Задание 3: Игра «Считалка» ===\n");
            Console.ResetColor();

            // Загрузка участников
            List<string> participants = LoadParticipants();
            if (participants.Count < 5 || participants.Count > 10)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Количество участников должно быть от 5 до 10.");
                Console.ResetColor();
                return;
            }

            // Создание циклического связного списка
            CircularLinkedList<string> list = new CircularLinkedList<string>();
            foreach (var name in participants)
                list.AddLast(name);

            // Ввод считалки
            Console.Write("Введите строку считалки (слова разделяются пробелами): ");
            string rhyme = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(rhyme))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Считалка не может быть пустой.");
                Console.ResetColor();
                return;
            }

            string[] rhymeWords = rhyme.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            if (rhymeWords.Length == 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Считалка не содержит слов.");
                Console.ResetColor();
                return;
            }

            // Выбор начального участника
            Console.WriteLine("\nСписок участников:");
            for (int i = 0; i < participants.Count; i++)
                Console.WriteLine($"{i + 1}. {participants[i]}");

            Console.Write("Введите номер участника, с которого начать считалку: ");
            if (!int.TryParse(Console.ReadLine(), out int startIndex) || startIndex < 1 || startIndex > participants.Count)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Некорректный номер участника.");
                Console.ResetColor();
                return;
            }

            CircularLinkedListNode<string> current = list.GetNodeAt(startIndex - 1);

            // Эмуляция игры
            foreach (var word in rhymeWords)
            {
                current = current.Next;
            }

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"\nПоследнее слово считалки выпало на участнике: {current.Data}");
            Console.ResetColor();
        }

        /// <summary>
        /// Загружает участников из файла или использует прошитый список
        /// </summary>
        /// <returns>Список имен участников</returns>
        private static List<string> LoadParticipants()
        {
            List<string> participants = new List<string>();
            string filePath = "participants.txt";

            if (File.Exists(filePath))
            {
                var lines = File.ReadAllLines(filePath);
                foreach (var line in lines)
                {
                    string name = line.Trim();
                    if (!string.IsNullOrWhiteSpace(name))
                        participants.Add(name);
                }
            }
            else
            {
                // Прошитый список участников
                participants.AddRange(new string[]
                {
                    "Анна",
                    "Борис",
                    "Виктор",
                    "Галина",
                    "Дмитрий",
                    "Елена",
                    "Жанна",
                    "Игорь",
                    "Ксения",
                    "Леонид"
                });
            }

            return participants;
        }
    }
}
