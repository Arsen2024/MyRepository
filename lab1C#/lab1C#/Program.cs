using System;

class Program
{
    static string CheckPoint(double x, double y, double R)
    {
        double halfR= R/2;

        //Межі квадрата
        bool inSquare = (x >= -halfR && x <= halfR) && (y >= -halfR && y <= halfR);
        bool onSquareBorder = (x == -halfR || x == halfR) || (y == -halfR || y == halfR);

        //Рівняння кіл 
        bool inSircle1 = Math.Pow(x + halfR, 2) + Math.Pow(y - halfR, 2) < Math.Pow(halfR, 2);
        bool onSircle1 = Math.Pow(x + halfR, 2) + Math.Pow(y - halfR, 2) == Math.Pow(halfR, 2);

        bool inSircle2 = Math.Pow(x - halfR, 2) + Math.Pow(y + halfR, 2) < Math.Pow(halfR, 2);
        bool onSircle2 = Math.Pow(x - halfR, 2) + Math.Pow(y + halfR, 2) == Math.Pow(halfR, 2);

        if (inSquare && !inSircle1 && !inSircle2)
            return "Так";
        else if (onSquareBorder || onSircle1 || onSircle2)
            return "На межі";
        else
            return "Ні";
    }

    static void Main()
    {
        Console.Write("Введіть значення R: ");
        double R = Convert.ToDouble(Console.ReadLine());

        Console.Write("Введіть значення x: ");
        double x = Convert.ToDouble(Console.ReadLine());

        Console.Write("Введіть значення y: ");
        double y = Convert.ToDouble(Console.ReadLine());

        string result = CheckPoint(x, y, R);
        Console.WriteLine($"Результат: {result}");
    }

}



