using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_9.Memento
{
    public class OrderHistory
    {
        private readonly Stack<OrderStateMemento> _history = new();

        public void Save(OrderStateMemento memento)
        {
            _history.Push(memento);
        }

        public OrderStateMemento? Undo()
        {
            return _history.Count > 0 ? _history.Pop() : null;
        }
    }
}
