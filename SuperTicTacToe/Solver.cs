namespace SuperTicTacToe;

public class Solver
{
    public static double Minimax(Board board, TurnInfo turn, int depth)
    {
        // 1. check if we've reached full depth. If so, evaluate the score of the board and return immediately.
        Team victory = board.CheckVictory();
        switch (victory)
        {
            case Team.None:
                break;
            case Team.X:
                return Program.AiTeam == Team.X ? 100.0 : -100.0;
            case Team.O:
                return Program.AiTeam == Team.O ? 100.0 : -100.0;
                
        }
        
        // 2. iterate through every cell in the small board represented in turn which hasn't already been moved in.
        for (int r = 0; r < 3; r++)
        {
            for (int c = 0; c < 3; c++)
            {
                if (board.Grid[turn.Position.Y, turn.Position.X].Grid[r, c] != Team.None) continue;
                
                // 2.1 deep clone the board
                Board newBoard = board.DeepClone();
                
                // make the move for the given team
                
            }
        }
    }
}