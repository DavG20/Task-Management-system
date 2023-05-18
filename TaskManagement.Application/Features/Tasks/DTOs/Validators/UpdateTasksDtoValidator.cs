using FluentValidation;

namespace TaskManagement.Application.Features.Tasks.DTOs.Validators
{
    public class UpdateTasksDtoValidator : AbstractValidator<UpdateTasksDto>
    {

        public UpdateTasksDtoValidator()
        {

            Include(new ITasksDtoValidator());
            RuleFor(p => p.Id).NotNull().WithMessage("{PropertyName} must be present");
        }
        
    }
}