using _01.Play.TicTacToe.Infrastructure;
using Data.Infrastructure.Validation.Validators;
using FluentValidation.Results;

namespace _02.Play.TicTacToe.Core.Services;
public interface IPlayValidationService
{
    Task<ValidationResult> ValidatePlayTicTacToeRequest(PlayTicTacToeRecord registerPlayer);
}

public class PlayValidation : IPlayValidationService
{
    public async Task<ValidationResult> ValidatePlayTicTacToeRequest(PlayTicTacToeRecord playTicTacToe)
    {
        try
        {
            bool isExist = true;// first confirm gameId
            ValidationResult validation = new();
            if (isExist)
            {
                PlayTicTacToeValidator validationRules = new();
                validation = await validationRules.ValidateAsync(playTicTacToe.SetPlayTicTacToeRequest());
                if (validation is null)
                {
                    throw new Exception("Validation is null");
                }
            }
            return validation;
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message.ToString());
        }
    }
}

