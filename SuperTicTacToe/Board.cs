using System.Collections;

namespace SuperTicTacToe;

public class Board
{
    // first three items go in the first row, second three in the second row, last three in the last row.
    public class SmallBoard
    {
        public Team[,] Grid { get; set; }

        public SmallBoard()
        {
            Grid = new Team[3, 3];
            
            for (int i = 0; i < 3; i++)
                for (int j = 0; j < 3; j++)
                    Grid[i,j] = Team.None;
        }       
    }
    
    public SmallBoard[,] Grid { get; set; }

    public Board()
    {
        Grid = new SmallBoard[3,3];
        for (int i = 0; i < 3; i++)
            for (int j = 0; j < 3; j++)
                Grid[i,j] = new SmallBoard();
    }
    
    public void PrintBoard()
    {
        Console.WriteLine("-------------------------------");
        for (int bigRow = 0; bigRow < 3; bigRow++)
        {
            for (int smallRow = 0; smallRow < 3; smallRow++)
            {
                Console.Write("|  ");
                
                for(int bigCol = 0; bigCol < 3; bigCol++)
                {
                    for(int smallCol = 0; smallCol < 3; smallCol++)
                    {
                        Team cell = Grid[bigRow, bigCol].Grid[smallRow, smallCol];
                        Console.Write((cell == Team.None ? "\u25a1" : cell) + " ");
                    }
                    
                    Console.Write(" |  ");
                }
            
                Console.WriteLine();
                
            }
            
            Console.WriteLine("-------------------------------");
        }
    }
}