using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_10.State
{
    public class CancelledState : IOrderState
    {
        public void Next(Order order)
        {
            Console.WriteLine("Замовлення скасовано. Немає подальших дій.");
        }

        public void Prev(Order order)
        {
            Console.WriteLine("Неможливо повернутись назад після скасування.");
        }

        public void PrintStatus()
        {
            Console.WriteLine("Статус: Скасовано.");
        }
    }
}
