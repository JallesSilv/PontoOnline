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
        public Int64 ChavePontoHistorico { get; set; }
        public TimeSpan Horas { get; set; }
        public string Observacao { get; set; }
        [ForeignKey("Ponto")]
        public Int64 ChavePonto { get; set; }
        public virtual Ponto Ponto { get; set; }
        [ForeignKey("Usuario")]
        public Int64 ChaveUsuario { get; set; }
        public virtual Usuario Usuario { get; set; }
        [ForeignKey("Imagem")]
        public Int64 ChaveImagem { get; set; }
        public virtual Imagem Imagem { get; set; }

    }
}
