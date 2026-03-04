using System;

namespace GuessNumber
{
    internal class Program
    {
        int min = 0;
        int max = 0;
        int count = 0;
        int countGame = 0;
        int left = 0;
        int right = 100;
        int counter = 0;

        public int? GetNumber()
        {
            int attempt = 0;
            for (int i = 0; i < 3; i++)
            {
                if (int.TryParse(Console.ReadLine(), out attempt))
                {
                    if (attempt >= left && attempt <= right)
                        return attempt;
                    else
                        Console.WriteLine($"Input number from [{left}];{right}]");
                }
                else
                {
                    Console.WriteLine($"Input number from [{left}];{right}]");
                }

                if (i == 2)
                {
                    Console.WriteLine("You are stupid");
                    return null;
                }
            }
            return null;
        }

        public bool CompareNumber(int attempt, int number)
        {
            if (number < attempt)
            {
                Console.WriteLine("Your number is greater");
                return false;
            }
            else if (number > attempt)
            {
                Console.WriteLine("Your number is less");
                return false;
            }
            else
            {
                Console.WriteLine("You are win!!!");
                return true;
            }
        }

        public void PlayGame(int number)
        {
            while (true)
            {
                Console.WriteLine($"Input number from [{left}];{right}]");
                int? result = GetNumber();
                if (result == null)
                    return;

                int attempt = result.Value;
                counter++;
                bool flag = CompareNumber(attempt, number);
                if (flag == true)
                {
                    // Статистика игры
                    if (min == 0 || min > counter) min = counter;
                    max = max < counter ? counter : max;
                    count += counter;
                    countGame++;
                    break;
                }
            }
        }

        static void Main(string[] args)
        {
            Random rnd = new Random();
            Program program = new Program();

            string name = "new Name";
            Console.WriteLine(name);

            char answer = 'Y';
            do
            {
                int number = rnd.Next(program.left, program.right + 1);
                program.counter = 0; // Сброс счетчика для новой игры
                program.PlayGame(number);

                Console.WriteLine("Do you want play again?");
                answer = Convert.ToChar(Console.ReadLine());

            } while (answer == 'Y' || answer == 'y');

            Console.WriteLine($"min = {program.min} max = {program.max} avg = {(double)program.count / program.countGame}");
        }
    }
}