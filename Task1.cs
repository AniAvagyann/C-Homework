using System;

class A
{
    static void Main()
    {
        int[,] matrix = new int[8, 8];
        Console.Write("Enter the row of the knight (0-7): ");
        int row = int.Parse(Console.ReadLine());
        Console.Write("Enter the column of the knight (0-7): ");
        int col = int.Parse(Console.ReadLine());
        MarkPossibleMoves(matrix, row, col);
        DisplayMatrix(matrix);
    }

    static void MarkPossibleMoves(int[,] matrix, int row, int col)
    {
        int[] knightMovesRow = { -2, -1, 1, 2, 2, 1, -1, -2 };
        int[] knightMovesCol = { 1, 2, 2, 1, -1, -2, -2, -1 };
        matrix[row, col] = 2;

        for (int i = 0; i < 8; i++)
        {
            int newRow = row + knightMovesRow[i];
            int newCol = col + knightMovesCol[i];

            if (IsValidMove(newRow, newCol))
            {
                matrix[newRow, newCol] = 1;
            }
        }
    }

    static bool IsValidMove(int row, int col)
    {
        return row >= 0 && row <= 7 && col >= 0 && col <= 7;
    }

    static void DisplayMatrix(int[,] matrix)
    {
        Console.WriteLine("Chessboard with Knight's Possible Positions in One Step:");
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
                    Console.Write("K ");
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
