using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Dto.ProductDto
{
    public class ProductCreateDto
    {
        public string Name { get; set; }
        public double Price { get; set; }
        public bool isDelete { get; set; }


    }
    public class ProductCreateValidator : AbstractValidator<ProductCreateDto>
    {
        public ProductCreateValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .WithMessage("bosh qoyma")
                .MaximumLength(50)
                .WithMessage("50 den yuxari ola bilmez");

            RuleFor(p => p.Price).GreaterThan(30).WithMessage("30 dan asagi qiymet ola bilmez");

        }
    }

}
