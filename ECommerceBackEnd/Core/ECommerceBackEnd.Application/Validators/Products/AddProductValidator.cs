using ECommerceBackEnd.Application.ViewModels.Product;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceBackEnd.Application.Validators.Products
{
    public class AddProductValidator : AbstractValidator<ProductAddViewModel>
    {
        public AddProductValidator()
        {
            RuleFor(p => p.Name)
                .NotEmpty()
                .NotNull()
                .WithMessage("Please Enter The Name")
                .MaximumLength(150)
                .MinimumLength(2).WithMessage("Lenght must be contain 2-150");

            RuleFor(p => p.Stock)
                .NotEmpty()
                .NotNull()
                .WithMessage("Stock can not be null")
                .Must(s=> s >= 0)
                .WithMessage("Stock must be greater than 0");

            RuleFor(p => p.Price)
               .NotEmpty()
               .NotNull()
               .WithMessage("Price can not be null")
               .Must(s => s >= 0)
               .WithMessage("Price must be greater than 0");


        }
    }
}
