namespace SolveLabs.Labs.Lab1
{
    public static class Solve2
    {
        public static void Execute()
        {
            Console.Write("Введите количество секунд прошедших с начала суток: ");
            if (!int.TryParse(Console.ReadLine(), out int totalSeconds) || totalSeconds < 0 || totalSeconds >= 86400)
            {
                Console.WriteLine("Введите число секунд в диапазоне от 0 до 86399.");
                return;
            }

            int hours = totalSeconds / 3600;
            int remainingSeconds = totalSeconds % 3600;
            int minutes = remainingSeconds / 60;
            int seconds = remainingSeconds % 60;

            Console.WriteLine($"Прошло {hours} часов, {minutes} минут и {seconds} секунд.");
        }
    }
}
