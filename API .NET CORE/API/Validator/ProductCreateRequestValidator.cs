using API.Contracts.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Validator
{
    public class ProductCreateRequestValidator
    {
        public bool IsValid(ProductCreatRequest prod)
        {
            bool resposta = true;

            if (string.IsNullOrEmpty(prod.Description))
                resposta = false;

            if (string.IsNullOrEmpty(prod.Category))
                resposta = false;

            if (double.IsNaN(prod.Price))
                resposta = false;

            return resposta;
        }
    }
}
