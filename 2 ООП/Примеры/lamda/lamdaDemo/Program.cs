namespace lamdaDemo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //стандартный делегат для void...()
            Action act = () =>  Console.WriteLine("1"); ;
            act += () =>
            {
                for (int i = 0; i<10; i++) Console.Write(i+"|");
            };

            act();
            //стандартный делегат для <T> ... (<T>....<T>)
            Func<int, int, int[,]> fun = (i, b) =>
            {
                int[,] arr = new int[i, b];
                Random rnd = new Random();
                for (int a = 0; a < i; a++)
                {
                    for (int g = 0; g < b; g++)
                    {
                        arr[a, g] = rnd.Next(10, 100);
                    }
                }
                return arr;
            };

            int[,] nums = fun(5, 6);
            foreach(int i in nums) Console.WriteLine(i);
            //стандартный метод для bool ... (<T>)
            Predicate<int> isCount = (x) => {
                if (x>0) return true;
                else return false;
            };

            Console.WriteLine(isCount(-400));
        }
    }
}