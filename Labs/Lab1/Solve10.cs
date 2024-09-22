namespace SolveLabs.Labs.Lab1
{
    public struct Country
    {
        public string Name;
        public string Capital;
        public long Population;
        public string GovernmentType;
    }

    public static class Solve10
    {
        public static void Execute()
        {
            Country[] countries = new Country[3];
            string[] validGovernmentTypes = { "Ф", "УГ" };

            for (int i = 0; i < countries.Length; i++)
            {
                Console.WriteLine($"Введите данные для страны {i + 1}:");

                while (true)
                {
                    Console.Write("Название страны: ");
                    countries[i].Name = Console.ReadLine();

                    if (string.IsNullOrWhiteSpace(countries[i].Name))
                        Console.WriteLine("Название страны не может быть пустым. Попробуйте снова.");
                    else break;
                }

                while (true)
                {
                    Console.Write("Столица: ");
                    countries[i].Capital = Console.ReadLine();

                    if (string.IsNullOrWhiteSpace(countries[i].Capital))
                        Console.WriteLine("Столица не может быть пустой. Попробуйте снова.");
                    else
                        break;
                }

                while (true)
                {
                    Console.Write("Население (целое положительное число): ");
                    string populationInput = Console.ReadLine();
                    if (long.TryParse(populationInput, out long population) && population > 0)
                    {
                        countries[i].Population = population;
                        break;
                    }
                    else
                        Console.WriteLine("Введите корректное положительное целое число для населения.");
                }

                while (true)
                {
                    Console.Write("Тип строя (Ф - федерация, УГ - унитарное государство): ");
                    countries[i].GovernmentType = Console.ReadLine().ToUpper();

                    if (Array.Exists(validGovernmentTypes, type => type == countries[i].GovernmentType))
                        break;
                    else
                        Console.WriteLine("Неверный тип строя. Введите 'Ф' для федерации или 'УГ' для унитарного государства.");
                }
            }

            // Вывод форматированной таблицы
            Console.WriteLine("\nГеография");
            Console.WriteLine(new string('-', 50));
            Console.WriteLine("| {0,-15} | {1,-15} | {2,-10} | {3,-5} |", "Государство", "Столица", "Население", "Строй");
            Console.WriteLine(new string('-', 50));

            foreach (var country in countries)
            {
                Console.WriteLine("| {0,-15} | {1,-15} | {2,-10} | {3,-5} |",
                    country.Name, country.Capital, country.Population, country.GovernmentType);
            }

            Console.WriteLine(new string('-', 50));
            Console.WriteLine("Перечисляемый тип: Ф - федерация, УГ - унитарное государство");
        }
    }
}
