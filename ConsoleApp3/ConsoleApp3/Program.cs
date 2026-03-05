using System.Reflection.Metadata.Ecma335;

namespace TwoPointers_SlidingWindows
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string str1 = "asd dsa";
            string str2 = "asdsa";
            string str3 = "asd";

            Console.WriteLine(BadSolution1(str1));
            Console.WriteLine(BadSolution1(str2));
            Console.WriteLine(BadSolution1(str3));
            Console.WriteLine();
            Console.WriteLine(GoodSolution1(str1));
            Console.WriteLine(GoodSolution1(str2));
            Console.WriteLine(GoodSolution1(str3));
            int[] arr = { 1, 2, 1, 4, 5, 2 };
            Console.WriteLine(GoodSolution2(arr, 10));
        }

        public static bool BadSolution1(string str) // 0(n) - линейная сложность
        {
            if (string.IsNullOrWhiteSpace(str)) return false;

            string rev = "";

            foreach (var ch in str)
            {
                rev = ch + rev;
            }
            for (int i = 0; i < str.Length; i++) // 0(n)
            {
                if (rev[i] != str[i])
                {
                    return false;
                }
            }
            return true;
        }

        public static bool GoodSolution1(string str)
        {
            if (string.IsNullOrWhiteSpace(str)) return false;

            for (int left = 0, right = str.Length - 1; left < right; left++, right--)
            {
                if (str[left] != str[right]) return false;
            }
            return true;
        }

        public static int GoodSolution2(int[] arr, int k)
        { // 1 2  10 k=100
            int top = 0, bottom = 0;
            int sum = 0, max = 0;
            while (top < arr.Length - 1)
            {
                if (sum + arr[top]<=k)
                {
                    sum += arr[top];
                    top++;
                }
                else
                {
                    max = max > top - bottom ? max : top - bottom;
                    sum -= arr[bottom];
                    bottom++;
                }
            } return max;
        }   
    }
}