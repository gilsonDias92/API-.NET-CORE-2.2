using API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Validator
{
    public class ProductCreateValidator
    {
        private APIContext _context;
        private Product _product;

        public ProductCreateValidator(APIContext context, Product prod)
        {
            _context = context;
            _product = prod;

        }

        public List<string> IsValid()
        {
            List<string> errors = new List<string>();
            bool response;

            if (string.IsNullOrEmpty(_product.Description))
            {
                errors.Add("Descrição não pode ser vazia!");
            }

            if (_product.Category == 0)
            {
                errors.Add("Unidade de medida invalida!");
            }

            if (_product.Price <= 0)
            {
                errors.Add("Valor não pode ser menor ou igual a zero!");
            }

            return errors;
        }

        public bool ExistingProduct()
        {
            //Validando se o produto já existe no banco de dados
            var exist = _context.Product.Where(p => p.Description == _product.Description &&
                                                    p.Category == _product.Category).Count();

            if (exist > 0)
            {
                return false;
            }
            return true;
        }
    }
}
