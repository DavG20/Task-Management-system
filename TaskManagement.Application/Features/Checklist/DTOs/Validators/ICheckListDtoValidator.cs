
using FluentValidation;

namespace TaskManagement.Application.Features.Checklist.DTOs.Validators
{
    public class ICheckListDtoValidator : AbstractValidator<ICheckListDto>
    {
        
        public ICheckListDtoValidator()
        {
            RuleFor(p => p.Title)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(50).WithMessage("{PropertyName} must not exceed {ComparisonValue} characters.");

            RuleFor(p => p.Description)
               .NotEmpty().WithMessage("{PropertyName} is required.")
               .NotNull()
               .MaximumLength(200).WithMessage("{PropertyName} must not exceed {ComparisonValue} characters.");
            
        }
    }
}