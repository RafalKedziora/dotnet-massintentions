using Application.Dto;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Validators
{
    public class UpdateCategoryDtoValidator : AbstractValidator<UpdateCategoryDto>
    {
        public UpdateCategoryDtoValidator(MyIntentionsContext dbContext)
        {
            RuleFor(x => x.Name).NotEmpty();

            RuleFor(x => x.Name)
                .Custom((value, context) =>
                {
                    var categoryInUse = dbContext.Categories.Any(c => c.Name == value);
                    if (categoryInUse)
                    {
                        context.AddFailure("Name", "That Category Name is already taken");
                    }
                });
        }
    }
}
