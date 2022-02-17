namespace Games.Core.Funcs;

public class WinnerFuncs
{
    private readonly IReadRepository _readRepository;

    public WinnerFuncs(IReadRepository readRepository)
    {
        _readRepository = readRepository;
    }

    private Expression<Func<MovesEntity, bool>>? _expressionBool;
    private Expression<Func<MovesEntity, string>>? _expressionInt;
    
    public async Task<GameResponse> GetWinnerTicTacToe(GameVsHumanRequest request)
    {
        _expressionBool = x => x.GameId == request.IdGame && x.PlayerName == request.Player.Name;
        _expressionInt = x => x.MoveTo;
        var playerMoves = await _readRepository.GetSelectedTableToListAsync(_expressionBool, _expressionInt);
        bool haveWinner = WinnerCheckTictacToe.HaveWinnerMethod(playerMoves);
        throw new NotImplementedException();
    }


}
