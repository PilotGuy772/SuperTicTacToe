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
        
        public Team CheckVictory()
        {
            // iterate through rows
            for (int r = 0; r < 3; r++)
                if (Grid[r,0] == Grid[r,1] && Grid[r,1] == Grid[r,2] && Grid[r,0] != Team.None)
                    return Grid[r,0];
            
            // iterate through columns
            for (int c = 0; c < 3; c++)
                if (Grid[0, c] == Grid[1, c] && Grid[1, c] == Grid[2, c] && Grid[0, c] != Team.None)
                    return Grid[0, c];
            
            // check diagonals
            if (Grid[0,0] == Grid[1,1] && Grid[1,1] == Grid[2,2] && Grid[0,0] != Team.None)
                return Grid[0,0];
            
            if (Grid[0,2] == Grid[1,1] && Grid[1,1] == Grid[2,0] && Grid[0,2] != Team.None)
                return Grid[0,2];
            
            // otherwise no victory, return none
            return Team.None;
            
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
        // iterate through rows
        for (int r = 0; r < 3; r++)
            if (WinStatus[r,0] == WinStatus[r,1] && WinStatus[r,1] == WinStatus[r,2] && WinStatus[r,0] != Team.None)
                return WinStatus[r,0];
            
        // iterate through columns
        for (int c = 0; c < 3; c++)
            if (WinStatus[0, c] == WinStatus[1, c] && WinStatus[1, c] == WinStatus[2, c] && WinStatus[0, c] != Team.None)
                return WinStatus[0, c];
            
        // check diagonals
        if (WinStatus[0,0] == WinStatus[1,1] && WinStatus[1,1] == WinStatus[2,2] && WinStatus[0,0] != Team.None)
            return WinStatus[0,0];
            
        if (WinStatus[0,2] == WinStatus[1,1] && WinStatus[1,1] == WinStatus[2,0] && WinStatus[0,2] != Team.None)
            return WinStatus[0,2];
            
        // otherwise no victory, return none
        return Team.None;
    }

    public Board DeepClone()
    {
        Board newBoard = new Board();
        // clone each cell one at a time
        for (int bigRow = 0; bigRow < 3; bigRow++)
        {
            for (int bigCol = 0; bigCol < 3; bigCol++)
            {
                for (int smallRow = 0; smallRow < 3; smallRow++)
                {
                    for (int smallCol = 0; smallCol < 3; smallCol++)
                    {
                        // structs are value types so it's okay
                        newBoard.Grid[bigRow, bigCol].Grid[smallRow, smallCol] = this.Grid[bigRow, bigCol].Grid[smallRow, smallCol];
                    }
                }
            }
        }
        
        // clone the winStatus list one at a time
        for (int r = 0; r < 3; r++)
        {
            for (int c = 0; c < 3; c++)
            {
                newBoard.Grid[r, c] = this.Grid[r, c];
            }
        }

        return newBoard;
    }
    
    
    public void Move(Team turn, (int y, int x) bigBoardIndex, (int y, int x) smallBoardIndex)
    {
        // first, change the given cell to the requested team
        Grid[bigBoardIndex.y, bigBoardIndex.x].Grid[smallBoardIndex.y, smallBoardIndex.x] = turn;
        
        // then, check if this board has had a victory
        Team victory = Grid[bigBoardIndex.y, bigBoardIndex.x].CheckVictory();
        
        // if so, update the win status array
        if (victory != Team.None)
            WinStatus[bigBoardIndex.y, bigBoardIndex.x] = victory;
        
    }
}
    
