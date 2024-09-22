namespace SolveLabs.Labs.Lab6
{
    public static class Solve5
    {
        public static void Execute()
        {
            Console.Write("Введите имя BMP-файла (с расширением .bmp): ");
            string bmpFile = Console.ReadLine();

            if (!File.Exists(bmpFile))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Файл '{bmpFile}' не найден.");
                Console.ResetColor();
                return;
            }

            try
            {
                using (FileStream fs = new FileStream(bmpFile, FileMode.Open, FileAccess.Read))
                using (BinaryReader br = new BinaryReader(fs))
                {
                    // Чтение BITMAPFILEHEADER (14 байт)
                    ushort bfType = br.ReadUInt16(); // 0-1 байты
                    if (bfType != 0x4D42) // "BM" в little endian
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Это не BMP-файл.");
                        Console.ResetColor();
                        return;
                    }

                    uint bfSize = br.ReadUInt32(); // 2-5 байты
                    br.ReadUInt16(); // 6-7 байты (резерв)
                    br.ReadUInt16(); // 8-9 байты (резерв)
                    uint bfOffBits = br.ReadUInt32(); // 10-13 байты

                    // Чтение BITMAPINFOHEADER (40 байт)
                    uint biSize = br.ReadUInt32(); // 14-17 байты
                    if (biSize != 40)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine($"Не поддерживаемый размер заголовка BITMAPINFOHEADER: {biSize} байт.");
                        Console.ResetColor();
                        return;
                    }

                    int biWidth = br.ReadInt32(); // 18-21 байты
                    int biHeight = br.ReadInt32(); // 22-25 байты
                    ushort biPlanes = br.ReadUInt16(); // 26-27 байты
                    ushort biBitCount = br.ReadUInt16(); // 28-29 байты
                    uint biCompression = br.ReadUInt32(); // 30-33 байты
                    uint biSizeImage = br.ReadUInt32(); // 34-37 байты
                    int biXPelsPerMeter = br.ReadInt32(); // 38-41 байты
                    int biYPelsPerMeter = br.ReadInt32(); // 42-45 байты
                    uint biClrUsed = br.ReadUInt32(); // 46-49 байты
                    uint biClrImportant = br.ReadUInt32(); // 50-53 байты

                    // Определение типа сжатия
                    string compression = biCompression switch
                    {
                        0 => "Без сжатия (BI_RGB)",
                        1 => "4-бит RLE (BI_RLE4)",
                        2 => "8-бит RLE (BI_RLE8)",
                        _ => $"Другой тип сжатия (код {biCompression})"
                    };

                    // Определение количества цветов по количеству бит на пиксель
                    string bitPerPixelInfo = biBitCount switch
                    {
                        1 => "1 бит на пиксель (монохромная палитра, 2 цвета)",
                        4 => "4 бита на пиксель (палитра на 16 цветов)",
                        8 => "8 бит на пиксель (палитра на 256 цветов)",
                        16 => "16 бит на пиксель (65536 цветов)",
                        24 => "24 бита на пиксель (16 миллионов цветов)",
                        _ => $"Неизвестное количество бит на пиксель: {biBitCount}"
                    };

                    // Вывод информации
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"\nИнформация о BMP-файле '{bmpFile}':");
                    Console.ResetColor();
                    Console.WriteLine($"Размер файла: {bfSize} байт");
                    Console.WriteLine($"Ширина: {biWidth} пикселей");
                    Console.WriteLine($"Высота: {biHeight} пикселей");
                    Console.WriteLine($"Количество бит на пиксель: {biBitCount} ({bitPerPixelInfo})");
                    Console.WriteLine($"Горизонтальное разрешение: {biXPelsPerMeter} пикселей/метр");
                    Console.WriteLine($"Вертикальное разрешение: {biYPelsPerMeter} пикселей/метр");
                    Console.WriteLine($"Тип сжатия: {compression}");
                }
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Ошибка при обработке файла: {ex.Message}");
                Console.ResetColor();
            }
        }
    }
}
