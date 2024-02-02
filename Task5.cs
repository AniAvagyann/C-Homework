using System;

class SaddlePointProgram
{
    static void Main()
    {
        Console.Write("Enter the number of rows (M): ");
        int m = int.Parse(Console.ReadLine());
        Console.Write("Enter the number of columns (N): ");
        int n = int.Parse(Console.ReadLine());

        int[,] matrix = ReadMatrix(m, n);
        FindSaddlePoint(matrix);
    }

    static int[,] ReadMatrix(int m, int n)
    {
        int[,] matrix = new int[m, n];

        Console.WriteLine("Enter the matrix elements:");
        for (int i = 0; i < m; i++)
        {
            for (int j = 0; j < n; j++)
            {
                Console.Write($"Enter element at position ({i + 1},{j + 1}): ");
                matrix[i, j] = int.Parse(Console.ReadLine());
            }
        }

        return matrix;
    }

    static void FindSaddlePoint(int[,] matrix)
    {
        int rows = matrix.GetLength(0);
        int columns = matrix.GetLength(1);

        for (int i = 0; i < rows; i++)
        {
            int maxInRow = matrix[i, 0];
            int columnIndex = 0;
     
            for (int j = 1; j < columns; j++)
            {
                if (matrix[i, j] > maxInRow)
                {
                    maxInRow = matrix[i, j];
                    columnIndex = j;
                }
            }

            bool isSaddlePoint = true;
            for (int k = 0; k < rows; k++)
            {
                if (matrix[k, columnIndex] < maxInRow)
                {
                    isSaddlePoint = false;
                    break;
                }
            }

            if (isSaddlePoint)
            {
                Console.WriteLine($"Saddle point: {maxInRow}, Row: {i + 1}, Column: {columnIndex + 1}");
                return;
            }
        }

        Console.WriteLine("No saddle point");
    }
}
