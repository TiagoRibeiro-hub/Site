using ApiShared;
using FluentValidation.Results;


namespace Data.Infrastructure.Validation;

public class ValidationError : IValidationErrorService
{
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
}
