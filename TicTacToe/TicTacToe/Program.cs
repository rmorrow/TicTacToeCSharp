using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    class Program
    {
        //TicTacToe board positions
        private static char[] board = new char[9] { '1', '2', '3', '4', '5', '6', '7', '8', '9' };
        //Winning board will be displayed at end of game
        private static char[] winningBoard = new char[9];
        private String name;
        //List used to store players
        private static List<Program> players = new List<Program>();
        private static String winner;

        public Program(String name)
        {
            Console.Write("What is your name: " + GetPlayerName());
            SetPlayerName(Console.ReadLine());
            Console.WriteLine("Hello " + GetPlayerName());
        }

        public String GetPlayerName()
        {
            return name;
        }

        public void SetPlayerName(String name)
        {
            this.name = name;
        }
        static void Main(string[] args)
        {
            Program player1 = new TicTacToe.Program("player1");
            players.Add(player1);
            Program player2 = new TicTacToe.Program("player2");
            players.Add(player2);
            DrawBoard();
            Console.WriteLine("The players are: " + players[0].GetPlayerName() + " and " + players[1].GetPlayerName());
            StartGame();
            Console.ReadLine();

        }

        //Called everytime the board needs to be redrawn.
        private static void DrawBoard()
        {
            Console.WriteLine();
            for (int i = 0; i < board.Length; i++)
            {

                Console.Write(board[i] + " | ");
                if ((i > 0) && ((i + 1) % 3 == 0))
                    Console.WriteLine("\n ----------");
            }

        }

        //Called only after winner is determined. Used for flashing announcement at end of game.
        private static void DrawWinningBoard()
        {
            Console.WriteLine();
            for (int i = 0; i < winningBoard.Length; i++)
            {

                Console.Write(winningBoard[i] + " | ");
                if ((i > 0) && ((i + 1) % 3 == 0))
                    Console.WriteLine("\n ----------");
            }

        }

        public static void StartGame()
        {
            int turn = 0;
            char character = 'X';
            while (!CheckForWinner())
            {
                Console.WriteLine("Its your play " + players[turn].GetPlayerName() + ". What position would you like to play?");
                int move;

                //Make sure that character entered is an integer
                int.TryParse(Console.ReadLine(), out move);

                //Switches between placing Xs and Os based on whose turn it is
                switch (turn)
                {
                    case 0:
                        character = 'X';
                        break;
                    case 1:
                        character = 'O';
                        break;
                    default:
                        Console.Write("Can't switch case");
                        break;
                }
                if ((move > 0) && (move < 10))
                {
                    if (!(board[move - 1] == 'X') && !(board[move - 1] == 'O'))
                    {
                        board[move - 1] = character;
                        if (CheckForWinner())
                        {
                            winner = players[turn].GetPlayerName();
                            break;
                        }
                        if (turn.Equals(0))
                        {
                            turn = 1;
                        }
                        else
                            turn = 0;
                    }
                    else
                        Console.WriteLine("That is an invalid move. Please try again");
                }
                else
                    Console.WriteLine("That is an invalid move. Please try again");

                

                DrawBoard();

            }
            DisplayWinner(winner);
        }
        //Check for winner after each play
        private static Boolean CheckForWinner()
        {

            //Check to see if player1 won
            if (board[0] == 'X' && board[1] == 'X' && board[2] == 'X')
            {
                Array.Copy(board, winningBoard, board.Length);
                winningBoard[0] = winningBoard[1] = winningBoard[2] = ' ';
                return true;
            }
            else if (board[0] == 'X' && board[1] == 'X' && board[2] == 'X')
            {
                Array.Copy(board, winningBoard, board.Length);
                winningBoard[0] = winningBoard[2] = winningBoard[2] = ' ';
                return true;
            }
            else if (board[3] == 'X' && board[4] == 'X' && board[5] == 'X')
            {
                Array.Copy(board, winningBoard, board.Length);
                winningBoard[3] = winningBoard[4] = winningBoard[5] = ' ';
                return true;
            }
            else if (board[6] == 'X' && board[7] == 'X' && board[8] == 'X')
            {
                Array.Copy(board, winningBoard, board.Length);
                winningBoard[6] = winningBoard[7] = winningBoard[8] = ' ';
                return true;
            }
            else if (board[0] == 'X' && board[3] == 'X' && board[6] == 'X')
            {
                Array.Copy(board, winningBoard, board.Length);
                winningBoard[0] = winningBoard[3] = winningBoard[6] = ' ';
                return true;
            }
            else if (board[1] == 'X' && board[4] == 'X' && board[7] == 'X')
            {

                Array.Copy(board, winningBoard, board.Length);
                winningBoard[1] = winningBoard[4] = winningBoard[7] = ' ';
                return true;
            }
            else if (board[2] == 'X' && board[5] == 'X' && board[8] == 'X')
            {
                Array.Copy(board, winningBoard, board.Length);
                winningBoard[2] = winningBoard[5] = winningBoard[8] = ' ';
                return true;
            }
            else if (board[0] == 'X' && board[4] == 'X' && board[8] == 'X')
            {
                Array.Copy(board, winningBoard, board.Length);
                winningBoard[0] = winningBoard[4] = winningBoard[8] = ' ';
                return true;
            }
            else if (board[2] == 'X' && board[4] == 'X' && board[6] == 'X')
            {
                Array.Copy(board, winningBoard, board.Length);
                winningBoard[2] = winningBoard[4] = winningBoard[6] = ' ';
                return true;
            }

            //Check to see if player2 won
            else if (board[0] == 'O' && board[1] == 'O' && board[2] == 'O')
            {
                Array.Copy(board, winningBoard, board.Length);
                winningBoard[0] = winningBoard[1] = winningBoard[2] = ' ';
                return true;
            }
            else if (board[0] == 'O' && board[1] == 'O' && board[2] == 'O')
            {
                Array.Copy(board, winningBoard, board.Length);
                winningBoard[0] = winningBoard[1] = winningBoard[2] = ' ';
                return true;
            }
            else if (board[3] == 'O' && board[4] == 'O' && board[5] == 'O')
            {
                Array.Copy(board, winningBoard, board.Length);
                winningBoard[3] = winningBoard[4] = winningBoard[5] = ' ';
                return true;
            }
            else if (board[6] == 'O' && board[7] == 'O' && board[8] == 'O')
            {
                Array.Copy(board, winningBoard, board.Length);
                winningBoard[6] = winningBoard[7] = winningBoard[8] = ' ';
                return true;
            }
            else if (board[0] == 'O' && board[3] == 'O' && board[6] == 'O')
            {
                Array.Copy(board, winningBoard, board.Length);
                winningBoard[0] = winningBoard[3] = winningBoard[6] = ' ';
                return true;
            }
            else if (board[1] == 'O' && board[4] == 'O' && board[7] == 'O')
            {
                Array.Copy(board, winningBoard, board.Length);
                winningBoard[1] = winningBoard[4] = winningBoard[7] = ' ';
                return true;
            }
            else if (board[2] == 'O' && board[5] == 'O' && board[8] == 'O')
            {
                Array.Copy(board, winningBoard, board.Length);
                winningBoard[2] = winningBoard[5] = winningBoard[8] = ' ';
                return true;
            }
            else if (board[0] == 'O' && board[4] == 'O' && board[8] == 'O')
            {
                Array.Copy(board, winningBoard, board.Length);
                winningBoard[0] = winningBoard[4] = winningBoard[8] = ' ';
                return true;
            }
            else if (board[2] == 'O' && board[4] == 'O' && board[6] == 'O')
            {
                Array.Copy(board, winningBoard, board.Length);
                winningBoard[2] = winningBoard[4] = winningBoard[6] = ' ';
                return true;
            }

            return false;
        }

        //Displays flashing announcement of winning play
        private static void DisplayWinner(String winner)
        {
            while (1 > 0)
            {
                Console.Clear();
                Console.WriteLine("You Won " + winner + "!!");
                DrawBoard();
                System.Threading.Thread.Sleep(400);
                Console.Clear();
                Console.WriteLine("You Won " + winner + "!!");
                DrawWinningBoard();
                System.Threading.Thread.Sleep(400);

            }
        }

    }
}
