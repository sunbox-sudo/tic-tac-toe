using System.Diagnostics;

namespace tic_tac_toe
{
    internal class Program
    {
        static char[,] Board = new char[3, 3];
        static int Player_Cords_x = 0;
        static int Player_Cords_y = 0;
        static char Player_Team = 'x';
        

        public static bool Debug_Mode = true;

        static void Main(string[] args)
        {
            Console.WriteLine("Tic Tac Toe Game Started");
            Thread.Sleep(1000);
            Console.Clear();
            Setup_Board(Board);
            Print_Board(Board);
            while (true)
            {
                Select_cell();
                Console.Clear();
                Print_Board(Board);
            }
        }

        #region Game 
        static void Setup_Board(char[,] Board) 
        {
            for (int i = 0; i < Board.GetLength(0); i++) 
            { 
                for (int j = 0; j < Board.GetLength(1); j++) 
                {
                    Board[i, j] = '#';
                }
            }
        }


        static void Check_Win() 
        {

        }

        static void Switch_Player() 
        {
            
        }

        static void Place_Marker(int x, int y, char team) 
        {
            if (Board[y, x] == '#')
            {
                Board[y, x] = team;
                Switch_Player();
            }
        }

        #endregion


        #region UI Methods

        static void Print_Board(char[,] Board) 
        { 
            for (int i = 0; i < Board.GetLength(0); i++) 
            {
                for (int j = 0; j < Board.GetLength(1); j++) 
                {
                    if (i == Player_Cords_y && j == Player_Cords_x)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write(Board[i, j] + " ");
                        Console.ResetColor();
                    }
                    else

                        Console.Write(Board[i, j] + " ");
                }
                Console.WriteLine();
            }
        }

        static void Select_cell()
        {
            // Get Input
            ConsoleKey input = Console.ReadKey().Key;
            if (input == ConsoleKey.UpArrow) Player_Cords_y--;
            if (input == ConsoleKey.DownArrow) Player_Cords_y++;
            if (input == ConsoleKey.LeftArrow) Player_Cords_x--;
            if (input == ConsoleKey.RightArrow) Player_Cords_x++;

            // Boundaries
            if (Player_Cords_y < 0) Player_Cords_y = (Board.GetLength(0) -1);
            if (Player_Cords_y > Board.GetLength(0) -1 ) Player_Cords_y = 0;
            if (Player_Cords_x < 0) Player_Cords_x = Board.GetLength(1) -1 ;
            if (Player_Cords_x > Board.GetLength(1) - 1) Player_Cords_x = 0;

            

            // Debugg
            if (Debug_Mode)
            {
                Debug.WriteLine("Player at: " + Player_Cords_x + ", " + Player_Cords_y);
            }

            // Select

            if (input == ConsoleKey.Enter) Place_Marker(Player_Cords_x, Player_Cords_y, Player_Team);
        }

        #endregion

    }
}
