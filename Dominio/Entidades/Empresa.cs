using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dominio.Entidades
{
    [Table("Empresa")]
    public partial class Empresa
    {
        [Key]
        public Guid ChaveEmpresa { get; set; }
        [MaxLength(100)]
        public string NomeEmpresa { get; set; }
        [MaxLength(14)]
        public Int64 Cnpj { get; set; }
        [MaxLength(20)]
        public string Inscricao { get; set; }
        public DateTime DataCadastro { get; set; }
        [ForeignKey("Endereco")]
        public Guid ChaveEndereco { get; set; }
        public virtual Endereco Endereco { get; set; }
    }
}
