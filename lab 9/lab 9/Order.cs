using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using lab_9.Memento;
using lab_9.Observer;

namespace lab_9.Shared.Models
{
    public partial class Order
    {
        private readonly List<IOrderObserver> _observers = new();

        public OrderStateMemento SaveState()
        {
            return new OrderStateMemento(Status);
        }

        public void RestoreState(OrderStateMemento memento)
        {
            Status = memento.State;
        }

        public void AttachObserver(IOrderObserver observer)
        {
            _observers.Add(observer);
        }

        public void DetachObserver(IOrderObserver observer)
        {
            _observers.Remove(observer);
        }

        private void NotifyObservers(string message)
        {
            foreach (var observer in _observers)
            {
                observer.Update(message);
            }
        }

        public void UpdateStatus(string newStatus)
        {
            Status = newStatus;
            NotifyObservers($"Статус замовлення [{Id}] змінено на: {Status}");
        }
    }

}