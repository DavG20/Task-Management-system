using FluentValidation;

namespace TaskManagement.Application.Features.Tasks.DTOs.Validators
{
    public class ITasksDtoValidator : AbstractValidator<ITasksDto>
    {
        public ITasksDtoValidator()
        {
            RuleFor(p => p.Title)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(50).WithMessage("{PropertyName} must not exceed {ComparisonValue} characters.");

            RuleFor(p => p.Description)
               .NotEmpty().WithMessage("{PropertyName} is required.")
               .NotNull()
               .MaximumLength(200).WithMessage("{PropertyName} must not exceed {ComparisonValue} characters.");

            RuleFor(p => p.StartDate)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .GreaterThanOrEqualTo(DateTime.Now.Date).WithMessage("{PropertyName} must be greater than or equal to the current date.");

            RuleFor(p => p.EndDate)
                .NotEmpty()
                .WithMessage("{PropertyName} is required.")
                .NotNull()
                .GreaterThanOrEqualTo(p => p.StartDate)
                .WithMessage("{PropertyName} must be greater than or equal to the Start Date.");

            RuleFor(p => p.Completed)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull();
        }
    }
}