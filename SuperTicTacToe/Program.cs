namespace SuperTicTacToe;

internal static class Program
{
    private static int Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
        Board board = new();
        board.PrintBoard();
        return 0;
    }
}