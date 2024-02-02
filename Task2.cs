using System;

class A
{
    static void Main()
    {
        int[,] matrix = new int[8, 8];
        Console.Write("Enter the row of the queen (0-7): ");
        int row = int.Parse(Console.ReadLine());
        Console.Write("Enter the column of the queen (0-7): ");
        int col = int.Parse(Console.ReadLine());
        MarkPossibleMoves(matrix, row, col);
        DisplayMatrix(matrix);
    }

    static void MarkPossibleMoves(int[,] matrix, int row, int col)
    {
        matrix[row, col] = 2;

        // Mark horizontal and vertical moves
        for (int i = 0; i < 8; i++)
        {
            if (IsValidMove(row, i))
            {
                matrix[row, i] = 1;
            }
            if (IsValidMove(i, col))
            {
                matrix[i, col] = 1;
            }
        }

        // Mark diagonal moves
        for (int i = 1; i < 8; i++)
        {
            if (IsValidMove(row + i, col + i))
            {
                matrix[row + i, col + i] = 1;
            }
            if (IsValidMove(row - i, col - i))
            {
                matrix[row - i, col - i] = 1;
            }
            if (IsValidMove(row + i, col - i))
            {
                matrix[row + i, col - i] = 1;
            }
            if (IsValidMove(row - i, col + i))
            {
                matrix[row - i, col + i] = 1;
            }
        }
    }

    static bool IsValidMove(int row, int col)
    {
        return row >= 0 && row <= 7 && col >= 0 && col <= 7;
    }

    static void DisplayMatrix(int[,] matrix)
    {
        Console.WriteLine("Chessboard with Queen's Possible Positions:");
        for (int i = 0; i < 8; i++)
        {
            for (int j = 0; j < 8; j++)
            {
                if (matrix[i, j] == 0)
                {
                    Console.Write("0 ");
                }
                else if (matrix[i, j] == 2)
                {
                    Console.Write("Q ");
                }
                else
                {
                    Console.Write("X ");
                }
            }
            Console.WriteLine();
        }
    }
}
