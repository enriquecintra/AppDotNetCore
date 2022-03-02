namespace OPPI.Servico.DTO
{
    public class AnuncioFotoDTO : DTOBase
    {
        public FotoDTO Foto { get; set; }
        public int Ordem { get; set; }
    }
}