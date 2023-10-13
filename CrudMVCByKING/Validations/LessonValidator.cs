using CrudMVCByKING.Models.DTOs;
using FluentValidation;

namespace CrudMVCByKING.Validations
{
    public class LessonValidator : AbstractValidator<LessonsDto>
    {
        public LessonValidator()
        {
            RuleFor(lesson => lesson.Video).NotEmpty().WithMessage("Video cannot be empty");
            RuleFor(lesson => lesson.Title).NotEmpty().WithMessage("Title cannot be empty").NotEqual(" ").WithMessage("Title cannot be just spaces.");
            RuleFor(lesson => lesson.Desc).NotEmpty().WithMessage("Description cannot be empty").NotEqual(" ").WithMessage("Description cannot be just spaces.");
        }
    }
}
