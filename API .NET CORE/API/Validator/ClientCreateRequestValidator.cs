using API.Contracts.Request;
using API.Validator;
using API.Validator.Rules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Validator
{
    public class ClientCreateRequestValidator
    {
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
