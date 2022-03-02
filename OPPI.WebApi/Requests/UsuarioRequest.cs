using OPPI.Dominio.Entidades;
using OPPI.Servico.DTO;

namespace OPPI.WebApi.Requests
{
    public class UsuarioRequest
    {
        public string Nome { get; set; }
        public string Email { get; set; }
        public string CPF { get; set; }
        public TelefoneDTO Telefone { get; set; }
        public EnderecoDTO Endereco { get; set; }
    }
}
