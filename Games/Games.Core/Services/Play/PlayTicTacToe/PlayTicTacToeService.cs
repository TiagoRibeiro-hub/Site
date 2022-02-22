namespace Games.Core.Services;

public class PlayTicTacToeService : IPlayTicTacToeService
{
    public Dictionary<string, string> SetInitialPossibleMovesTicTacToe(int ticTacToeNrCol)
    {
        int max = ticTacToeNrCol * ticTacToeNrCol + 1;
        Dictionary<string, string> result = new();
        for (int i = 1; i < max; i++)
        {
            result.Add(i.ToString(), i.ToString());
        }
        return result;
    }
}
