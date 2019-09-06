using API.Contracts.Request;
using API.Enums;
using API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.ExtensionsMethods
{
    public static class ExtensionsMethodProduct
    {
        public static Product ConvertContractToProduct( this ProductCreatRequest product)
        {
            var prod = new Product
            {
                RegisterDate = DateTime.Now,
                Description = product.Description,
                Quantity = product.Quantity,
                Price = product.Price
            };

            if (Enum.GetNames(typeof(Category)).Contains(product.Category))
            {
                prod.Category = (Category)Enum.Parse(typeof(Category), product.Category);
            }
            return prod;
        }

        public static Client ConvertContractToClient(this ClientCreateRequest client)
        {
            var cli = new Client
            {
                Name = client.Name,
                Email = client.Email,
                Active = true
            };
            return cli;
        }



    }
}
