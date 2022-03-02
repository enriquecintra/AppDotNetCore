using OPPI.Dominio.Enums;
using System.Collections.Generic;

namespace OPPI.Servico.DTO
{
    public class CategoriaDTO : DTOBase
    {
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public string Foto { get; set; }
        public TipoCategoriaEnum Tipo { get; set; }
        public IList<SegmentoDTO> Segmentos { get; set; }
        public string Icone { get; set; }
    }
}