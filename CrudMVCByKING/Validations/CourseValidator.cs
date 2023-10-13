using CrudMVCByKING.Models.DTOs;
using FluentValidation;

namespace CrudMVCByKING.Validations
{
    public class CourseValidator : AbstractValidator<CoursesDto>
    {
        public CourseValidator()
        {
            RuleFor(course => course.Image).NotEmpty().WithMessage("Image cannot be empty");
            RuleFor(course => course.Title).NotEmpty().WithMessage("Title cannot be empty").NotEqual(" ").WithMessage("Title cannot be just spaces."); 
            RuleFor(course => course.Desc).NotEmpty().WithMessage("Description cannot be empty").NotEqual(" ").WithMessage("Description cannot be just spaces.");
            RuleFor(course => course.Price).NotEmpty().WithMessage("Price cannot be empty").GreaterThanOrEqualTo(5).WithMessage("Price cannot be negative.");
        }
    }
}
