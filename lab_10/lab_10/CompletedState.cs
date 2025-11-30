using lab_10.State;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_10
{
    public class CompletedState : IOrderState
    {
        public void Next(Order order)
        {
            Console.WriteLine("Замовлення вже завершено!");
        }

        public void Prev(Order order)
        {
            Console.WriteLine("Повертаємось у стан поїздки.");
            order.State = new InProgressState();
        }

        public void PrintStatus()
        {
            Console.WriteLine("Статус: Завершено!");
        }
    }
}
