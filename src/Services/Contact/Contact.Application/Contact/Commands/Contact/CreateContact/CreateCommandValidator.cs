using Contact.Application.Contact.Commands.Base.CreateContact;
using FluentValidation;

namespace Gallery.Application.Gallery.Commands.Base.CreateGallery;

public class CreateGalleryCommandValidator : AbstractValidator<CreateCommand>
{
    public CreateGalleryCommandValidator()
    {
        RuleFor(x => x.Name)
    .NotEmpty().WithMessage("نام الزامی است.");
        RuleFor(x => x.Email)
     .NotEmpty().WithMessage("ایمیل الزامی است.")
     .EmailAddress().WithMessage("فرمت ایمیل معتبر نیست."); // ✅ بررسی صحت ایمیل

        RuleFor(x => x.Message)
            .NotEmpty().WithMessage("پیام الزامی است.");


    }
}