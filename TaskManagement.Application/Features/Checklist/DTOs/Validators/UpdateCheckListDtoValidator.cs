using FluentValidation;

namespace TaskManagement.Application.Features.Checklist.DTOs.Validators
{
    public class UpdateCheckListDtoValidator : AbstractValidator<UpdateCheckListDto>
    {
        public UpdateCheckListDtoValidator()
        {
            Include(new ICheckListDtoValidator());
            RuleFor(p => p.Id).NotNull().WithMessage("{PropertyName} must be present");


        }
    }
}