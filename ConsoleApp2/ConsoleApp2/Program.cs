using System;

namespace практика2
{
    internal class Program
    {
        int left = 0;
        int right = 101;

        public int? GetNumber()
        {
            for (int i = 0; i < 3; i++)
            {
                if (int.TryParse(Console.ReadLine(), out int attempt))
                {
                    if (attempt >= left && attempt < right)
                        return attempt;
                    else
                        Console.WriteLine($"Input number from [{left};{right}]");
                }
                else
                {
                    Console.WriteLine("Invalid input! Please enter a number.");
                }
            }

            Console.WriteLine("You are stupid");
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
                Console.WriteLine($"Input number from [{left};{right}]");
                int? result = GetNumber();
                if (result == null)
                    return;

                int attempt = result.Value;
                bool flag = CompareNumber(attempt, number);
                if (flag == true)
                    break;
            }
        }

        static void Main(string[] args)
        {
            Random rnd = new Random();
            Program program = new Program();

            char answer = 'Y';
            do
            {
                int number = rnd.Next(program.left, program.right);
                program.PlayGame(number);

                Console.WriteLine("Do you want play again?");
                answer = Convert.ToChar(Console.ReadLine());

            } while (answer == 'Y' || answer == 'y');
        }
    }
}