namespace TicTacToe_2._0
{
    internal class Program
    {
        static void Main(string[] args)
        {   //Display logo
            Greeting();
            Console.WriteLine();
            Console.WriteLine("Press enter to start...");
            Console.ReadKey();
            int gameStatus = 0;
            int currentPlayer = -1;
            //Game board is a charArray
            char[] gameMarkers = new char[9] { '1', '2', '3', '4', '5', '6', '7', '8', '9' };

            do // we loop until we have a winner or draw
            {
                Console.Clear();
                // we pass currentPlayer and get next player
                currentPlayer = GetNextPlayer(currentPlayer);

                //display welcome msg and whos turn it is
                Welcome(currentPlayer);
                PrintBoard(gameMarkers);


                GameEngine(gameMarkers, currentPlayer);


                gameStatus = CheckForWinner(gameMarkers);

            } while (gameStatus.Equals(0));

            Console.Clear();
            Welcome(currentPlayer);
            PrintBoard(gameMarkers);

            if (gameStatus.Equals(1))
            {
                Console.WriteLine($"\nGame over! Player {currentPlayer} is the winner!");
            }

            if (gameStatus.Equals(2))
            {
                Console.WriteLine($"\nGame over! It´s a draw!");
            }


        }

        private static int CheckForWinner(char[] gameMarkers)
        {

            if (IsGameWinner(gameMarkers))
            {
                return 1;
            }

            // 3.3 If all markers are placed and no winner then it's a draw stop the game
            if (IsGameDraw(gameMarkers))
            {
                return 2;
            }

            return 0;

        }

        private static bool IsGameDraw(char[] gameMarkers)
        {
            return gameMarkers[0] != '1' &&
                   gameMarkers[1] != '2' &&
                   gameMarkers[2] != '3' &&
                   gameMarkers[3] != '4' &&
                   gameMarkers[4] != '5' &&
                   gameMarkers[5] != '6' &&
                   gameMarkers[6] != '7' &&
                   gameMarkers[7] != '8' &&
                   gameMarkers[8] != '9';


        }

        private static bool IsGameWinner(char[] gameMarkers)
        {
            if (IsGameMarkersTheSame(gameMarkers, 0, 1, 2))
            {
                return true;
            }
            if (IsGameMarkersTheSame(gameMarkers, 3, 4, 5))
            {
                return true;
            }
            if (IsGameMarkersTheSame(gameMarkers, 6, 7, 8))
            {
                return true;
            }
            if (IsGameMarkersTheSame(gameMarkers, 0, 3, 6))
            {
                return true;
            }
            if (IsGameMarkersTheSame(gameMarkers, 1, 4, 7))
            {
                return true;
            }
            if (IsGameMarkersTheSame(gameMarkers, 2, 5, 8))
            {
                return true;
            }
            if (IsGameMarkersTheSame(gameMarkers, 0, 4, 8))
            {
                return true;
            }
            if (IsGameMarkersTheSame(gameMarkers, 2, 4, 6))
            {
                return true;
            }
            return false;
        }

        private static bool IsGameMarkersTheSame(char[] testGameMarkers, int pos1, int pos2, int pos3)
        {
            return testGameMarkers[pos1].Equals(testGameMarkers[pos2]) && testGameMarkers[pos2].Equals(testGameMarkers[pos3]);
        }

        private static void GameEngine(char[] gameMarkers, int currentPlayer)
        {
            bool validMove = true;
            do
            {

                string? userInput = Console.ReadLine();

                if (!string.IsNullOrEmpty(userInput) &&
                   (userInput.Equals("1") ||
                    userInput.Equals("2") ||
                    userInput.Equals("3") ||
                    userInput.Equals("4") ||
                    userInput.Equals("5") ||
                    userInput.Equals("6") ||
                    userInput.Equals("7") ||
                    userInput.Equals("8") ||
                    userInput.Equals("9")))
                {


                    int.TryParse(userInput, out var gamePlaceMarkers);

                    char currentMarker = gameMarkers[gamePlaceMarkers - 1];

                    if (currentMarker.Equals('X') || currentMarker.Equals('O'))
                    {
                        Console.WriteLine("Occupied, try again!");

                    }
                    else
                    {
                        gameMarkers[gamePlaceMarkers - 1] = GetPlayerMarker(currentPlayer);
                        validMove = false;
                    }

                }


            } while (validMove);

        }

        private static char GetPlayerMarker(int player)
        {
            // if(player.Equals(1))return X
            if (player % 2 == 0)
            {
                return 'O';
            }
            return 'X';
        }

        static void PrintBoard(char[] mark)
        {
            Console.WriteLine($"    {mark[0]} | {mark[1]} | {mark[2]} ");
            Console.WriteLine("   ---+---+---");
            Console.WriteLine($"    {mark[3]} | {mark[4]} | {mark[5]} ");
            Console.WriteLine("   ---+---+---");
            Console.WriteLine($"    {mark[6]} | {mark[7]} | {mark[8]} ");
        }

        static int GetNextPlayer(int player)
        {
            if (player.Equals(1))
            {
                return 2;
            }

            return 1;
        }

        static void Welcome(int playerNumber)
        {

            Console.WriteLine();
            Console.WriteLine("****************");
            Console.WriteLine("* Player 1: X  *");
            Console.WriteLine("* Player 2: O  *");
            Console.WriteLine("****************");
            Console.WriteLine();
            Console.WriteLine($"Turn: Player {playerNumber}");
            Console.WriteLine();
        }

        static void Greeting()
        {
            Console.WriteLine("\r\n  _____   ___    ___   _____     _      ___   _____    ___    ___ \r\n |_   _| |_ _|  / __| |_   _|   /_\\    / __| |_   _|  / _ \\  | __|\r\n   | |    | |  | (__    | |    / _ \\  | (__    | |   | (_) | | _| \r\n   |_|   |___|  \\___|   |_|   /_/ \\_\\  \\___|   |_|    \\___/  |___|\r\n\r\n");
            Console.WriteLine();
        }
    }
}