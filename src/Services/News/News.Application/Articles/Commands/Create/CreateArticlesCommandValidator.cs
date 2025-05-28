using FluentValidation;

namespace News.Application.Articles.Commands.Create;

public class CreateArticlesCommandValidator : AbstractValidator<CreateArticlesCommand>
{
    public CreateArticlesCommandValidator()
    {


    }
}