using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using SharpGrip.FluentValidation.AutoValidation.Mvc.Configuration;
using SharpGrip.FluentValidation.AutoValidation.Mvc.Results;
using FarmController.Application.ViewObjects;

namespace FarmController.Api.Configurations
{
    public static class AutomaticValidationConfigurations
    {
        public static void LoadConfigurations(AutoValidationMvcConfiguration configuration)
        {
            configuration.OverrideDefaultResultFactoryWith<CustomResultFactory>();
        }
    }

    public class CustomResultFactory : IFluentValidationAutoValidationResultFactory
    {
        public IActionResult CreateActionResult(ActionExecutingContext context, ValidationProblemDetails? validationProblemDetails)
        {
            var errorsList = validationProblemDetails?.Errors
                .Values
                .SelectMany(errorItems => errorItems)
                .ToList();
            return new BadRequestObjectResult(new BaseResponseViewObject(errorsList!));
        }
    }
}
