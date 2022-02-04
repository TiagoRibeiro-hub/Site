namespace TicTacToe.Service;
public static class WinnerFuncs
{
    public static (bool, string) IsFinished(int nrOfplayedMove)
    {
        if (nrOfplayedMove == 8)
        {
            return (true, GameState.Tie.ToString());
        }
        return (false, GameState.Continue.ToString());
    }
    public static bool HaveWinnerMethod(Dictionary<int, int> DictMovesPlayer)
    {
        HashSet<int> ListMovesPlayer = new();
        foreach (var move in DictMovesPlayer)
        {
            ListMovesPlayer.Add(move.Value);
        }

        if (Diagonal(ListMovesPlayer)) return true;
        if (Vertical(ListMovesPlayer)) return true;
        if (Horizontal(ListMovesPlayer)) return true;

        return false;
    }
    private static bool Diagonal(HashSet<int> moves)
    {
        if ((moves.Contains(1) && moves.Contains(5) && moves.Contains(9)) ||
            (moves.Contains(3) && moves.Contains(5) && moves.Contains(7)))
        {
            return true;
        }
        return false;
    }
    private static bool Vertical(HashSet<int> moves)
    {
        if ((moves.Contains(1) && moves.Contains(4) && moves.Contains(7)) ||
            (moves.Contains(2) && moves.Contains(5) && moves.Contains(8)) ||
            (moves.Contains(3) && moves.Contains(6) && moves.Contains(9)))
        {
            return true;
        }
        return false;
    }
    private static bool Horizontal(HashSet<int> moves)
    {
        if ((moves.Contains(1) && moves.Contains(2) && moves.Contains(3)) ||
            (moves.Contains(4) && moves.Contains(5) && moves.Contains(6)) ||
            (moves.Contains(7) && moves.Contains(8) && moves.Contains(9)))
        {
            return true;
        }
        return false;
    }
}

