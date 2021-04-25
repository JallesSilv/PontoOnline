using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Dominio.Entidades
{
    [Table("Usuario")]
    public partial class Usuario
    {
        [Key]
        public Guid ChaveUsuario { get; set; }
        [ForeignKey("Empresa")]
        public Guid? ChaveEmpresa { get; set; }
        public virtual Empresa Empresa { get; set; }
        //[ForeignKey("NivelAcesso")]
        //public Int64? ChaveNivelAcesso { get; set; }
        //public virtual NivelAcesso NivelAcesso { get; set;}
        [ForeignKey("Cargo")]
        public Guid? ChaveCargo { get; set; }
        public virtual Cargo Cargo { get; set; }
        [ForeignKey("Endereco")]
        public Guid? ChaveEndereco { get; set; }
        public virtual Endereco Endereco { get; set; }
        [MaxLength(100)]
        public string Nome { get; set; }
        [MaxLength(1000)]
        public string Email { get; set; }
        [MaxLength(1000)]
        public string Senha { get; set; }
        [MaxLength(11)]
        public string Cpf { get; set; }
        public bool Ativo { get; set; }
    }
}
