using FluentValidation;
using News.Application.News.Commands.News.Update;

namespace News.Application.Category.Commands.Update
{
    public class UpdateCategoryCommandValidator : AbstractValidator<UpdateCategoryCommand>
    {
        public UpdateCategoryCommandValidator()
        {
        
        }

    }
}
