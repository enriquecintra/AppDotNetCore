namespace OPPI.Dominio.Entidades
{
    public class LojaCampanha : EntidadeBase
    {
        public int LojaId { get; set; }
        public Loja Loja { get; set; }
        public int CampanhaId { get; set; }
        public Campanha Campanha { get; set; }
    }
}
