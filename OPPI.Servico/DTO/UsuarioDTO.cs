using System;
using System.Collections.Generic;

namespace OPPI.Servico.DTO
{
    public class UsuarioDTO : DTOBase
    {
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public string Avatar { get; set; }
        public bool Ativo { get; set; }
        public DateTime UltimoAcesso { get; set; }
        public IList<DocumentoDTO> Documentos { get; set; }
        public IList<EnderecoDTO> Enderecos { get; set; }
        public IList<TelefoneDTO> Telefones { get; set; }
        public DateTime? DataAceiteTermos { get; set; }
        public DateTime? DataAceitePolitica { get; set; }
        public IList<LojaDTO> Lojas { get; set; }
        public IList<ProvedorDTO> Provedores { get; set; }
        public string Role { get; set; }
        public string Token { get; set; }
        public int CodigoConfirmacao { get; set; }
    }
}
