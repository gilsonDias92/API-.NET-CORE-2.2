using API.Contracts.Request;
using API.Validator;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace XUnitTestProject.ContractTest
{
    public class ProductCreateRequestTest
    {
        private ProductCreateRequestValidator _validator;
        public ProductCreateRequestTest()
        {
            _validator = new ProductCreateRequestValidator();
        }

        [Fact(DisplayName = "Produto válido para ser incluído.")]

        //acontecem sem prender o software
        public async Task ProdutoValidoParaInclusao() //transforma em tarefa, independente de sincronismo
        {
            var produto = new ProductCreatRequest
            {
                Description = "PRODUTO TESTE",
                Price = 30,
                Quantity = 10,
                Category = "Eletronics"
            };

            Assert.True(_validator.IsValid(produto));
        }

        [Fact(DisplayName = "Produto Inválido para inclusão")]
        public async Task ProdutoInvalidoParaInclusao() //transforma em tarefa, independente de sincronismo
        {
            var produto = new ProductCreatRequest
            {
                Description = "PRODUTO TESTE",
                Price = 30,
                Quantity = 1,
                Category = ""
            };

            Assert.False(_validator.IsValid(produto));
        }
    }
}
