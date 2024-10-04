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
    public Team[,] WinStatus { get; set; }

    public Board()
    {
        Grid = new SmallBoard[3,3];
        for (int i = 0; i < 3; i++)
            for (int j = 0; j < 3; j++)
                Grid[i,j] = new SmallBoard();
        
        for (int i = 0; i < 3; i++)
            for (int j = 0; j < 3; j++)
                WinStatus[i, j] = Team.None;
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
    
    /// <summary>
    /// Checks for any cases of lines of three small boards in a row that are won by one team.
    /// </summary>
    /// <returns>Team.X if the first series of three-in-a-row small boards is of X. Team.O if of O. Team.None if there are no three-in-a-rows.</returns>
    public Team CheckVictory()
    {
        for (int r = 0; r < 3; r++)
        {
            for(int c = 0; c < 3; c++)
            {
                // if there is no victory here, it is not relevant for any three-in-a-rows and may be ignored.
                if (WinStatus[r, c] == Team.None) continue;
                
                // start with this cell and continue in each direction to try 
            }
        }
    }
    
}