namespace SolveLabs.Labs.Lab1
{
    public static class Solve7
    {
        public static void Execute()
        {
            Console.Write("Введите трехзначное число: ");
            string input = Console.ReadLine();

            if (input.Length != 3 || !input.All(char.IsDigit))
            {
                Console.WriteLine("Введено некорректное трёхзначное число.");
                return;
            }

            string reversed = new string(input.Reverse().ToArray());
            Console.WriteLine($"Число в обратном порядке: {reversed}");
        }
    }
}
