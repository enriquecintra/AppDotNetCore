using OPPI.Dominio.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OPPI.Servico.DTO
{
    public class DocumentoDTO : DTOBase
    {
        public TipoDocumentoEnum TipoDocumento { get; set; }
        public string Numero { get; set; }
    }
}
