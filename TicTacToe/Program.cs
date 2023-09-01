using System.Diagnostics.Metrics;
using System.Reflection;

namespace TicTacToe
{
    internal class Program
    {
        private static string[,] board = new string[3, 3] { { "1", "2", "3" }, { "4", "5", "6" }, { "7", "8", "9" } };
        
        private static int turns = 0;
        
        static void Main(string[] args)
        {
            
            int player = 2;
            Boolean inputCorrect = false;
            int gameInput = 0;

            do
            {


                if (player == 2)
                {
                    player = 1;
                    GridEntry(player, gameInput);
                }
                else if (player == 1) { 
                    player = 2;
                    GridEntry(player, gameInput);
                }
                setUp(board);

                //check winning cinditions
                string[] playerSigns = { "O", "x" };

                foreach (string playerSign in playerSigns) {
                    if (((board[0, 0] == playerSign) && (board[0, 1] == playerSign) && (board[0, 2] == playerSign))
                        || ((board[1, 0] == playerSign) && (board[1, 1] == playerSign) && (board[1, 2] == playerSign))
                        || ((board[2, 0] == playerSign) && (board[2, 1] == playerSign) && (board[2, 2] == playerSign))
                        || ((board[0, 0] == playerSign) && (board[1, 0] == playerSign) && (board[2, 0] == playerSign))
                        || ((board[0, 1] == playerSign) && (board[1, 1] == playerSign) && (board[2, 1] == playerSign))
                        || ((board[2, 0] == playerSign) && (board[2, 1] == playerSign) && (board[2, 2] == playerSign))
                        || ((board[0, 0] == playerSign) && (board[1, 1] == playerSign) && (board[2, 2] == playerSign))
                        || ((board[2, 0] == playerSign) && (board[1, 1] == playerSign) && (board[0, 2] == playerSign))
                        )
                    {
                        string winner = playerSign == "X" ? "Player 2 has won!" : "Player 2 has wone!";
                        Console.WriteLine(winner);
                        Console.WriteLine("Please press any key to reset the game!");
                        Console.ReadKey();
                        resetField();
                        break;
                    }
                    else if (turns == 10) {
                        Console.WriteLine("There was a tie!");
                        Console.WriteLine("Please press any key to reset the game!");
                        Console.ReadKey();
                        resetField();
                        break;
                    }

                }
                
                

                // check if field is already taken
                do {
                    Console.Write("\nPlayer {0}: choose your field! ", player);
                    try
                    {
                        gameInput = Convert.ToInt32(Console.ReadLine());
                    }
                    catch {
                        Console.WriteLine("Please enter a number available on the grid!");
                    }

                    if ((gameInput == 1) && (board[0, 0] == "1"))
                    {
                        inputCorrect = true;
                    }
                    else if ((gameInput == 2) && (board[0, 1] == "2"))
                    {
                        inputCorrect = true;
                    }
                    else if ((gameInput == 3) && (board[0, 2] == "3"))
                    {
                        inputCorrect = true;
                    }
                    else if ((gameInput == 4) && (board[1, 0] == "4"))
                    {
                        inputCorrect = true;
                    }
                    else if ((gameInput == 5) && (board[1, 1] == "5"))
                    {
                        inputCorrect = true;
                    }
                    else if ((gameInput == 6) && (board[1, 2] == "6"))
                    {
                        inputCorrect = true;
                    }
                    else if ((gameInput == 7) && (board[2, 0] == "7"))
                    {
                        inputCorrect = true;
                    }
                    else if ((gameInput == 8) && (board[2, 1] == "8"))
                    {
                        inputCorrect = true;
                    }
                    else if ((gameInput == 9) && (board[2, 2] == "9"))
                    {
                        inputCorrect = true;
                    }
                    else {
                        Console.WriteLine("The field you chose isn't available! please choose a different field!");
                        inputCorrect = false;
                    }
                } while (!inputCorrect);
            } while (true);



        }

        public static void resetField() {
            string[,] boardInitial = new string[3, 3] { { "1", "2", "3" }, { "4", "5", "6" }, { "7", "8", "9" } };
            board = boardInitial;
            turns = 0;
            setUp(board);
        }

        public static void setUp(string[,] board)
        {
            turns++;
            Console.Clear();
            for (int h = 0; h < 8; h++)
            {
                if (h == 3 || h == 6)
                {
                    Console.WriteLine("-------------------------");
                }

                if (h == 1)
                {
                    Console.WriteLine("    {0}\t|" + "   {1}\t|" + "   {2}", board[0, 0], board[0, 1], board[0, 2]);
                    continue;
                }

                if (h == 4)
                {
                    Console.WriteLine("    {0}\t|" + "   {1}\t|" + "   {2}", board[1, 0], board[1, 1], board[1, 2]);
                    continue;
                }

                if (h == 7)
                {
                    Console.WriteLine("    {0}\t|" + "   {1}\t|" + "   {2}", board[2, 0], board[2, 1], board[2, 2]);
                    continue;
                }
                for (int i = 1; i < 3; i++)
                {

                    Console.Write("\t|");

                }
                Console.WriteLine();
            }
            Console.WriteLine("\t|\t|");


        }

        public static void GridEntry(int player, int input) {
            string playerSign = " ";

            if (player == 1) {
                playerSign = "X";
            }
            if (player == 2)
            {
                playerSign = "O";
            }

            switch (input)
            {
                case 1:
                    if (board[0, 0] != "X" && board[0, 0] != "O")
                    {
                        board[0, 0] = playerSign;
                        
                    }
                    break;
                case 2:
                    if (board[0, 1] != "X" && board[0, 1] != "O")
                    {
                        board[0, 1] = playerSign;
                        
                    }
                    break;
                case 3:
                    if (board[0, 2] != "X" && board[0, 2] != "O")
                    {
                        board[0, 2] = playerSign;
                        
                    }

                    break;
                case 4:
                    if (board[1, 0] != "X" && board[1, 0] != "O")
                    {
                        board[1, 0] = playerSign;
                        
                    }

                    break;
                case 5:
                    if (board[1, 1] != "X" && board[1, 1] != "O")
                    {
                        board[1, 1] = playerSign;
                        
                    }

                    break;
                case 6:
                    if (board[1, 2] != "X" && board[1, 2] != "O")
                    {
                        board[1, 2] = playerSign;
                        
                    }

                    break;
                case 7:
                    if (board[2, 0] != "X" && board[2, 0] != "O")
                    {
                        board[2, 0] = playerSign;
                        
                    }

                    break;
                case 8:
                    if (board[2, 1] != "X" && board[2, 1] != "O")
                    {
                        board[2, 1] = playerSign;
                        
                    }

                    break;
                case 9:
                    if (board[2, 2] != "X" && board[2, 2] != "O")
                    {
                        board[2, 2] = playerSign;
                        
                    }

                    break;

            }
        }
    }
}
