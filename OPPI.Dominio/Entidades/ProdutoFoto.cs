namespace OPPI.Dominio.Entidades
{
    public class ProdutoFoto : EntidadeBase
    {
        public int ProdutoId { get; set; }
        public Produto Produto { get; set; }
        public int FotoId { get; set; }
        public Foto Foto { get; set; }
        public int Ordem { get; set; }
        public string Posicao { get; set; }
    }
}
