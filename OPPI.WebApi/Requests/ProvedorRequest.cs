using OPPI.Servico.DTO;
using System.Collections.Generic;

namespace OPPI.WebApi.Requests
{
    public class ProvedorRequest
    {
        public string RazaoSocial { get; set; }
        public string CNPJ { get; set; }
        public IList<TelefoneDTO> Telefones { get; set; }
        public bool Ativo { get; set; }
        public EnderecoDTO Endereco { get; set; }
    }
}
