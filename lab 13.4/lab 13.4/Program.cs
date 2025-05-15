using System;
using System.Net.NetworkInformation;
using System.Threading;

class Program
{
    static string subnet;

    static void Main(string[] args)
    {
        Console.Write("Введіть підмережу (наприклад: 192.168.1.): ");
        subnet = Console.ReadLine();

        // Перевірка через цикл
        for (int i = 1; i < 255; ++i)
        {
            Ping ping = new Ping();
            string ip = subnet + i;
            PingReply pingReply = ping.Send(ip, 1000);
            if (pingReply.Status == IPStatus.Success)
            {
                Console.WriteLine($"Success {ip}");
            }
        }

        // Потік, що показує повідомлення що 3 секунди
        Thread infoThread = new Thread(ThreadFunction);
        infoThread.IsBackground = true;
        infoThread.Start();

        // Перевірка кожного IP через окремий потік
        for (int i = 1; i < 255; ++i)
        {
            Thread thread = new Thread(Function);
            thread.Start(i);
        }

        Console.WriteLine("Натисніть Enter для виходу...");
        Console.ReadLine();
    }

    static void ThreadFunction()
    {
        while (true)
        {
            Console.WriteLine($"Потоки активні... Час: {DateTime.Now:T}");
            Thread.Sleep(3000);
        }
    }

    static void Function(object i)
    {
        try
        {
            int number = (int)i;
            string ip = subnet + number;

            Ping ping = new Ping();
            PingReply pingReply = ping.Send(ip, 1000);

            if (pingReply.Status == IPStatus.Success)
            {
                Console.WriteLine($"Success {ip}");
            }
            else
            {
                Console.WriteLine($"Dead {ip}");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Помилка: {ex.Message}");
        }
    }
}
