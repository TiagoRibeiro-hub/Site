using ApiShared;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Infrastructure.Validation;

public interface IValidationErrorService
{
    Task<Response<Error>> GetErrors(ValidationResult validationResult);
}
