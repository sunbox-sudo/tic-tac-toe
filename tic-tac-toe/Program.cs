using System.Diagnostics;

namespace tic_tac_toe
{
    internal class Program
    {
         static char[,] Board = new char[3, 3];

        static void Main(string[] args)
        {
            Debug.WriteLine("Tic Tac Toe Game Started");
            Setup_Board(Board);
            Print_Board(Board);
            Console.ReadLine();
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

        #endregion


        #region UI Methods

        static void Print_Board(char[,] Board) 
        { 
            for (int i = 0; i < Board.GetLength(0); i++) 
            {
                for (int j = 0; j < Board.GetLength(1); j++) 
                {
                    Console.Write(Board[i, j] + " ");
                }
                Console.WriteLine();
            }
        }

        #endregion

    }
}
