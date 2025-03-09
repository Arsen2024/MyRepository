using System;

class Program
{
    static Random random = new Random();

    // Генерація матриці
    static int[,] GenerateMatrix(int rows, int cols)
    {
        int[,] matrix = new int[rows, cols];
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                matrix[i, j] = random.Next(-50, 50); // Числа в діапазоні -50…49
            }
        }
        return matrix;
    }

    // Виведення матриці
    static void PrintMatrix(int[,] matrix)
    {
        int rows = matrix.GetLength(0);
        int cols = matrix.GetLength(1);
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                Console.Write(matrix[i, j] + "\t");
            }
            Console.WriteLine();
        }
    }

    // Знаходимо максимальний та мінімальний елементи по модулю
    static (int maxAbsValue, int minAbsValue, (int, int) maxPosition, (int, int) minPosition) GetMaxMinAbsValues(int[,] matrix)
    {
        int maxAbsValue = matrix[0, 0];
        int minAbsValue = matrix[0, 0];
        (int, int) maxPosition = (0, 0); 
        (int, int) minPosition = (0, 0); 

        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                int element = matrix[i, j];

                // Порівнюємо по абсолютному значенню
                if (Math.Abs(element) > Math.Abs(maxAbsValue))
                {
                    maxAbsValue = element;
                    maxPosition = (i, j); 
                }

                if (Math.Abs(element) < Math.Abs(minAbsValue))
                {
                    minAbsValue = element;
                    minPosition = (i, j); 
                }
            }
        }

        return (maxAbsValue, minAbsValue, maxPosition, minPosition);
    }

    // Метод для знаходження позиції елемента в матриці
    static (int row, int col) GetElementPosition(int[,] matrix, int element)
    {
        for (int row = 0; row < matrix.GetLength(0); row++)
        {
            for (int col = 0; col < matrix.GetLength(1); col++)
            {
                if (matrix[row, col] == element)
                {
                    return (row, col);
                }
            }
        }
        return (-1, -1); // Якщо елемент не знайдений
    }

    // Підрахунок кількості та суми елементів, що не перебувають між мінімальним і максимальним по модулю
    static (int count, int sum) CountAndSumOutside(int[,] matrix, int maxAbsValue, int minAbsValue)
    {
        int count = 0;
        int sum = 0;

        // Знаходимо позиції максимального та мінімального елементів
        (int maxRow, int maxCol) = GetElementPosition(matrix, maxAbsValue);
        (int minRow, int minCol) = GetElementPosition(matrix, minAbsValue);
     
        foreach (var element in matrix)
        {
            (int row, int col) = GetElementPosition(matrix, element);

            // Якщо елемент не між максимальним і мінімальним за розташуванням
            if (!(row > minRow && row < maxRow || (row == minRow && col > minCol) || (row == maxRow && col < maxCol)))
            {
                count++;
                sum += element;
            }
        }

        return (count, sum);
    }

    static void Main(string[] args)
    {
        int rows = 5;
        int cols = 7;

        // Генерація та виведення матриці
        int[,] matrix = GenerateMatrix(rows, cols);
        Console.WriteLine("Згенерована матриця:");
        PrintMatrix(matrix);

        // Знаходимо максимальний та мінімальний елементи по модулю
        var (maxAbsValue, minAbsValue, maxPosition, minPosition) = GetMaxMinAbsValues(matrix);

        // Виводимо максимальний та мінімальний елементи по модулю
        Console.WriteLine($"\nМаксимальний елемент по модулю: {maxAbsValue}");
        Console.WriteLine($"Мінімальний елемент по модулю: {minAbsValue}");   

        // Підрахунок кількості та суми елементів, що не перебувають між максимальним та мінімальним
        var (countOutside, sumOutside) = CountAndSumOutside(matrix, maxAbsValue, minAbsValue);

        // Виведення кількості і суми елементів, що не перебувають між максимальним і мінімальним
        Console.WriteLine($"Кількість елементів, що не перебувають між максимальним і мінімальним: {countOutside}");
        Console.WriteLine($"Сума елементів, що не перебувають між максимальним і мінімальним: {sumOutside}");
    }

}