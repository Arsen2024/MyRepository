using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_10.State
{
    public interface IOrderState
    {
        void Next(Order order);
        void Prev(Order order);
        void PrintStatus();
    }
}
