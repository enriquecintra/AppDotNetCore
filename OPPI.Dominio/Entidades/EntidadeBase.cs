using OPPI.Dominio.Attributes;
using System;

namespace OPPI.Dominio.Entidades
{
    public abstract class EntidadeBase
    {
        public int Id { get; set; }
        [SwaggerIgnore]
        public DateTime DataCadastro { get; set; }
        [SwaggerIgnore]
        public DateTime DataAlteracao { get; set; }
    }
}
