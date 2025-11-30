using lab_10.Shared.Models;
using lab_10.State;
using lab_10.Strategy;

namespace lab_10
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            var order = new Order
            {
                Id = Guid.NewGuid(),
                PickupLocation = "Центр",
                Destination = "Аеропорт",
                Price = 250,
                Status = "Створено",
                Client = client,
                Driver = driver
            };

            // Початковий стан
            order.PrintState();

            // Перехід: присвоїти водія
            order.NextState();
            order.PrintState();

            // Перехід: поїздка почалась
            order.NextState();
            order.PrintState();

            // Перехід: завершити поїздку
            order.NextState();
            order.PrintState();

            // Спроба відкотити назад
            order.PrevState();
            order.PrintState();

            // Примусове скасування
            Console.WriteLine("\n Клієнт вирішив скасувати замовлення!");
            order.State = new CancelledState();
            order.PrintState();

            Console.WriteLine("\n Спроба виконати наступний стан:");
            order.NextState();


            var order1 = new Order
            {
                Id = Guid.NewGuid(),
                PickupLocation = "Центр",
                Destination = "ТЦ 'Формат'",
                DistanceKm = 8
            };

            Console.WriteLine($"Відстань: {order.DistanceKm} км\n");

            order.PricingStrategy = new StandardPricing();
            Console.WriteLine("➡ Тариф: Standard");
            order.ApplyPricing();

            order.PricingStrategy = new ComfortPricing();
            Console.WriteLine("➡ Тариф: Comfort");
            order.ApplyPricing();

            order.PricingStrategy = new NightPricing();
            Console.WriteLine("➡ Тариф: Night");
            order.ApplyPricing();

        }
    }
}