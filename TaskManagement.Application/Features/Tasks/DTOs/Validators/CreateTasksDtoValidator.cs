using FluentValidation;

namespace TaskManagement.Application.Features.Tasks.DTOs.Validators
{
    public class CreateTasksDtoValidator : AbstractValidator<CreateTasksDto>
    {
        public CreateTasksDtoValidator()
        {
            Include(new ITasksDtoValidator());

            RuleFor(p => p.UserId)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .GreaterThan(0).WithMessage("{PropertyName} must be greater than or equal to {ComparisonValue}.");
        }

    }
}