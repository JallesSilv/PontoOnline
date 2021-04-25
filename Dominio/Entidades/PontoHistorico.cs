using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Dominio.Entidades
{
    [Table("PontoHistorico")]
    public partial class PontoHistorico
    {
        [Key]
        public Guid ChavePontoHistorico { get; set; }
        public TimeSpan Horas { get; set; }
        public string Observacao { get; set; }
        [ForeignKey("Ponto")]
        public Guid ChavePonto { get; set; }
        public virtual Ponto Ponto { get; set; }
        [ForeignKey("Usuario")]
        public Guid ChaveUsuario { get; set; }
        public virtual Usuario Usuario { get; set; }
        [ForeignKey("Imagem")]
        public Guid ChaveImagem { get; set; }
        public virtual Imagem Imagem { get; set; }

    }
}
