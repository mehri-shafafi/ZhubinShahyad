using FluentValidation;

namespace News.Application.Articles.Commands.Update
{
    public class UpdateArticleCommandValidator : AbstractValidator<UpdateArticleCommand>
    {
        public UpdateArticleCommandValidator()
        {

        }

    }
}
