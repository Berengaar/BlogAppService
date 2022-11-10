using BlogAppService.Application.Dtos.Category;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogAppService.Application.Validators.CategoryValidators
{
    public class UpdateCategoryValidator:AbstractValidator<UpdateCategoryDto>
    {
        public UpdateCategoryValidator()
        {
            RuleFor(x => x.Id).NotNull().NotEmpty().WithMessage("Id cannot be null");
            RuleFor(x => x.Name).NotNull().NotEmpty().WithMessage("Category name can not be empty")
                .MinimumLength(5).WithMessage("Category name must be greater than 5 characters");
        }
    }
}
