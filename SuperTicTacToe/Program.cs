namespace SuperTicTacToe;

internal static class Program
{
    public static int SearchDepth = 5;
    public static Team AiTeam = Team.X;
    
    private static int Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
        Board board = new();
        board.PrintBoard();
        return 0;
    }
}