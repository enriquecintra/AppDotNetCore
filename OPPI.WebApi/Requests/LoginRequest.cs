using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OPPI.WebApi.Requests
{
    public class LoginRequest
    {
        public string Login { get; set; }
        public string Senha { get; set; }
    }
}
