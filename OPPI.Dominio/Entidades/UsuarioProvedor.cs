namespace OPPI.Dominio.Entidades
{
    public class UsuarioProvedor : EntidadeBase
    {
        public UsuarioProvedor(int provedorId, int usuarioId)
        {
            ProvedorId = provedorId;
            UsuarioId = usuarioId;
        }

        public int UsuarioId { get; set; }
        public Usuario Usuario { get; set; }
        public int ProvedorId { get; set; }
        public Provedor Provedor { get; set; }
    }
}
