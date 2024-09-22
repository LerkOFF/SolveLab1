namespace SolveLabs.Labs.Lab1
{
    public static class Solve4
    {
        public static void Execute()
        {
            Console.Write("Введите первое целое число a: ");
            if (!int.TryParse(Console.ReadLine(), out int a))
            {
                Console.WriteLine("Некорректный ввод для a.");
                return;
            }

            Console.Write("Введите второе целое число b: ");
            if (!int.TryParse(Console.ReadLine(), out int b))
            {
                Console.WriteLine("Некорректный ввод для b.");
                return;
            }

            Console.WriteLine($"До обмена: a = {a}, b = {b}");

            a = a + b;
            b = a - b;
            a = a - b;

            Console.WriteLine($"После обмена: a = {a}, b = {b}");
        }
    }
}
