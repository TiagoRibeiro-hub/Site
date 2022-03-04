using _01.Game.Initialize.Infrastructure;
using _02.Game.Initialize.Core.Repository;
using Data.Infrastructure.Validation.Validators;
using FluentValidation.Results;

namespace _02.Game.Initialize.Core.Services;

public interface IInitializeGameValidationService
{
    Task<ValidationResult> ValidateInitializeGameRequest(InitializeGameRecord registerPlayer);
}

public class InitializeGameValidation : IInitializeGameValidationService
{
    public readonly IInitializeGameRepository _initializeGameRepository;

    public InitializeGameValidation(IInitializeGameRepository initializeGameRepository)
    {
        _initializeGameRepository = initializeGameRepository;
    }
    public async Task<ValidationResult> ValidateInitializeGameRequest(InitializeGameRecord game)
    {
        try
        {
            InitializeGameValidator validationRules = new();
            var validation = await validationRules.ValidateAsync(game.SetInitializeGameRequest());
            if (validation is null)
            {
                throw new Exception("Validation is null");
            }
            return validation;
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message.ToString());
        }
    }
}