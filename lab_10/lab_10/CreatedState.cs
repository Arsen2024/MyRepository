using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_10.State
{
    public class CreatedState : IOrderState
    {
        public void Next(Order order)
        {
            Console.WriteLine("Водія призначено!");
            order.State = new AssignedState();
        }

        public void Prev(Order order)
        {
            Console.WriteLine("Неможливо повернутись назад. Замовлення щойно створено.");
        }

        public void PrintStatus()
        {
            Console.WriteLine("Статус: Замовлення створено.");
        }
    }
}
