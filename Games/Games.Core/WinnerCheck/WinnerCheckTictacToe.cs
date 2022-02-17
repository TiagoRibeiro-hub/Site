namespace Games.Core;

public static class WinnerCheckTictacToe
{
    internal static bool HaveWinner(List<string> listMovesPlayer, int nrCol)
    {
        if (Diagonal(listMovesPlayer, nrCol)) return true;
        if (Vertical(listMovesPlayer, nrCol)) return true;
        if (Horizontal(listMovesPlayer, nrCol)) return true;

        return false;
    }
    internal static bool Diagonal(List<string> moves, int nrCol)
    {
        int nextNr_Diagonal1 = 1;
        int nextNr_Diagonal2 = nrCol;
        int count_1 = 0, count_2 = 0;
        foreach (var move in moves)
        {
            if (move == nextNr_Diagonal1.ToString())
            {
                count_1 += 1;
                nextNr_Diagonal1 += nrCol + 1;
            }
            if (move == nextNr_Diagonal2.ToString())
            {
                count_2 += 1;
                nextNr_Diagonal2 += nrCol - 1;
            }
            if (count_1 == nrCol || count_2 == nrCol)
            {
                return true;
            }
        }
        return false;
    }
    internal static bool Vertical(List<string> moves, int nrCol)
    {
        List<List<string>> listPossibleInLine = new();
        for (int i = 1; i <= nrCol; i++)
        {
            List<string> list = new();
            int nextNr = i;
            for (int j = 1; j <= nrCol; j++)
            {
                list.Add(nextNr.ToString());
                nextNr += nrCol;
            }
        }
        int count = 0;
        foreach (var list in listPossibleInLine)
        {
            foreach (var item in list)
            {
                foreach (var move in moves)
                {
                    if(item == move)
                    {
                        count += 1;
                    }
                }
            }
            if(count == nrCol)
            {
                return true;
            }
        }
        return false;
    }
    internal static bool Horizontal(List<string> moves, int nrCol)
    {
        Dictionary<int, List<int>> listPossibleInLine = new();
        for (int i = 1; i <= nrCol; i++)
        {
            List<int> inLineMoves = new();
            int nextNr = i;
            for (int j = 1; j <= nrCol; j++)
            {
                inLineMoves.Add(nextNr);
                nextNr += 1;
            }
            listPossibleInLine.Add(i, inLineMoves);
        }
        foreach (var move in moves)
        {

        }
        if ((moves.Contains("1") && moves.Contains("2") && moves.Contains("3")) ||
                (moves.Contains("4") && moves.Contains("5") && moves.Contains("6")) ||
                (moves.Contains("7") && moves.Contains("8") && moves.Contains("9")))
        {
            return true;
        }

        return false;
    }
}