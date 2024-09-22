namespace SolveLabs.Labs.Lab2
{
    public static class Solve7
    {
        public static void Execute()
        {
            Console.Write("Введите число от 1 до 10000: ");
            int number = int.Parse(Console.ReadLine());

            if (number < 1 || number > 10000)
            {
                Console.WriteLine("Число должно быть в диапазоне от 1 до 10000.");
                return;
            }

            Console.WriteLine($"Нечётные делители числа {number}:");
            for (int i = 1; i <= number; i += 2)
            {
                if (number % i == 0)
                {
                    Console.WriteLine(i);
                }
            }
        }
    }
}