using FluentValidation;
using News.Application.News.Commands.News.Update;

namespace News.Application.Articles.Commands.Update
{
    public class UpdateArticleCommandValidator : AbstractValidator<UpdateArticleCommand>
    {
        public UpdateArticleCommandValidator()
        {
        
        }

    }
}
