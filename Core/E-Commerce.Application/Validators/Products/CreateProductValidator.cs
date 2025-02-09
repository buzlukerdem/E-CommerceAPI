using E_Commerce.Application.ViewModels.Products;
using FluentValidation;
using Microsoft.AspNetCore.Rewrite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Application.Validators.Products
{
    public class CreateProductValidator : AbstractValidator<VM_Create_Product>
    {
        public CreateProductValidator()
        {
            RuleFor(p => p.Name)
                .NotEmpty()
                .NotNull()
                    .WithMessage("Ürün adı boş bırakılamaz.")
                .Length(3, 50)
                    .WithMessage("3-50 karakter arasında ürün adını giriniz.");

            RuleFor(p => p.Stock)
                .NotEmpty()
                .NotNull()
                    .WithMessage("Ürün stock değeri boş bırakılamaz.")
                .Must(s => s >= 0)
                    .WithMessage("Stock sayısı 0 veya daha fazla olmalıdır.");

            RuleFor(p => p.Price)
                .NotEmpty()
                .NotNull()
                     .WithMessage("Ürün fiyat değeri boş bırakılamaz.")
                 .Must(s => s >= 0)
                      .WithMessage("Ürün fiyat değeri 0 veya daha fazla olmalıdır.");
        }
    }
}
