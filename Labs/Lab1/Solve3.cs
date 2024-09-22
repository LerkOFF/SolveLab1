namespace SolveLabs.Labs.Lab1
{
    public static class Solve3
    {
        public static void Execute()
        {
            Console.Write("Введите часы (0-11): ");
            if (!int.TryParse(Console.ReadLine(), out int h) || h < 0 || h > 11)
            {
                Console.WriteLine("Некорректные значения часов.");
                return;
            }

            Console.Write("Введите минуты (0-59): ");
            if (!int.TryParse(Console.ReadLine(), out int m) || m < 0 || m > 59)
            {
                Console.WriteLine("Некорректные значения минут.");
                return;
            }

            Console.Write("Введите секунды (0-59): ");
            if (!int.TryParse(Console.ReadLine(), out int s) || s < 0 || s > 59)
            {
                Console.WriteLine("Некорректные значения секунд.");
                return;
            }

            double angle = h * 30 + (m * 0.5) + (s * (0.5 / 60));

            Console.WriteLine($"Угол между начальным положением и текущим положением часовой стрелки: {angle} градусов.");
        }
    }
}
