using System.Collections.Generic;

namespace OPPI.WebApi.Requests
{
    public class LojaRequest
    {
        public string CNPJ { get; set; }
        public string Nome { get; set; }
        public string Resumo { get; set; }
        public string Descricao { get; set; }
        public int TipoFornecedor { get; set; }
        public string Logo { get; set; }
        public IList<TelefoneRequest> Telefones { get; set; }
        public bool Ativa { get; set; }
        public int UsuarioId { get; set; }
        public EnderecoRequest Endereco { get; set; }
    }
}
