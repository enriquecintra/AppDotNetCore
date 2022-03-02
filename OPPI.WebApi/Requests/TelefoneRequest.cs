namespace OPPI.WebApi.Requests
{
    public class TelefoneRequest
    {
        public int TipoTelefone { get; set; }
        public int DDI { get; set; }
        public int DDD { get; set; }
        public string Numero { get; set; }
        public string Ramal { get; set; }
    }
}