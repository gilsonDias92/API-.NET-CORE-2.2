using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using API.ExtensionsMethods;
using Microsoft.EntityFrameworkCore;
using API.Models;
using API.Contracts.Request;
using API.Validator;
using API.Validator.Rules;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly APIContext _context;

        public ClienteController(APIContext context)
        {
            _context = context;
        }

        // GET: api/Cliente
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Client>>> GetCliente()
        {
            return await _context.Cliente.ToListAsync();
        }

        // GET: api/Cliente/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Client>> GetCliente(int id)
        {
            var cliente = await _context.Cliente.FindAsync(id);

            if (cliente == null)
            {
                return NotFound();
            }

            return cliente;
        }

        // PUT: api/Cliente/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCliente(int id, Client cliente)
        {
            if (id != cliente.Id)
            {
                return BadRequest();
            }

            _context.Entry(cliente).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ClienteExists(id))
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

        // POST: api/Cliente
        [HttpPost]
        public async Task<ActionResult<Client>> PostCliente(ClientCreateRequest cliente)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var validator = new ClientCreateRequestValidator();

            if (!validator.IsValid(cliente))
                return BadRequest(new { error = "Cliente inválido" });

            var cli = cliente.ConvertContractToClient();

            var modelValidator = new ClientCreateValidator(_context, cli);

            var errors = modelValidator.IsValid();

            if (errors.Count() > 0)
                return BadRequest(new { error = errors});

            if (!modelValidator.ExistingProduct())
                return BadRequest(new { error = "Erro! Cliente existente." });

            _context.Cliente.Add(cli);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCliente", new { id = cli.Id }, cli);
        }

        // DELETE: api/Cliente/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Client>> DeleteCliente(int id)
        {
            var cliente = await _context.Cliente.FindAsync(id);
            if (cliente == null)
            {
                return NotFound();
            }

            _context.Cliente.Remove(cliente);
            await _context.SaveChangesAsync();

            return cliente;
        }

        private bool ClienteExists(int id)
        {
            return _context.Cliente.Any(e => e.Id == id);
        }
    }
}
