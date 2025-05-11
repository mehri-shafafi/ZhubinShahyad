using FluentValidation;
using Products.Application.Products.Commands.Product.UpdateProduct;

namespace Products.Application.Products.Commands.Categories.Update
{
    public class UpdateCategoryCommandValidator : AbstractValidator<UpdateCategoryCommand>
    {
        public UpdateCategoryCommandValidator()
        {
           
        }

    }
}
