namespace Games.Core.Services;

public class GameFuncs
{
    private readonly WinnerFuncs _winnerFuncs;

    public GameFuncs(WinnerFuncs winnerFuncs)
    {
        _winnerFuncs = winnerFuncs;
    }

    public Dictionary<string, string> SetInitialPossibleMovesTicTacToe()
    {
        Dictionary<string, string> result = new();
        for (int i = 1; i < 10; i++)
        {
            result.Add(i.ToString(), i.ToString());
        }
        return result;
    }

    public async Task<GameResponse?> GetWinnerAsync(GameVsHumanRequest request)
    {
        if(request.GameType.ToLower() == GameType.TicTacToe.ToString().ToLower())
        {
           return await _winnerFuncs.GetWinnerTicTacToe(request);
        }
        return null;
    }
}
