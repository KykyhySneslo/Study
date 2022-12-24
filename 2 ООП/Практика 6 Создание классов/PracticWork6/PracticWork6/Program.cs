using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace PracticWork6
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int obj = 4;
            Random r = new Random();
            BookCard[] book = new BookCard[obj];

            for (int j = 0; j < obj; j++)
            {

                book[j] = new BookCard();
                book[j].id = r.Next(1, 99);
                book[j].author = "Достоевский";
                book[j].title = "Преступление и наказание";
                book[j].year = r.Next(1990, 2022);
                book[j].condition = "d";
                book[j].GetBookInfo();
            }
            ScientificBookCard sb1 = new ScientificBookCard
            {
                id = 4,
                author = "Вышегородский",
                title = "Научная энциклопедия",
                year = 2000,
                condition = "На списание",
                direction = "Химия"
            };
            ScientificBookCard sb2 = new ScientificBookCard
            {
                id = 5,
                author = "Колмогоров",
                title = "Высшая математика",
                year = 2022,
                condition = "Новая",
                direction = "Математика"
            };
            sb1.getScientificBookCardInfo();
            sb2.getScientificBookCardInfo();
            Console.WriteLine();
            Console.ReadKey();
        }

        enum Condition
        {
            На_списание,
            Хорошее,
            Новая
        }
      
    }
}
    
    





    
    