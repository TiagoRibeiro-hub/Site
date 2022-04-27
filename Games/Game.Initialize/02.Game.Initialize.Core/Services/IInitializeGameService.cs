using _01.Game.Initialize.Infrastructure;
using ApiShared;
using Data.Infrastructure.Data.Enums;
using Data.Infrastructure.Data.Extensions;
using Data.Infrastructure.Events;
using Data.Infrastructure.Infrastructure.Api.InitializeGame;
using Data.Infrastructure.Validation;
using MassTransit;

namespace _02.Game.Initialize.Core.Services;
public interface IInitializeGameService
{
    Task<ApiShared.Response> SetSetInitializeGameResponse(InitializeGameRecord game);
}

public class InitializeGameImplementation : IInitializeGameService
{
    private readonly IInitializeGameValidationService _initializeGameValidationService;
    private readonly IValidationErrorService _validationErrorService;
    private readonly IInitializeGameOptionsService _initializeGameOptions;
    private readonly IPublishEndpoint _publishEndpoint;

    public InitializeGameImplementation(
        IInitializeGameValidationService initializeGameValidationService, 
        IValidationErrorService validationErrorService, 
        IInitializeGameOptionsService initializeGameOptions,
        IPublishEndpoint publishEndpoint)
    {
        _initializeGameValidationService = initializeGameValidationService;
        _validationErrorService = validationErrorService;
        _initializeGameOptions = initializeGameOptions;
        _publishEndpoint = publishEndpoint;
    }

    public async Task<ApiShared.Response> SetSetInitializeGameResponse(InitializeGameRecord game)
    {
        var validation = await _initializeGameValidationService.ValidateInitializeGameRequest(game);
        if (!validation.IsValid)
        {
            return await _validationErrorService.GetErrors(validation);
        }
        InitializeGameResponse initializeGameResponse = await GetInitializeGameResponse(game);
        ApiShared.Response<InitializeGameResponse> response = new();
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
            await _publishEndpoint.Publish<IInitializeGameEvent>(new
            {
                IdGame = initializeGameResponse.IdGame,
                PossibleMoves = initializeGameResponse.PossibleMoves
            });
        }
        return initializeGameResponse;
    }
}