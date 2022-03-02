using System.Collections.Generic;

namespace OPPI.Servico.DTO
{
    public class ProvedorDTO : DTOBase
    {
        public string RazaoSocial { get; set; }
        public string CNPJ { get; set; }
        public IList<TelefoneDTO> Telefones { get; set; }
        public bool Ativo { get; set; }
        public IList<UsuarioDTO> Usuarios { get; set; }
        public EnderecoDTO Endereco { get; set; }
    }
}
