namespace OPPI.Dominio.Entidades
{
    public class ProdutoPromocao : EntidadeBase
    {
        public int ProdutoId { get; set; }
        public Produto Produto { get; set; }

        public int PromocaoId { get; set; }
        public Promocao Promocao { get; set; }
        public decimal Desconto { get; set; }
    }
}
