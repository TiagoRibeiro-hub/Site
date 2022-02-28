namespace Games.Core.Services;

public class PlayPhaseService : IPlayPhaseService
{
    private readonly ITicTacToeService _ticTacToeService;

    public PlayPhaseService(ITicTacToeService ticTacToeService)
    {
        _ticTacToeService = ticTacToeService;
    }

    public async Task<PlayResponse> Play(PlayRequest request)
    {
        PlayResponse playResponse = new();
        if (request.VsComputer.IsComputer)
        {
            //
        }
        else
        {
            if (GameType.TicTacToe.GetGameType(request.GetGameType.GameTypeName))
            {
                List<string> playerMoves = await _ticTacToeService.PlayMove(request);
                playResponse = await _ticTacToeService.GetWinner(request, playerMoves);
            }
        }
        return playResponse;
    }
} 
