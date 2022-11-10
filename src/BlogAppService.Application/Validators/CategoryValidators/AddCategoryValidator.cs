using BlogAppService.Application.Dtos.Category;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogAppService.Application.Validators.CategoryValidators
{
    public class AddCategoryValidator:AbstractValidator<AddCategoryDto>
    {
        public AddCategoryValidator()
        {
            RuleFor(x => x.Name).NotEmpty().NotNull().WithMessage("Category name can not be empty")
                .MinimumLength(5).WithMessage("Category name must greater than 5 characters");
        }
    }
}
