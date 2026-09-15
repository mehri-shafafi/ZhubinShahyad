using FluentValidation;

namespace News.Application.Articles.Commands.Update
{
    public class UpdateArticleCommandValidator : AbstractValidator<UpdateNewsCommand>
    {
        public UpdateArticleCommandValidator()
        {

        }

    }
}
