using System;

namespace GameNumber
{
    internal class Program
    {
        Random rnd = new Random();
        char answer = 'Y';

        /// <summary>
        /// МЕТОД GetRandomNumbers
        /// Назначение: получает от пользователя число и проверяет его корректность
        /// Логика: дает 3 попытки на ввод числа от 0 до 100
        /// Возвращает: число (int) или null, если попытки исчерпаны
        /// </summary>
        public int? GetRandomNumbers()
        {
            int attempt = 0;
            for (int i = 0; i < 3; i++)
            {
                if (int.TryParse(Console.ReadLine(), out attempt))
                {
                    if (attempt >= 0 && attempt <= 100)
                        return attempt;
                    else
                        Console.WriteLine("input number from [0,100]");
                }
                else
                {
                    Console.WriteLine("input number from [0,100]");
                }

                if (i == 2)
                {
                    Console.WriteLine("Идиот?");
                    Environment.Exit(0);
                }
            }
            Console.WriteLine("Превышено количество попыток");
            return null;
        }

        /// <summary>
        /// МЕТОД ComparingNumbers
        /// Назначение: сравнивает число игрока с загаданным числом
        /// Логика: выводит подсказку (больше/меньше) и возвращает результат сравнения
        /// Возвращает: true - если числа равны (победа), false - если не равны
        /// </summary>
        public bool ComparingNumbers(int attempt, int number)
        {
            if (number < attempt)
            {
                Console.WriteLine("Твое число больше");
                return false;
            }
            else if (number > attempt)
            {
                Console.WriteLine("Твое число меньше");
                return false;
            }
            else
            {
                Console.WriteLine("ТЫ ПОБЕДИЛ!!");
                return true;
            }
        }

        /// <summary>
        /// МЕТОД Main (главный)
        /// Назначение: точка входа в программу, управляет игровым процессом
        /// </summary>
        static void Main(string[] args)
        {
            Program program = new Program();

            Console.WriteLine("ИГРА УГАДАЙ ЧИСЛО");

            do
            {
                int mysteryNumber = program.rnd.Next(0, 101);
                int attemptsCounter = 0;
                bool isGuessed = false;

                Console.WriteLine($"\nОтгадай число от 0 до 100.");

                while (!isGuessed)
                {
                    attemptsCounter++;
                    Console.Write($"\nПопытка {attemptsCounter}: ");

                    int? userAttempt = program.GetRandomNumbers();

                    if (userAttempt == null)
                    {
                        Console.WriteLine("Игра прервана из-за некорректного ввода");
                        return;
                    }

                    isGuessed = program.ComparingNumbers(userAttempt.Value, mysteryNumber);
                }

                Console.Write("\nСыграть еще? (Y/N): ");
                string input = Console.ReadLine();
                program.answer = input.Length > 0 ? char.ToUpper(input[0]) : 'N';

            } while (program.answer == 'Y');

            Console.WriteLine("\nСпасибо за игру! До свидания!");
        }
    }
}