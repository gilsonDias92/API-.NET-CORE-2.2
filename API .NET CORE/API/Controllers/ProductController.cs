using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using API.Models;
using API.Contracts.Request;
using API.Enums;
using API.ExtensionsMethods;
using API.Validator;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly APIContext _context;

        public ProductController(APIContext context)
        {
            _context = context;
        }

        // GET: api/Product
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> GetProduct()
        {
            return await _context.Product.ToListAsync();
        }

        // GET: api/Product/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProduct(int id)
        {
            var product = await _context.Product.FindAsync(id);

            if (product == null)
            {
                return NotFound();
            }

            return product;
        }

        // PUT: api/Product/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProduct(int id, Product product)
        {
            if (id != product.Id)
            {
                return BadRequest();
            }

            _context.Entry(product).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Product
        [HttpPost]

        public async Task<ActionResult<Product>> PostProduct([FromBody] ProductCreatRequest product)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var validator = new ProductCreateRequestValidator();

            if (!validator.IsValid(product))
            {
                return BadRequest(new { error = "Produto inválido!"});
            }

            var prod = product.ConvertContractToProduct();
            var modelValidator = new ProductCreateValidator(_context, prod);
            //atribui a variavel erros a lista de erros encontrados
            var errors = modelValidator.IsValid();
            // verificando se existe algum erro na lista errors
            if (errors.Count() > 0)
            {
                return BadRequest(new { error = errors });
            }

            if (!modelValidator.ExistingProduct())
            {
                return BadRequest(new { error = "ERRO! Produto existente."});
            }

            _context.Product.Add(prod);
            await _context.SaveChangesAsync();
            return CreatedAtAction("GetProduct", new { id = prod.Id }, prod);
        }

        // DELETE: api/Product/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Product>> DeleteProduct(int id)
        {
            var product = await _context.Product.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }

            _context.Product.Remove(product);
            await _context.SaveChangesAsync();

            return product;
        }

        private bool ProductExists(int id)
        {
            return _context.Product.Any(e => e.Id == id);
        }
    }
}
