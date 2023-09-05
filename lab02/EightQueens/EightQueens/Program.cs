using System;

class EightQueensSolver
{
    static Random randomNumbers = new Random();
    static bool[,] board = new bool[8, 8];
    static int[,] access =
    {
        { 22, 22, 22, 22, 22, 22, 22, 22 },
        { 22, 24, 24, 24, 24, 24, 24, 22 },
        { 22, 24, 26, 26, 26, 26, 24, 22 },
        { 22, 24, 26, 28, 28, 26, 24, 22 },
        { 22, 24, 26, 28, 28, 26, 24, 22 },
        { 22, 24, 26, 26, 26, 26, 24, 22 },
        { 22, 24, 24, 24, 24, 24, 24, 22 },
        { 22, 22, 22, 22, 22, 22, 22, 22 }
    };
    static int maxAccess = 99;
    static int queens = 0;

    static void Main(string[] args)
    {
        SolveEightQueens();
        PrintBoard();
    }

    static void SolveEightQueens()
    {
        while (queens < 8)
        {
            int accessNumber = maxAccess;
            int currentRow = -1;
            int currentColumn = -1;

            // Find the square with the smallest elimination number
            for (int row = 0; row < 8; row++)
            {
                for (int col = 0; col < 8; col++)
                {
                    if (access[row, col] < accessNumber && !board[row, col])
                    {
                        accessNumber = access[row, col];
                        currentRow = row;
                        currentColumn = col;
                    }
                }
            }

            // No valid moves left
            if (accessNumber == maxAccess)
                break;

            board[currentRow, currentColumn] = true;
            UpdateAccess(currentRow, currentColumn);
            queens++;
        }
    }

    static void UpdateAccess(int row, int column)
    {
        for (int i = 0; i < 8; i++)
        {
            access[row, i] = maxAccess;
            access[i, column] = maxAccess;
        }

        UpdateDiagonals(row, column);
    }

    static void UpdateDiagonals(int row, int col)
    {
        for (int i = 0; i < 8; i++)
        {
            if (ValidMove(row - i, col - i))
                access[row - i, col - i] = maxAccess;

            if (ValidMove(row - i, col + i))
                access[row - i, col + i] = maxAccess;

            if (ValidMove(row + i, col - i))
                access[row + i, col - i] = maxAccess;

            if (ValidMove(row + i, col + i))
                access[row + i, col + i] = maxAccess;
        }
    }

    static bool ValidMove(int row, int col)
    {
        return row >= 0 && row < 8 && col >= 0 && col < 8;
    }

    static void PrintBoard()
    {
        Console.Write("  ");
        for (int k = 0; k < 8; k++)
            Console.Write(" {0}", k);

        Console.WriteLine("\n");

        for (int row = 0; row < 8; row++)
        {
            Console.Write("{0} ", row);
            for (int col = 0; col < 8; col++)
                Console.Write(board[row, col] ? " Q" : " .");

            Console.WriteLine();
        }

        Console.WriteLine("\n{0} queens placed on the board.", queens);
    }
}
