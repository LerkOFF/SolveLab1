namespace SolveLabs.Labs.Lab6
{
    public static class Solve4
    {
        private const string SourceFile = "lab.dat";
        private const string DestinationDir = "Lab6_Temp";
        private const string BackupFile = "lab_backup.dat";

        public static void Execute()
        {
            // Выбор раздела диска (например, "C:\\")
            Console.Write("Введите путь к разделу диска (например, C:\\): ");
            string drivePath = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(drivePath) || !Directory.Exists(drivePath))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Некорректный путь к разделу диска.");
                Console.ResetColor();
                return;
            }

            string fullDestinationPath = Path.Combine(drivePath, DestinationDir);

            try
            {
                // Создание директории
                Directory.CreateDirectory(fullDestinationPath);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"Директория '{DestinationDir}' создана или уже существует.");
                Console.ResetColor();

                string sourceFilePath = Path.Combine(Directory.GetCurrentDirectory(), SourceFile);
                if (!File.Exists(sourceFilePath))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"Файл '{SourceFile}' не найден в текущей директории.");
                    Console.ResetColor();
                    return;
                }

                // Копирование файла
                string destFilePath = Path.Combine(fullDestinationPath, SourceFile);
                File.Copy(sourceFilePath, destFilePath, overwrite: true);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"Файл '{SourceFile}' скопирован в '{fullDestinationPath}'.");
                Console.ResetColor();

                // Побайтовое копирование для создания backup
                string backupFilePath = Path.Combine(fullDestinationPath, BackupFile);
                using (FileStream sourceStream = File.OpenRead(destFilePath))
                using (FileStream backupStream = File.Create(backupFilePath))
                {
                    sourceStream.CopyTo(backupStream);
                }

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"Копия файла создана как '{BackupFile}'.");
                Console.ResetColor();

                // Получение информации о файле
                FileInfo fi = new FileInfo(sourceFilePath);
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("\nИнформация о файле 'lab.dat':");
                Console.ResetColor();
                Console.WriteLine($"Размер: {fi.Length} байт");
                Console.WriteLine($"Время последнего изменения: {fi.LastWriteTime}");
                Console.WriteLine($"Время последнего доступа: {fi.LastAccessTime}");
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Ошибка: {ex.Message}");
                Console.ResetColor();
            }
        }
    }
}
