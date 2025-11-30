using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_9.Memento
{
    public class OrderStateMemento
    {
        public string State { get; }
        public DateTime Timestamp { get; }

        public OrderStateMemento(string state)
        {
            State = state;
            Timestamp = DateTime.Now;
        }
    }
}
