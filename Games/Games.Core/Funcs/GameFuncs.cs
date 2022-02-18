namespace Games.Core.Funcs;

public class GameFuncs
{
    private readonly WinnerFuncs _winnerFuncs;

    public GameFuncs(WinnerFuncs winnerFuncs)
    {
        _winnerFuncs = winnerFuncs;
    }

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

    public async Task<GameResponse?> GetWinnerAsync(GameVsHumanRequest request)
    {
        if (GameType.TicTacToe.GetGameType(request.GameType))
        {
            return await _winnerFuncs.GetWinnerTicTacToe(request);
        }
        return null;
    }
}
