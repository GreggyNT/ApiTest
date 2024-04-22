using FluentValidation;
using FluentValidation.Results;
using TestApi.Dtos;

namespace TestApi.Services.Validators;

public class EventValidator:AbstractValidator<EventDto>
{
  public EventValidator()
  {
    RuleFor(x => x.Description).Length(0, 255);
    Rule
  }
}