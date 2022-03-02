using System;
using System.Collections.Generic;

namespace OPPI.Servico.DTO
{
    public class AnuncioDTO : DTOBase
    {
        public LojaDTO Loja { get; set; }
        public string Foto { get; set; }
        public string Descricao { get; set; }
        public DateTime DataInicial { get; set; }
        public DateTime? DataFinal { get; set; }
        public IList<AnuncioFotoDTO> AnuncioFotos { get; set; }
    }
}
