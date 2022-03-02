namespace OPPI.Servico.DTO
{
    public class MensagemDTO : DTOBase
    {
        public UsuarioDTO Usuario { get; set; }
        public string Descricao { get; set; }
        public string Foto { get; set; }
    }
}