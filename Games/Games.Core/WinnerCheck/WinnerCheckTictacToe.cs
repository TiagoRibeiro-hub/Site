namespace Games.Core;

public static class WinnerCheckTictacToe
{
    internal static bool HaveWinnerMethod(List<string> listMovesPlayer, int nrCol = 3)
    {
        if (Diagonal(listMovesPlayer, nrCol)) return true;
        if (Vertical(listMovesPlayer, nrCol)) return true;
        if (Horizontal(listMovesPlayer, nrCol)) return true;

        return false;
    }
    internal static bool Diagonal(List<string> moves, int nrCol = 3)
    {
        int nextNr_1 = 1;
        int nextNr_2 = nrCol;
        int count_1 = 0, count_2 = 0;

        for (int i = 0; i < moves.Count; i++)
        {
            if(moves[i] == nextNr_1.ToString())
            {
                count_1 += 1;
                nextNr_1 += nrCol + 1;
            }
            if (moves[i] == nextNr_2.ToString())
            {
                count_2 += 1;
                nextNr_2 += nrCol - 1;
            }
            if (count_1 == nrCol || count_2 == nrCol)
            {
                return true;
            }
        }
        return false;
    }
    internal static bool Vertical(List<string> moves, int nrCol = 3)
    {
        if (nrCol == 3)
        {
            if ((moves.Contains("1") && moves.Contains("4") && moves.Contains("7")) ||
                (moves.Contains("2") && moves.Contains("5") && moves.Contains("8")) ||
                (moves.Contains("3") && moves.Contains("6") && moves.Contains("9")))
            {
                return true;
            }
        }
        return false;
    }
    internal static bool Horizontal(List<string> moves, int nrCol = 3)
    {
        if (nrCol == 3)
        {
            if ((moves.Contains("1") && moves.Contains("2") && moves.Contains("3")) ||
                (moves.Contains("4") && moves.Contains("5") && moves.Contains("6")) ||
                (moves.Contains("7") && moves.Contains("8") && moves.Contains("9")))
            {
                return true;
            }
        }
        return false;
    }
}