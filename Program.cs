using System;

class TicTacToe
{
    // board array
    char[,] board = new char[3, 3];

    // initialize empty board
    void InitBoard()
    {
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                board[i, j] = ' ';
            }
        }
    }

    // print board
    void PrintBoard()
    {
        Console.WriteLine("-------------");
        for (int i = 0; i < 3; i++)
        {
            Console.WriteLine("| {0} | {1} | {2} |", board[i, 0], board[i, 1], board[i, 2]);
            Console.WriteLine("-------------");
        }
    }

    // make move
    void MakeMove(char player, int row, int col)
    {
        board[row, col] = player;
    }

    // check for winner
    char CheckWinner()
    {
        // check rows
        for (int i = 0; i < 3; i++)
            if (board[i, 0] == board[i, 1] && board[i, 1] == board[i, 2])
                return board[i, 0];

        // check columns  
        for (int i = 0; i < 3; i++)
            if (board[0, i] == board[1, i] && board[1, i] == board[2, i])
                return board[0, i];

        // check diagonals
        if (board[0, 0] == board[1, 1] && board[1, 1] == board[2, 2])
            return board[0, 0];

        if (board[0, 2] == board[1, 1] && board[1, 1] == board[2, 0])
            return board[0, 2];

        return ' ';
    }

    static void Main()
    {
        TicTacToe game = new TicTacToe();
        game.InitBoard();

        char player = 'X';

        while (true)
        {
            game.PrintBoard();

            // get input
            Console.Write("Player {0} turn. Enter row and column: ", player);
            int row = int.Parse(Console.ReadLine());
            int col = int.Parse(Console.ReadLine());

            // make move 
            game.MakeMove(player, row, col);

            // check winner
            char winner = game.CheckWinner();
            if (winner != ' ')
            {
                Console.WriteLine("Player {0} wins!", winner);
                break;
            }

            // switch player
            if (player == 'X')
                player = 'O';
            else
                player = 'X';
        }
    }
}
