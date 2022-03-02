namespace OPPI.WebApi.Requests
{
    public class ProdutoRequest
    {
        public string Nome { get; set; }
        public string Resumo { get; set; }
        public string Descricao { get; set; }
        public decimal Valor { get; set; }
        public decimal Desconto { get; set; }
        public bool Destaque { get; set; }
        public int LojaId { get; set; }
        public int SegmentoId { get; set; }
    }
}
