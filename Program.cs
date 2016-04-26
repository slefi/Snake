using System;
using SdlDotNet.Core;
using SdlDotNet.Graphics;

namespace Snake
{
	class Game
	{
		public static void Main ( string[] args)
		{
			Video.SetVideoMode( 800, 600, 32, false, false, false, true);
			Events.Quit += new EventHandler<QuitEventArgs> ( ApplicationQuitEventHandler );
			Events.Run();
		}
		
		private static void ApplicationQuitEventHandler ( object sender, QuitEventArgs args ) 
		{
			Events.QuitApplication();
		}
	}
	
	class Board
	{
		private int Size { get; set; }
		private Dictionary Screen { get; set; }
		private int PixelSize { get; set; }
		private int[,] board { get; set; }
		
		public Board ( int size , Dictionary screen) 
		{
			/* Assign variables*/
			Size = size;
			Screen = screen;
			
			/* Reikna stærð kassanna í gridinu á skjánum */
			int minSize = Screen["width"] >= Screen["height"] ? Screen["width"] : Screen["height"];
			PixelSize = minSize / Size;
			
			/* Initializa borðið */
			board = Generate( Size );
		}
		
		/* Býr til og fyllir borðið */
		private static int[,] Generate (int size) {
			int[,] b = new int[size, size];
			
			for (int rows = 0; rows < size; rows++) {
				for (int columns = 0; columns < size; columns++) {
					b[rows, columns] = 0;
				}
			}
		}
		
		
		/* Checkar hvort næsta hreyfing er gild */
		public bool isColliding ( Dictionary position, Dictionary newPosition, bool orb = false)
		{
			contents = board[newPosition["x"], newPosition["y"]];
			if (!orb) {
				if (contents == 1)
					return true;
				return false;
			}
			else{
				if (contents == 2)
					return true;
				return false;
			}
		}
		
		/* Breyta borðinu */
		public void Draw ( Dictionary position, int type )
		{
			board[position["x"], position["y"]] = type;
		}
		
		public void Erase ( Dictionary position )
		{
			Draw(position, 0);
		}
		
	}
	
	class Snake
	{
		int Size { get; set; }
		SdlColor color { get; set; }
		int speed { get; set; }
		
	}
}
