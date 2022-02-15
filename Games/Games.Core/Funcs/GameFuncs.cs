namespace Games.Core.Services;

public class GameFuncs
{
    public Dictionary<string, string> SetInitialPossibleMovesTicTacToe()
    {
        Dictionary<string, string> result = new();
        for (int i = 1; i < 10; i++)
        {
            result.Add(i.ToString(), i.ToString());
        }
        return result;
    }

    public Task<GameResponse> GetWinnerAsync(GameVsHumanRequest request)
    {

        return null;
    }
}
