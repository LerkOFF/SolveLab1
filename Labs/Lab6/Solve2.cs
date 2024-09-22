namespace SolveLabs.Labs.Lab6
{
    public static class Solve2
    {
        private const string ProgressionFile = "arithmetic_progression.bin";
        private const string SelectedTermsFile = "selected_terms.bin";

        public static void Execute()
        {
            WriteArithmeticProgression(10); // Записываем 10 членов прогрессии
            ReadAndWriteSelectedTerms(5, 6);
        }

        /// <summary>
        /// Записывает арифметическую прогрессию в бинарный файл
        /// </summary>
        private static void WriteArithmeticProgression(int count)
        {
            using (BinaryWriter writer = new BinaryWriter(File.Open(ProgressionFile, FileMode.Create)))
            {
                int firstTerm = 4;
                int step = 7;
                for (int i = 0; i < count; i++)
                {
                    writer.Write(firstTerm + i * step);
                }
            }

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Арифметическая прогрессия записана в файл '{ProgressionFile}'.");
            Console.ResetColor();
        }

        /// <summary>
        /// Читает 5-й и 6-й члены прогрессии и записывает их во второй файл
        /// </summary>
        private static void ReadAndWriteSelectedTerms(int term1, int term2)
        {
            if (!File.Exists(ProgressionFile))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Файл '{ProgressionFile}' не найден.");
                Console.ResetColor();
                return;
            }

            int value1 = 0, value2 = 0;

            using (BinaryReader reader = new BinaryReader(File.Open(ProgressionFile, FileMode.Open)))
            {
                try
                {
                    reader.BaseStream.Seek((term1 - 1) * sizeof(int), SeekOrigin.Begin);
                    value1 = reader.ReadInt32();
                    value2 = reader.ReadInt32();
                }
                catch (EndOfStreamException)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Недостаточно членов прогрессии в файле.");
                    Console.ResetColor();
                    return;
                }
            }

            using (BinaryWriter writer = new BinaryWriter(File.Open(SelectedTermsFile, FileMode.Create)))
            {
                writer.Write(value1);
                writer.Write(value2);
            }

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"5-й и 6-й члены прогрессии ({value1}, {value2}) записаны в файл '{SelectedTermsFile}'.");
            Console.ResetColor();
        }
    }
}
