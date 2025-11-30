using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_10.State
{
    public class AssignedState : IOrderState
    {
        public void Next(Order order)
        {
            Console.WriteLine("Поїздка почалась!");
            order.State = new InProgressState();
        }

        public void Prev(Order order)
        {
            Console.WriteLine("Повертаємось до створення.");
            order.State = new CreatedState();
        }

        public void PrintStatus()
        {
            Console.WriteLine("Статус: Водій призначений.");
        }
    }
}
