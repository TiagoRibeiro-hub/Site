using FluentValidation.Results;
using Games.Core.Validators;
using Games.Data.Game;
using Games.Infrastructure;

namespace Games.Core.Validatons;

public class ValidationService : IValidationService
{
    private readonly IRegisteredPlayersRepository _registeredPlayersRepository;
    private readonly ITicTacToeReadRepository _ticTacToeReadRepository;
    public ValidationService(IRegisteredPlayersRepository registeredPlayersRepository, ITicTacToeReadRepository ticTacToeReadRepository)
    {
        _registeredPlayersRepository = registeredPlayersRepository;
        _ticTacToeReadRepository = ticTacToeReadRepository;
    }

    public Task<Response<Error>> GetErrors(ValidationResult validationResult)
    {
        var errors = validationResult.Errors.ToDictionary(x => x.PropertyName, x => x.ErrorMessage).ToArray();
        Error errorResponse = new();
        foreach (var item in errors)
        {
            ErrorModel errorModel = new()
            {
                FieldName = item.Key.ToString(),
                Message = item.Value.ToString(),
            };
            errorResponse.Errors.Add(errorModel);
        }
        Response response = new();
        return Task.FromResult(response.Fail(content: errorResponse));
    }

    public async Task<ValidationResult> ValidateRegisterPlayerRequest(RegisterPlayerRequest registerPlayer)
    {
        RegisterPlayerRequestValidator validationRules = new(_registeredPlayersRepository);
        var validation = await validationRules.ValidateAsync(registerPlayer);
        return validation;
    }

    public async Task<ValidationResult> InitializeGameRequestValidator(InitializeGameRequest initializeGame)
    {
        InitializeGameRequestValidator validationRules = new(_ticTacToeReadRepository);
        var validation = await validationRules.ValidateAsync(initializeGame);
        return validation;
    }

    public async Task<ValidationResult> PlayRequestValidator(PlayRequest playRequest)
    {
        MovementValidation movementValidation = new(playRequest);
        PlayRequestValidator validationRules = new(movementValidation);
        var validation = await validationRules.ValidateAsync(playRequest);

        if (playRequest.VsComputer.IsComputer == false && validation.IsValid)
        {
            bool isExist = false;
            Expression<Func<GameEntity, bool>> predicate = x => x.Id == playRequest.IdGame && (x.Player1_Name == playRequest.PlayerName || x.Player2_Name == playRequest.PlayerName);
            if (GameType.TicTacToe.GetGameType(playRequest.GetGameType.GameTypeName))
            {
                isExist = await _ticTacToeReadRepository.IsAnyGameAsync(predicate);
            }
            if (GameType.Chess.GetGameType(playRequest.GetGameType.GameTypeName))
            {
                //isExist = 
            }
            if (isExist == false)
            {
                validation.Errors.Add(new ValidationFailure("PlayerName", $"{playRequest.PlayerName} does not belong to this Game Id: {playRequest.IdGame}."));
            }
        }
        return validation;
    }
}
