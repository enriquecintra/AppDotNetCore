using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OPPI.WebApi.Responses
{
    public class TokenResponse : ResponseBase
    {
        public string Token { get; set; }
    }
}
