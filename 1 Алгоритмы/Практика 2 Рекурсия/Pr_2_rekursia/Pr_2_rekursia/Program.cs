using System;

namespace Pr_2_rekursia
{
    class Program
    {
        
        public static void NaturNumber(int N, int i)//все возможные варианты сложения                  
        {
            if (Nature(N))                                            
            {
                int k = N - i;

                if (i <= k)
                {
                    Console.WriteLine(N + " = " + i + " + " + k);
                    NaturNumber(N, i + 1);
                }
            }
            else
                Console.WriteLine("Число не является натуральным");
        }

        static bool Nature(int N)//натуральность
        {
            if (N >= 1 && N % 1 == 0)
                return true;
            else
                return false;
        }

        static bool Prime(int n, int k = 2)//простое число
        {
            if (k * k > n)
                return true;
            if (n % k == 0)
                return false;
            return Prime(n, k + 1);
        }

        static bool Palindrom(string str, int i)//палиндром
        {
            if (str[i] != str[str.Length - i - 1])
                return false;

            if (i <= str.Length / 2 - 1)
                Palindrom(str, i + 1);

            return true;
        }

        static bool Brackets(string str)//расстановка скобок
        {
            int left = str.IndexOf("(");
            int right = str.LastIndexOf(")");

            if (left == -1 && right == -1)
                return true;
            else if (left == -1 || right == -1 || right < left)
                return false;
            else
                try
                {
                    return Brackets(str.Substring(left + 1, right));
                }
                catch (System.ArgumentOutOfRangeException)
                {
                    return false;
                }
        }
        static void Main(string[] args)
        {
            Console.Write("Введите натуральное число: ");
            int N = Convert.ToInt32(Console.ReadLine());

            NaturNumber(N, 1);

            if (Prime(N))
                Console.WriteLine("Число является простым");
            else
                Console.WriteLine("Число не является простым");


            Console.Write("Введите строку: ");
            string str = Console.ReadLine().ToLower();

            if (Palindrom(str, 0))
                Console.WriteLine("Строка является палиндромом");
            else
                Console.WriteLine("Строка не является палиндромом");


            Console.Write("Введите строку: ");
            str = Console.ReadLine().ToLower();

            if (Brackets(str))
                Console.WriteLine("Скобки расставлены правильно");
            else
                Console.WriteLine("Скобки расставлены неправильно");
        }
    }
}
