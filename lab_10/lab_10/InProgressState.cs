using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_10.State
{
    public class InProgressState : IOrderState
    {
        public void Next(Order order)
        {
            Console.WriteLine("Поїздку завершено!");
            order.State = new CompletedState();
        }

        public void Prev(Order order)
        {
            Console.WriteLine("Повертаємось до призначення.");
            order.State = new AssignedState();
        }

        public void PrintStatus()
        {
            Console.WriteLine("Статус: Поїздка виконується.");
        }
    }
}
