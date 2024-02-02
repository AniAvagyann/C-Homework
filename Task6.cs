using System;

class RandomMatrix
{
    static void Main()
    {
        Console.Write("Enter the number of rows (N): ");
        int n = int.Parse(Console.ReadLine());

        Console.Write("Enter the number of columns (M): ");
        int m = int.Parse(Console.ReadLine());

        int[,] matrix = FillRandomMatrix(n, m);

        Console.WriteLine("Randomly filled matrix:");
        PrintMatrix(matrix);
    }

    static int[,] FillRandomMatrix(int n, int m)
    {
        int[,] matrix = new int[n, m];
        Random random = new Random();

        int totalNumbers = n * m;
        int[] allNumbers = new int[totalNumbers];
        for (int i = 0; i < totalNumbers; i++)
        {
            allNumbers[i] = i + 1;
        }

        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < m; j++)
            {
                int index = random.Next(allNumbers.Length);
                matrix[i, j] = allNumbers[index];

                allNumbers[index] = allNumbers[allNumbers.Length - 1];
                Array.Resize(ref allNumbers, allNumbers.Length - 1);
            }
        }

        return matrix;
    }

    static void PrintMatrix(int[,] matrix)
    {
        int rows = matrix.GetLength(0);
        int columns = matrix.GetLength(1);

        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < columns; j++)
            {
                Console.Write($"{matrix[i, j]} ");
            }
            Console.WriteLine();
        }
    }
}
