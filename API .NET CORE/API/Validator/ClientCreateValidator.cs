using API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Validator.Rules
{
    public class ClientCreateValidator
    {
        private APIContext _context;
        private Client _cliente;

        public ClientCreateValidator(APIContext context, Client cliente)
        {
            _context = context;
            _cliente = cliente;
        }

        public bool ExistingProduct()
        {
            var existingClient = _context.Cliente.Where(c => c.Name == _cliente.Name &&
                                        c.Email == _cliente.Email).Count();

            if (existingClient > 0)
            {
                return false;
            }

            return true;
        }

        public List<string> IsValid()
        {
            var errors = new List<string>();

            if (string.IsNullOrEmpty(_cliente.Name))
                errors.Add("Nome não pode ficar em branco.");

            if (string.IsNullOrEmpty(_cliente.Email))
                errors.Add("E-mail não pode ficar em branco.");

            return errors;
        }
    }
}
