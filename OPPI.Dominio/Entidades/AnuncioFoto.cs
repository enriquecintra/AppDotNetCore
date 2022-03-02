namespace OPPI.Dominio.Entidades
{
    public class AnuncioFoto : EntidadeBase
    {
        public int AnuncioId { get; set; }
        public Anuncio Anuncio { get; set; }
        public int FotoId { get; set; }
        public Foto Foto { get; set; }
        public int Ordem { get; set; }
    }
}
