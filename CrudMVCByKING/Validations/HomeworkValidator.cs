using CrudMVCByKING.Models.DTOs;
using FluentValidation;

namespace CrudMVCByKING.Validations
{
    public class HomeworkValidator: AbstractValidator<HomeworkDto>
    {
        public HomeworkValidator()
        {
            RuleFor(model => model.Title).NotEmpty().WithMessage("Title cannot be empty").NotEqual(" ").WithMessage("Title cannot be just spaces.");
            RuleFor(model => model.Desc).NotEmpty().WithMessage("Description cannot be empty").NotEqual(" ").WithMessage("Description cannot be just spaces.");
        }
    }
}
