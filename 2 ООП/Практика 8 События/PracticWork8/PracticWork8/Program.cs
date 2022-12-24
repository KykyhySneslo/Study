﻿class Program
{
    private static void Main(string[] args)
    {
        Counter counter = new Counter();
        counter.GetNumber200 += Wait.ShowNumber200Text;
        counter.GetNumber800 += Wait.ShowNumber800Text;
        counter.countUp();
        Console.ReadLine();
    }

    public class Counter
    {
        public int numbers { get; set; } = 0;
        public void countUp()
        {
            while (numbers < 1000)
            {
                numbers++;
                Console.WriteLine("Число: " + numbers);
                if (numbers == 200) GetNumber200();
                if (numbers == 800) GetNumber800();
            }
        }
        public event Action GetNumber200;
        public event Action GetNumber800;
    }

    public static class Wait
    {
        public static void ShowNumber200Text()
        {
            Console.WriteLine("Значение 200 достигнуто");
        }
        public static void ShowNumber800Text()
        {
            Console.WriteLine("Значение 800 достигнуто");
        }
    }

}