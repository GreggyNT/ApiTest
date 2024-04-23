using FluentValidation;
using FluentValidation.Results;
using TestApi.Dtos;

namespace TestApi.Services.Validators;

public class EventValidator:AbstractValidator<EventDto>
{
  public EventValidator()
  {
    RuleFor(x => x.DateTime).GreaterThan(DateTime.Now);
    RuleSet("Strings", () =>
    {
      RuleFor(x => x.Description).Length(0, 255);
      RuleFor(x => x.Location).Length(0, 255);
      RuleFor(x=>x.Category).Length(0, 255);
      RuleFor(x=>x.Name).Length(0, 255);
    });
    RuleFor(x => x.MaximumParticipants).ExclusiveBetween(1, 100);
  }
}