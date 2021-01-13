using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dominio.Entidades
{
    [Table("NivelAcesso")]
    public partial class NivelAcesso
    {
        [Key]
        public Int64 ChaveNivelAcesso { get; set; }
        public string NomeNivelAcesso { get; set; }
        public bool Ativo { get; set; }
    }
}
