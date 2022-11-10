using BlogAppService.Application.Dtos.Category;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogAppService.Application.Validators.CategoryValidators
{
    public class DeleteCategoryValidator:AbstractValidator<DeleteCategoryDto>
    {
        public DeleteCategoryValidator()
        {
            RuleFor(x => x.Id).NotNull().NotEmpty().WithMessage("Id can not be empty");
        }
    }
}
