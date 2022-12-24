using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticWork6
{
    internal class ScientificBookCard : BookCard
    {
        public string direction;

        public void getScientificBookCardInfo()
        {
            Console.WriteLine(
                   $"Уникальный номер: {id} \n" +
                   $"Автор: {author} \n" +
                   $"Название: {title} \n" +
                   $"Год издания экземпляра: {year} \n" +
                   $"Состояние книги: {condition} \n" +
                   $"Направление: {direction} \n ");
        }
    }
}
