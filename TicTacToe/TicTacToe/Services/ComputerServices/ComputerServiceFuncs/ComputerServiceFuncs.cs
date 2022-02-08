namespace TicTacToe.Services;
public static class ComputerServiceFuncs
{
    public static int GetMove(HashSet<int> possibleMoves, HashSet<int> opponentMoves)
    {
        int move = 0;
        move = HorizontalRtoL(possibleMoves, opponentMoves);
        if (move == 0)
        {
            move = HorizontalLtoR(possibleMoves, opponentMoves);
            if (move == 0)
            {
                move = VerticalUtoD(possibleMoves, opponentMoves);
                if (move == 0)
                {
                    move = VerticalDtoU(possibleMoves, opponentMoves);
                    if (move == 0)
                    {
                        move = Diagonal(possibleMoves, opponentMoves);
                    }
                }
            }
        }

        return move;
    }
    public static int GetRandomMove(List<int> possibleMoves)
    {
        var random = new Random();
        int index = random.Next(possibleMoves.Count);
        return possibleMoves[index];
    }
    private static int HorizontalRtoL(HashSet<int> possibleMoves, HashSet<int> opponentMoves)
    {
        if (opponentMoves.Contains(1) && opponentMoves.Contains(2))
        {
            if (possibleMoves.Contains(3))
            {
                return 3;
            }
        }
        if (opponentMoves.Contains(4) && opponentMoves.Contains(5))
        {
            if (possibleMoves.Contains(6))
            {
                return 6;
            }
        }
        if (opponentMoves.Contains(7) && opponentMoves.Contains(8))
        {
            if (possibleMoves.Contains(9))
            {
                return 9;
            }
        }
        return 0;
    }
    private static int HorizontalLtoR(HashSet<int> possibleMoves, HashSet<int> opponentMoves)
    {
        if (opponentMoves.Contains(2) && opponentMoves.Contains(3))
        {
            if (possibleMoves.Contains(1))
            {
                return 1;
            }
        }
        if (opponentMoves.Contains(5) && opponentMoves.Contains(6))
        {
            if (possibleMoves.Contains(4))
            {
                return 4;
            }
        }
        if (opponentMoves.Contains(8) && opponentMoves.Contains(9))
        {
            if (possibleMoves.Contains(7))
            {
                return 7;
            }
        }
        return 0;
    }
    private static int VerticalUtoD(HashSet<int> possibleMoves, HashSet<int> opponentMoves)
    {
        if (opponentMoves.Contains(1) && opponentMoves.Contains(4))
        {
            if (possibleMoves.Contains(7))
            {
                return 7;
            }
        }
        if (opponentMoves.Contains(2) && opponentMoves.Contains(5))
        {
            if (possibleMoves.Contains(8))
            {
                return 8;
            }
        }
        if (opponentMoves.Contains(3) && opponentMoves.Contains(6))
        {
            if (possibleMoves.Contains(9))
            {
                return 9;
            }
        }
        return 0;
    }
    private static int VerticalDtoU(HashSet<int> possibleMoves, HashSet<int> opponentMoves)
    {
        if (opponentMoves.Contains(7) && opponentMoves.Contains(4))
        {
            if (possibleMoves.Contains(1))
            {
                return 1;
            }
        }
        if (opponentMoves.Contains(8) && opponentMoves.Contains(5))
        {
            if (possibleMoves.Contains(2))
            {
                return 2;
            }
        }
        if (opponentMoves.Contains(9) && opponentMoves.Contains(6))
        {
            if (possibleMoves.Contains(3))
            {
                return 3;
            }
        }
        return 0;
    }
    private static int Diagonal(HashSet<int> possibleMoves, HashSet<int> opponentMoves)
    {
        if (opponentMoves.Contains(1) && opponentMoves.Contains(5))
        {
            if (possibleMoves.Contains(9))
            {
                return 9;
            }
        }
        if (opponentMoves.Contains(3) && opponentMoves.Contains(5))
        {
            if (possibleMoves.Contains(7))
            {
                return 7;
            }
        }
        if (opponentMoves.Contains(7) && opponentMoves.Contains(5))
        {
            if (possibleMoves.Contains(3))
            {
                return 3;
            }
        }
        if (opponentMoves.Contains(9) && opponentMoves.Contains(5))
        {
            if (possibleMoves.Contains(1))
            {
                return 1;
            }
        }
        return 0;
    }
}

