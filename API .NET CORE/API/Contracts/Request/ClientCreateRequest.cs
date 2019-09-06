using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Contracts.Request
{
    public class ClientCreateRequest
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public bool Active { get; set; }
    }
}
