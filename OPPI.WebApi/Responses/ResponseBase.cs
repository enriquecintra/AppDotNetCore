using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OPPI.WebApi.Responses
{
    public class ResponseBase
    {
        public ResponseBase()
        {
            Ok = true;
        }
        public string Mensagem { get; set; }
        public bool Ok { get; set; }
    }
}
