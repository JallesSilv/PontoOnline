using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Dominio.Entidades
{
    [Table("Imagem")]
    public partial class Imagem
    {
        [Key]
        public Guid ChaveImagem { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime DataFinal { get; set; }
        public byte ByteImagem { get; set; }
    }
}
