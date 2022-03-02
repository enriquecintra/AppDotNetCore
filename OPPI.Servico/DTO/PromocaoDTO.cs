using OPPI.Dominio.Enums;
using System;
using System.Collections.Generic;

namespace OPPI.Servico.DTO
{
    public class PromocaoDTO : DTOBase
    {
        public LojaDTO Loja { get; set; }
        public string Foto { get; set; }
        public string Descricao { get; set; }
        public decimal Desconto { get; set; }
        public DateTime DataInicial { get; set; }
        public DateTime? DataFinal { get; set; }
        public bool Ativa { get; set; }
        public IList<ProdutoDTO> Produtos { get; set; }
    }
}
