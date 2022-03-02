using System.Collections.Generic;

namespace OPPI.Servico.DTO
{
    public class AtendimentoDTO : DTOBase
    {
        public UsuarioDTO Usuario { get; set; }
        public int UsuarioId { get; set; }
        public LojaDTO Loja { get; set; }
        public int LojaId { get; set; }
        public bool Encerrado { get; set; }
        public int Avaliacao { get; set; }
        public IList<MensagemDTO> Mensagens { get; set; }
    }
}