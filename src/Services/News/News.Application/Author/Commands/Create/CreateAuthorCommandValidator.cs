using FluentValidation;
using News.Application.Articles.Commands.Create;

namespace News.Application.Author.Commands.Create;

public class CreateAuthorCommandValidator : AbstractValidator<CreateAuthorCommand>
{
    public CreateAuthorCommandValidator()
    {


    }
}