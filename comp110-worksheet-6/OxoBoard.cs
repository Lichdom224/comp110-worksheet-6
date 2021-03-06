﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace comp110_worksheet_6
{
	public enum Mark { None, O, X };

	public class OxoBoard
	{
        // Constructor. Perform any necessary data initialisation here.
        Mark[,] Board;
		// Uncomment the optional parameters if attempting the stretch goal -- keep the default values to avoid breaking unit tests.
		public OxoBoard (int width = 3, int height = 3, int inARow = 3)
		{
            Board = new Mark[width, height];
		}

		// Return the contents of the specified square.
		public Mark GetSquare(int x, int y)
		{
            return Board[x, y];
		}

		// If the specified square is currently empty, fill it with mark and return true.
		// If the square is not empty, leave it as-is and return False.
		public bool SetSquare(int x, int y, Mark mark)
		{
            if (x < Board.GetLongLength(0) && y < Board.GetLongLength(1) && x > -1 && y > -1)
            {
                if (Board[x, y] == Mark.None)
                {
                    Board[x, y] = mark;
                }
            }
            return false;
		}

		// If there are still empty squares on the board, return false.
		// If there are no empty squares, return true.
		public bool IsBoardFull()
		{
            for (int A = 0; A < Board.GetLongLength(0);)
            {
                A + 1;
                for (int B = 0; B < Board.GetLongLength(1);)
                {
                    B + 1;
                    return false;
                }
            }
           return true;
		}

        // If a player has three in a row, return Mark.O or Mark.X depending on which player.
        // Otherwise, return Mark.None.
        public Mark GetWinner()
        {
            for (int Yaxis = 0; Yaxis < Board.GetLongLength(1); )
        {
                Yaxis + 1;
                if (Board[0, Yaxis] == Board[1, Yaxis] && Board[1, Yaxis] == Board[2, Yaxis])
                {
                    if (GetSquare(0, Yaxis) != Mark.None)
                    {
                        return GetSquare(0 ,Yaxis);
                    }
                }
            }
            if (Board[0, 0] == Board[1, 1] && Board[1, 1] == Board[2, 2])
            {
                return GetSquare(0, 0);
            }
            if (Board[2, 0] == Board[1, 1] && Board[1, 1] == Board[0, 2])
            {
                return GetSquare(2, 0);
            }
            return Mark.None;
        }


		// Display the current board state in the terminal. You should only need to edit this if you are attempting the stretch goal.
		public void PrintBoard()
		{
			for (int y = 0; y < 3; y++)
			{
				if (y > 0)
					Console.WriteLine("--+---+--");

				for (int x = 0; x < 3; x++)
				{
					if (x > 0)
						Console.Write(" | ");

					switch (GetSquare(x, y))
					{
						case Mark.None:
							Console.Write(" "); break;
						case Mark.O:
							Console.Write("O"); break;
						case Mark.X:
							Console.Write("X"); break;
					}
				}

				Console.WriteLine();
			}
		}
	}
}

