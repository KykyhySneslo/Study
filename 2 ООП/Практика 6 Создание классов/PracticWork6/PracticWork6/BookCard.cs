using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticWork6
{
    public class BookCard
    {
        public int id = 0;
        public string author = "undefind";
        public string title = "undefind";
        public int year = 0;
        public string condition;

        public int Year
        {
            get => year;
            set
            {
                if (value >= 1990 && value <= 2022)
                {
                    year = value;
                }
                else
                    throw new InvalidCastException("Значение поля 'Год издания экземпляра' менее 1990 или более 2022.");
            }
        }
      
        public void GetBookInfo()
        {
            Console.WriteLine(
                   $"Уникальный номер: {id} \n" +
                   $"Автор: {author} \n" +
                   $"Название: {title} \n" +
                   $"Год издания экземпляра: {year} \n" +
                   $"Состояние книги: {condition} \n");
        }

    }
}
