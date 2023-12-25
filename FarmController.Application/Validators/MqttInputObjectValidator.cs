using FarmController.Application.InputObjects;
using FluentValidation;

namespace FarmController.Application.Validators
{
    public class MqttInputObjectValidator : AbstractValidator<SetMilkTemperatureInputObject>
    {
        private readonly string WORK_AREA_VALIDATION_MESSAGE = "WorkArea should have respect the regex: /[A-Za-z0-9])+ --> Ex: /teste1/teste2";
        public MqttInputObjectValidator() 
        {
            RuleFor(b => b.WorkArea)
                .Matches("(/[A-Za-z0-9])+")
                .WithMessage(WORK_AREA_VALIDATION_MESSAGE);
        }
    }
}
