namespace SolveLabs.Labs.Lab2
{
    public static class Solve6
    {
        public static void Execute()
        {
            Console.Write("Введите первое вещественное число: ");
            double number1 = double.Parse(Console.ReadLine());
            Console.Write("Введите второе вещественное число: ");
            double number2 = double.Parse(Console.ReadLine());

            if (number1 < 0 || number2 < 0)
            {
                Console.WriteLine("Error");
            }
            else
            {
                double minNumber = Math.Min(number1, number2);
                Console.WriteLine($"Квадратный корень из меньшего числа ({minNumber}): {Math.Sqrt(minNumber)}");
            }
        }
    }
}