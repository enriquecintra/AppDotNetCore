namespace OPPI.Dominio.Entidades
{
    public class LojaFoto : EntidadeBase
    {
        public int LojaId { get; set; }
        public Loja Loja { get; set; }
        public int FotoId { get; set; }
        public Foto Foto { get; set; }
        public int Ordem { get; set; }
        public string Posicao { get; set; }
    }
}
