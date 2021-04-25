using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Dominio.Entidades
{
    [Table("Ponto")]
    public partial class Ponto
    {
        [Key]
        public Guid ChavePonto { get; set; }
        public DateTime Data { get; set; }
    }
}
