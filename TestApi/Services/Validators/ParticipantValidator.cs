using FluentValidation;
using TestApi.Dtos;

namespace TestApi.Services.Validators;

public class ParticipantValidator:AbstractValidator<ParticipantDto>
{
    public ParticipantValidator()
    {
        RuleSet("Strings", () =>
        {
            RuleFor(x => x.Name).Length(0, 255);
            RuleFor(x => x.Surname).Length(0, 255);
        });
        RuleFor(x => x.RegistrationForEventDate).LessThanOrEqualTo(DateOnly.FromDateTime(DateTime.Now));
    }
}