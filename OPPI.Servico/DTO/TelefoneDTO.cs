using OPPI.Dominio.Enums;

namespace OPPI.Servico.DTO
{
    public class TelefoneDTO : DTOBase
    {
        public TipoTelefoneEnum TipoTelefone { get; set; }
        public int DDI { get; set; }
        public int DDD { get; set; }
        public string Numero { get; set; }
        public string Ramal { get; set; }
    }
}
