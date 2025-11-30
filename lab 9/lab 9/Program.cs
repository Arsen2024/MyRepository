using lab_9.Shared.Models;
using lab_9.Memento;


class Program
{
    static void Main()
    {
        var order = new Order
        {
            Id = Guid.NewGuid(),
            PickupLocation = "Центр",
            Destination = "ЖД вокзал",
            Status = "Створено"
        };

        var history = new OrderHistory();

        // Зберігаємо поточний стан
        history.Save(order.SaveState());
        order.Status = "В дорозі";

        history.Save(order.SaveState());
        order.Status = "Завершено";

        Console.WriteLine($"Поточний статус: {order.Status}");

        // Повертаємо стан назад
        var prevState = history.Undo();
        if (prevState != null)
            order.RestoreState(prevState);

        Console.WriteLine($"Статус після скасування: {order.Status}");

        var client = new Client { FullName = "Арсеній" };
        var driver = new Driver { FullName = "Петро" };

        var order = new Order
        {
            Id = Guid.NewGuid(),
            PickupLocation = "Майдан",
            Destination = "Аеропорт",
            Status = "Створено"
        };

        order.AttachObserver(client);
        order.AttachObserver(driver);

        order.UpdateStatus("Виконується");
        order.UpdateStatus("Завершено");
    }
}