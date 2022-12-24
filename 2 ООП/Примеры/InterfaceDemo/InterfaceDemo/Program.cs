namespace InterfaceDemo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Book b1 = new Book("Война и мир", 2020, "Толстой");
            Book b2 = new Book("Мертвые души", 1995, "Гоголь");
            Book b3 = new Book("Преступление и наказание", 2000, "Достоевский");

            Book[] books = {b1, b2, b3};

            Array.Sort(books);
            Array.Reverse(books);

            foreach (Book b in books) Console.WriteLine(b);
        }
    }
}