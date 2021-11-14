using FluentValidation;

namespace UniversityApp.BLL.ViewModel
{
    public class CourseInsertRequestViewModel
    {
        public string Name { get; set; }
        public string Code { get; set; }
        public double Credit { get; set; }
    }
    
    public class CourseInsertRequestViewModelValidator : AbstractValidator<CourseInsertRequestViewModel> 
    {
        public CourseInsertRequestViewModelValidator()
        {
            RuleFor(x => x.Name)
                .NotNull().WithMessage("name must not empty")
                .MinimumLength(3).WithMessage("name must be at least 3 character")
                .MaximumLength(50).WithMessage("name not greater than 50 character");
            
            RuleFor(x => x.Code)
                .NotNull().WithMessage("code must not empty")
                .MinimumLength(3).WithMessage("code must be at least 3 character")
                .MaximumLength(20).WithMessage("code not greater than 20 character");

            RuleFor(x => x.Credit)
                .GreaterThanOrEqualTo(1).WithMessage("credit must be grater than or equal 1")
                .LessThanOrEqualTo(5).WithMessage("credit must be less than or equal 5");
        }
    }
    
}