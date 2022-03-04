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

    public PlayImplementation(
        IValidationErrorService validationErrorService, 
        IPlayValidationService playValidationService)
    {
        _validationErrorService = validationErrorService;
        _playValidationService = playValidationService;
    }

    public async Task<Response> SetPlayResponse(PlayTicTacToeRecord playTicTacToe)
    {
        var validation = await _playValidationService.ValidatePlayTicTacToeRequest(playTicTacToe);
        if (!validation.IsValid)
        {
            return await _validationErrorService.GetErrors(validation);
        }
        throw new NotImplementedException();
    }
}
