using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dominio.Entidades
{
    [Table("NivelAcesso")]
    public partial class NivelAcesso
    {
        [Key]
        public Guid ChaveNivelAcesso { get; set; }
        public string Descricao { get; set; }
        public bool TCargo { get; set; }
        public bool TUsuario { get; set; }
        public bool TEmpresa { get; set; }
        public bool TImagam { get; set; }
        public bool TPonto { get; set; }
        public bool Ativo { get; set; }
    }
}
