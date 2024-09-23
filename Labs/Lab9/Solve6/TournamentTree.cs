namespace SolveLabs.Labs.Lab9
{
    public class TournamentNode
    {
        public string Team1 { get; set; }
        public string Team2 { get; set; }
        public string Result1 { get; set; } // Количество голов для Team1
        public string Result2 { get; set; } // Количество голов для Team2
        public string Winner { get; set; } // Победитель матча
        public TournamentNode Left { get; set; }
        public TournamentNode Right { get; set; }

        public TournamentNode()
        {
            Team1 = string.Empty;
            Team2 = string.Empty;
            Result1 = "0";
            Result2 = "0";
            Winner = string.Empty;
            Left = null;
            Right = null;
        }
    }

    public class TournamentTree
    {
        public TournamentNode Root { get; private set; }

        public TournamentTree()
        {
            Root = new TournamentNode();
        }

        /// <summary>
        /// Заполняет листовые узлы (1/16 финала)
        /// </summary>
        public void FillLeafNodes(List<string> teams)
        {
            if (teams.Count != 16)
                throw new ArgumentException("Должно быть 16 команд для 1/16 финала.");

            int pairIndex = 0;

            // Инициализируем очередь с корневым узлом
            Queue<TournamentNode> queue = new Queue<TournamentNode>();
            queue.Enqueue(Root);

            while (queue.Count > 0 && pairIndex < teams.Count)
            {
                TournamentNode current = queue.Dequeue();

                if (current.Left == null && current.Right == null)
                {
                    // Назначаем левый дочерний узел
                    if (pairIndex + 1 < teams.Count)
                    {
                        current.Left = new TournamentNode
                        {
                            Team1 = teams[pairIndex],
                            Team2 = teams[pairIndex + 1]
                        };
                        pairIndex += 2;
                        queue.Enqueue(current.Left);
                    }

                    // Назначаем правый дочерний узел
                    if (pairIndex + 1 < teams.Count)
                    {
                        current.Right = new TournamentNode
                        {
                            Team1 = teams[pairIndex],
                            Team2 = teams[pairIndex + 1]
                        };
                        pairIndex += 2;
                        queue.Enqueue(current.Right);
                    }
                }
                else
                {
                    if (current.Left != null)
                        queue.Enqueue(current.Left);
                    if (current.Right != null)
                        queue.Enqueue(current.Right);
                }
            }

            // Проверяем, все ли команды были назначены
            if (pairIndex != teams.Count)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Некоторые команды не были назначены на матчи. Проверьте количество команд.");
                Console.ResetColor();
            }
        }

        /// <summary>
        /// Генерирует случайные результаты матчей и продвигает победителей вверх по дереву
        /// </summary>
        public void GenerateResults()
        {
            GenerateResultsRecursive(Root);
        }

        private void GenerateResultsRecursive(TournamentNode node)
        {
            if (node == null)
                return;

            if (node.Left == null && node.Right == null)
            {
                // Листовой узел, уже содержит команды
                if (string.IsNullOrWhiteSpace(node.Team1) || string.IsNullOrWhiteSpace(node.Team2))
                    return;

                // Генерация случайных результатов
                Random rand = new Random();
                int goals1 = rand.Next(0, 5); // 0-4 гола
                int goals2 = rand.Next(0, 5);

                node.Result1 = goals1.ToString();
                node.Result2 = goals2.ToString();

                // Определение победителя
                if (goals1 > goals2)
                {
                    node.Winner = node.Team1;
                }
                else if (goals2 > goals1)
                {
                    node.Winner = node.Team2;
                }
                else
                {
                    // В случае ничьей выбираем победителя случайно
                    node.Winner = rand.Next(0, 2) == 0 ? node.Team1 : node.Team2;
                }
            }
            else
            {
                // Внутренний узел
                if (node.Left != null)
                    GenerateResultsRecursive(node.Left);
                if (node.Right != null)
                    GenerateResultsRecursive(node.Right);

                // Определяем победителя из дочерних узлов
                string winner = DetermineWinner(node.Left, node.Right);
                node.Winner = winner;
            }
        }

        private string DetermineWinner(TournamentNode left, TournamentNode right)
        {
            // Побеждает тот, кто продвигается из дочерних узлов
            if (!string.IsNullOrEmpty(left?.Winner) && !string.IsNullOrEmpty(right?.Winner))
            {
                // Здесь можно добавить логику для определения победителя между left.Winner и right.Winner
                // Для простоты будем считать, что left.Winner выигрывает
                return left.Winner;
            }

            return string.Empty;
        }

        /// <summary>
        /// Выводит результаты матчей
        /// </summary>
        public void PrintResults()
        {
            List<string> results = new List<string>();
            CollectResults(Root, results);
            foreach (var result in results)
                Console.WriteLine(result);
        }

        private void CollectResults(TournamentNode node, List<string> results)
        {
            if (node == null)
                return;

            if (node.Left == null && node.Right == null)
            {
                // Листовой узел
                if (!string.IsNullOrWhiteSpace(node.Team1) && !string.IsNullOrWhiteSpace(node.Team2))
                {
                    results.Add($"{node.Team1} - {node.Team2} : {node.Result1} - {node.Result2}");
                }
            }
            else
            {
                // Внутренний узел
                if (node.Left != null)
                    CollectResults(node.Left, results);
                if (node.Right != null)
                    CollectResults(node.Right, results);

                // Добавляем матч между победителями дочерних узлов, если они есть
                if (!string.IsNullOrWhiteSpace(node.Left?.Winner) && !string.IsNullOrWhiteSpace(node.Right?.Winner))
                {
                    // Для простоты генерируем случайные результаты между победителями
                    Random rand = new Random();
                    int goals1 = rand.Next(0, 5);
                    int goals2 = rand.Next(0, 5);

                    string winner;
                    if (goals1 > goals2)
                    {
                        winner = node.Left.Winner;
                    }
                    else if (goals2 > goals1)
                    {
                        winner = node.Right.Winner;
                    }
                    else
                    {
                        winner = rand.Next(0, 2) == 0 ? node.Left.Winner : node.Right.Winner;
                    }

                    string matchResult = $"{node.Left.Winner} - {node.Right.Winner} : {goals1} - {goals2}";
                    results.Add(matchResult);
                    node.Winner = winner;
                }
            }
        }
    }
}