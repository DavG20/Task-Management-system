using FluentValidation;

namespace TaskManagement.Application.Features.Checklist.DTOs.Validators
{
    public class CreateCheckListDtoValidator : AbstractValidator<CreateCheckListDto>
    {
        public CreateCheckListDtoValidator()
        {
            Include(new ICheckListDtoValidator());
            RuleFor(p => p.TasksId)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .GreaterThan(0).WithMessage("{PropertyName} must be greater than or equal to {ComparisonValue}.");

        }

    }
}