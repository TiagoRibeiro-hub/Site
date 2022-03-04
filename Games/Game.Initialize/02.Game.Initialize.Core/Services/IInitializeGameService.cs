using _01.Game.Initialize.Infrastructure;
using _02.Game.Initialize.Core.GameOptions;
using ApiShared;
using Data.Infrastructure.Data.Enums;
using Data.Infrastructure.Data.Extensions;
using Data.Infrastructure.Infrastructure.Api.InitializeGame;
using Data.Infrastructure.Validation;

namespace _02.Game.Initialize.Core.Services;
public interface IInitializeGameService
{
    Task<Response> SetSetInitializeGameResponse(InitializeGameRecord game);
}

public class InitializeGameImplementation : IInitializeGameService
{
    private readonly IInitializeGameValidationService _initializeGameValidationService;
    private readonly IValidationErrorService _validationErrorService;
    public readonly IInitializeGameOptionsService _initializeGameOptions;
    
    public InitializeGameImplementation(
        IInitializeGameValidationService initializeGameValidationService, 
        IValidationErrorService validationErrorService, 
        IInitializeGameOptionsService initializeGameOptions)
    {
        _initializeGameValidationService = initializeGameValidationService;
        _validationErrorService = validationErrorService;
        _initializeGameOptions = initializeGameOptions;
    }

    public async Task<Response> SetSetInitializeGameResponse(InitializeGameRecord game)
    {
        var validation = await _initializeGameValidationService.ValidateInitializeGameRequest(game);
        if (!validation.IsValid)
        {
            return await _validationErrorService.GetErrors(validation);
        }
        InitializeGameResponse initializeGameResponse = await GetInitializeGameResponse(game);
        Response<InitializeGameResponse> response = new();
        return response.Success
            (
                content: initializeGameResponse,
                message: "Successful registration"
            );
    }

    private async Task<InitializeGameResponse> GetInitializeGameResponse(InitializeGameRecord game)
    {
        InitializeGameResponse initializeGameResponse = new();
        if (GameType.TicTacToe.GetGameType(game.GameOptions.GameTypeName))
        {
            initializeGameResponse = await _initializeGameOptions.SetTicTacToeGame(game);
            // messagebroker
        }
        return initializeGameResponse;
    }
}