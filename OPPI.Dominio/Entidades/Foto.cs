using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace OPPI.Dominio.Entidades
{
    public class Foto : EntidadeBase
    {
        [Column(TypeName = "varchar(100)")]
        public string Descricao { get; set; }
        public string Base64 { get; set; }
        public IList<LojaFoto> LojaFotos { get; set; }
        public IList<ProdutoFoto> ProdutoFotos { get; set; }
        public IList<AnuncioFoto> AnuncioFotos { get; set; }
        public IList<CampanhaFoto> CampanhaFotos { get; set; }

    }
}
