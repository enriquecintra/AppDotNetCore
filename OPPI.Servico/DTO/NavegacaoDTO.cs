using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OPPI.Servico.DTO
{
    public class NavegacaoDTO : DTOBase
    {
        public NavegacaoDTO()
        {
            QuantidadeAcesso = 1;
        }
        public int UsuarioId { get; set; }
        public LojaDTO Loja { get; set; }
        public int LojaId { get; set; }
        public int QuantidadeAcesso { get; set; }
    }
}
