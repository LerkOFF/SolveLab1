namespace SolveLabs.Labs.Lab9
{
    public static class Solve6
    {
        public static void Execute()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("=== Задание 6: Турнирная сетка плей-офф ===\n");
            Console.ResetColor();

            // Загрузка команд
            List<string> teams = LoadTeams();
            if (teams.Count != 16)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Должно быть ровно 16 команд для 1/16 финала.");
                Console.ResetColor();
                return;
            }

            // Создание дерева турнира
            TournamentTree tree = new TournamentTree();
            tree.FillLeafNodes(teams);

            // Генерация результатов матчей
            tree.GenerateResults();

            // Вывод результатов
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\nРезультаты матчей:");
            Console.ResetColor();
            tree.PrintResults();
        }

        /// <summary>
        /// Загружает команды из файла или использует прошитый список
        /// </summary>
        /// <returns>Список названий команд</returns>
        private static List<string> LoadTeams()
        {
            List<string> teams = new List<string>();
            string filePath = "teams.txt";

            if (File.Exists(filePath))
            {
                var lines = File.ReadAllLines(filePath);
                foreach (var line in lines)
                {
                    string team = line.Trim();
                    if (!string.IsNullOrWhiteSpace(team))
                        teams.Add(team);
                }
            }
            else
            {
                // "Прошитый" список команд
                teams.AddRange(new string[]
                {
                    "FRA", "ARG", "BRA", "COL", "CHI", "URU", "GER", "ALG",
                    "CRC", "MEX", "NED", "GRE", "BEL", "SWI", "USA", "NIG"
                });
            }

            return teams;
        }
    }
}