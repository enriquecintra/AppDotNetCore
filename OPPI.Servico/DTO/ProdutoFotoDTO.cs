namespace OPPI.Servico.DTO
{
    public class ProdutoFotoDTO : DTOBase
    {
        public FotoDTO Foto { get; set; }
        public int Ordem { get; set; }
        public string Posicao { get; set; }
    }
}