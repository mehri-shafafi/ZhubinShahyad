using FluentValidation;
using News.Application.News.Commands.News.Update;

namespace News.Application.NewsComments.Commands.Update
{
    public class UpdateNewsCommandValidator : AbstractValidator<UpdateNewsCommand>
    {
        public UpdateNewsCommandValidator()
        {
        
        }

    }
}
