using OPPI.Dominio.Enums;

namespace OPPI.Servico.DTO
{
    public class EnderecoDTO : DTOBase
    {
        public TipoEnderecoEnum TipoEndereco { get; set; }
        public string CEP { get; set; }
        public string Logradouro { get; set; }
        public string Numero { get; set; }
        public string Complemento { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string UF { get; set; }
        public bool Padrao { get; set; }
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }
    }
}
