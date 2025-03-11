using System;

class Program
{
    static void Main()
    {
        // Введення кількості рядків
        Console.Write("Введіть кількість рядків (n): ");
        int n = int.Parse(Console.ReadLine());

        // Оголошення зубчастого масиву
        int[][] jaggedArray = new int[n][];

        // Заповнення масиву
        InputJaggedArray(jaggedArray);

        // Обчислення сум від’ємних елементів у кожному стовпці
        int[] negativeSums = CalculateNegativeColumnSums(jaggedArray);

        // Вивід результатів
        PrintResults(jaggedArray, negativeSums);
    }

    static void InputJaggedArray(int[][] jaggedArray)
    {
        for (int i = 0; i < jaggedArray.Length; i++)
        {
            Console.Write($"Введіть кількість елементів у рядку {i + 1}: ");
            int m = int.Parse(Console.ReadLine());
            jaggedArray[i] = new int[m];

            Console.WriteLine($"Введіть {m} елемент(и) для рядка {i + 1}:");
            for (int j = 0; j < m; j++)
            {
                jaggedArray[i][j] = int.Parse(Console.ReadLine());
            }
        }
    }

    static int[] CalculateNegativeColumnSums(int[][] jaggedArray)
    {
        // Визначення максимальної довжини рядка (кількість стовпців)
        int maxColumns = 0;
        foreach (var row in jaggedArray)
        {
            if (row.Length > maxColumns)
                maxColumns = row.Length;
        }

        // Масив для сум від’ємних чисел у кожному стовпці
        int[] negativeSums = new int[maxColumns];

        // Обчислення сум від’ємних елементів
        for (int j = 0; j < maxColumns; j++)
        {
            int sum = 0;
            for (int i = 0; i < jaggedArray.Length; i++)
            {
                if (j < jaggedArray[i].Length && jaggedArray[i][j] < 0)
                {
                    sum += jaggedArray[i][j];
                }
            }
            negativeSums[j] = sum;
        }

        return negativeSums;
    }

    static void PrintResults(int[][] jaggedArray, int[] negativeSums)
    {
        Console.WriteLine("\nВхідний зубчастий масив:");
        for (int i = 0; i < jaggedArray.Length; i++)
        {
            Console.WriteLine(string.Join("\t", jaggedArray[i]));
        }

        Console.WriteLine("\nСуми від’ємних елементів у кожному стовпці:");
        for (int j = 0; j < negativeSums.Length; j++)
        {
            Console.WriteLine($"Стовпець {j + 1}: {negativeSums[j]}");
        }
    }
}