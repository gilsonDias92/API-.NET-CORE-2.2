using API.Models;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Validator.Rules
{
    public class ProductPriceValidationRules : AbstractValidator<Product>
    {
        public ProductPriceValidationRules()
        {
            RuleFor(p => p.Price)
                .GreaterThan(0)
                .WithMessage("Price must be greater than {1}");
        }
    }
}
