using System;

class KnightMovement
{
    static int boardSize = 8;
    static int[,] board = new int[boardSize, boardSize];

    static int[] moveX = { 2, 1, -1, -2, -2, -1, 1, 2 };
    static int[] moveY = { 1, 2, 2, 1, -1, -2, -2, -1 };

    static Random random = new Random();

    static void Main()
    {
        int startX = random.Next(boardSize);
        int startY = random.Next(boardSize);

        Console.WriteLine($"Starting position: ({startX}, {startY})");

        int steps = MoveKnight(startX, startY);

        PrintBoard();
        Console.WriteLine($"Number of steps: {steps}");
    }

    static int MoveKnight(int x, int y)
    {
        int steps = 0;

        while (TryMoveKnight(ref x, ref y))
        {
            steps++;
        }

        return steps;
    }

    static bool TryMoveKnight(ref int x, ref int y)
    {
        board[x, y] = 1;

        for (int i = 0; i < 8; i++)
        {
            int newX = x + moveX[i];
            int newY = y + moveY[i];

            if (IsValidMove(newX, newY) && board[newX, newY] == 0)
            {
                x = newX;
                y = newY;
                return true;
            }
        }

        return false;
    }

    static bool IsValidMove(int x, int y)
    {
        return x >= 0 && x < boardSize && y >= 0 && y < boardSize;
    }

    static void PrintBoard()
    {
        Console.WriteLine("Board after knight's movement:");
        for (int i = 0; i < boardSize; i++)
        {
            for (int j = 0; j < boardSize; j++)
            {
                Console.Write($"{board[i, j]} ");
            }
            Console.WriteLine();
        }
    }
}
