using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using lab_9.Observer;

namespace lab_9.Shared.Models
{
    public partial class Driver : IOrderObserver
    {
        public void Update(string message)
        {
            Console.WriteLine($"[Водій {FullName}] Отримав оновлення: {message}");
        }
    }
}
