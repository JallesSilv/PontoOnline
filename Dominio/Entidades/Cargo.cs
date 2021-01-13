using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Dominio.Entidades
{
    [Table("Cargo")]
    public partial class Cargo
    {
        [Key]
        public Int64 ChaveCargo { get; set; }
        [MaxLength(50)]
        public string NomeCargo { get; set; }
    }
}
