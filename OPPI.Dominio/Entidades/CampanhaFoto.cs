namespace OPPI.Dominio.Entidades
{
    public class CampanhaFoto : EntidadeBase
    {
        public int CampanhaId { get; set; }
        public Campanha Campanha { get; set; }
        public int FotoId { get; set; }
        public Foto Foto { get; set; }
        public int Ordem { get; set; }
    }
}
