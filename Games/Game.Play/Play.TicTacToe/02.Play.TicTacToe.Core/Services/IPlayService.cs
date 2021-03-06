using _01.Play.TicTacToe.Infrastructure;
using ApiShared;
using Data.Infrastructure.Infrastructure.Api.PlayGame;
using Data.Infrastructure.Validation;

namespace _02.Play.TicTacToe.Core.Services;
public interface IPlayService
{
    Task<Response> SetPlayResponse(PlayTicTacToeRecord playTicTacToe);
}
public class PlayImplementation : IPlayService
{
    private readonly IValidationErrorService _validationErrorService;
    private readonly IPlayValidationService _playValidationService;
    private readonly ITicTacToeService _ticTacToeService;
    public PlayImplementation(
        IValidationErrorService validationErrorService,
        IPlayValidationService playValidationService, 
        ITicTacToeService ticTacToeService)
    {
        _validationErrorService = validationErrorService;
        _playValidationService = playValidationService;
        _ticTacToeService = ticTacToeService;
    }

    public async Task<Response> SetPlayResponse(PlayTicTacToeRecord playTicTacToe)
    {
        var validation = await _playValidationService.ValidatePlayTicTacToeRequest(playTicTacToe);
        if (!validation.IsValid)
        {
            return await _validationErrorService.GetErrors(validation);
        }
        PlayTicTacToeResponse playResponse = await GetPlayResponse(playTicTacToe);
        Response<PlayTicTacToeResponse> response = new();
        if (playResponse is null)
        {
            return response.Fail(message: ApiSharedConst.SomethingWentWrong);
        }
        return response.Success
            (
                content: playResponse,
                message: ApiSharedConst.EverthingOk
            );
    }

    private async Task<PlayTicTacToeResponse> GetPlayResponse(PlayTicTacToeRecord playTicTacToe)
    {
        List<string> playerMoves;
        if (playTicTacToe.VsComputer.IsComputer)
        {
            playerMoves = await _ticTacToeService.PlayMoveComputer(playTicTacToe);
        }
        else
        {
            playerMoves = await _ticTacToeService.PlayMoveHuman(playTicTacToe);
        }
        return await _ticTacToeService.GetWinner(playTicTacToe, playerMoves);
    }
}
