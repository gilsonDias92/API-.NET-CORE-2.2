using API.Contracts.Request;
using API.Enums;
using API.Models;
using API.Validator;
using API.Validator.Rules;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Validator
{
    public class ClientCreateRequestValidator : AbstractValidator<Product>
    {
        public ClientCreateRequestValidator()
        {
            RuleFor(p => p.Description).NotEmpty()
                .WithMessage("Nao pode ser vazio");

            RuleFor(p => p.Category).NotEqual(Category.Undefined)
                .WithMessage("Categoria inválida");

            RuleFor(p => p.Category).IsInEnum()
                .WithMessage("Categoria deve ser válida");

            RuleFor(p => p.Price).GreaterThan(0)
                .WithMessage("Valor tem que ser maior que zero");

            RuleFor(p => p.Quantity).GreaterThan(0)
                .WithMessage("Quantidade tem quer ser maior que zero");


        }






        public bool IsValid(ClientCreateRequest clienteCreateValidator)
        {
            bool response = true;

            if (string.IsNullOrEmpty(clienteCreateValidator.Name))
                response = false;
            if (string.IsNullOrEmpty(clienteCreateValidator.Email))
                response = false;

            return response;
        }
    }
}
