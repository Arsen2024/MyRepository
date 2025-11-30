using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using lab_9.Observer;

namespace lab_9.Shared.Models
{
    public partial class Client : IOrderObserver
    {
        public void Update(string message)
        {
            Console.WriteLine($"[Клієнт {FullName}] Отримав оновлення: {message}");
        }
    }
}
