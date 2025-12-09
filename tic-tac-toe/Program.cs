using System.Diagnostics;

namespace tic_tac_toe
{
    internal class Program
    {
        readonly static int size= 0;
        static char[,] Board = new char[size, size];
        static int Player_Cords_x = 0;
        static int Player_Cords_y = 0;
        static char Player_Team = 'x';
        static int Menu_Main_Position = 0;
        readonly static string[] Menu_Main_Options ={ "Play", "Setting", "Quit" };


        public static bool Debug_Mode = true;

        static void Main()
        {
            Console.WriteLine("Tic Tac Toe Game Started");
            Thread.Sleep(1000);
            Console.Clear();
            Play();
            Menu_Main();
        }

        #region Game 

        static void Play()
        {
            Setup_Board(Board);
            Print_Board(Board);

            while (true)
            {
                Select_cell();
                Console.Clear();
                Print_Board(Board);
            }
        }


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
            // check win row
            // check win colum 
            // check win diagonal left --> right
            // check win diagonal right --> left

        }

        static void Switch_Player()
        {
            if (Player_Team == 'x') Player_Team = 'o';
            else if (Player_Team == 'o') Player_Team = 'x';

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

            Console.WriteLine("Players turn: " + Player_Team);
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
            if (Player_Cords_y < 0) Player_Cords_y = (Board.GetLength(0) - 1);
            if (Player_Cords_y > Board.GetLength(0) - 1) Player_Cords_y = 0;
            if (Player_Cords_x < 0) Player_Cords_x = Board.GetLength(1) - 1;
            if (Player_Cords_x > Board.GetLength(1) - 1) Player_Cords_x = 0;



            // Debugg
            if (Debug_Mode)
            {
                Debug.WriteLine("Player at: " + Player_Cords_x + ", " + Player_Cords_y);
            }

            // Select

            if (input == ConsoleKey.Enter) Place_Marker(Player_Cords_x, Player_Cords_y, Player_Team);
        }

        static void Menu_Main()
        {
            while (true)
            {
                // Selector
                for (int i = 0; i < Menu_Main_Options.Length; i++)
                {
                    if (i == Menu_Main_Position)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine(Menu_Main_Options[i]);
                        Console.ResetColor();
                    }
                    else Console.WriteLine(Menu_Main_Options[i]);
                }
                
                // Menu buttons
                ConsoleKey input = Console.ReadKey().Key;
                if (input == ConsoleKey.UpArrow) Menu_Main_Position--;
                if (input == ConsoleKey.DownArrow) Menu_Main_Position++;
                if (input == ConsoleKey.Enter)

                // Boundaries
                if (Menu_Main_Position < 0) Menu_Main_Position = Menu_Main_Options.Length - 1;
                if (Menu_Main_Position > Menu_Main_Options.Length - 1) Menu_Main_Position = 0;

                Console.Clear();
            }
        }

        #endregion

    }
}
