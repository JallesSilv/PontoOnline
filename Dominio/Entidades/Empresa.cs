using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dominio.Entidades
{
    [Table("Empresa")]
    public partial class Empresa
    {
        [Key]
        public Int64 ChaveEmpresa { get; set; }
        public string NomeEmpresa { get; set; }
        public Int64 Cnpj { get; set; }
        public string Inscricao { get; set; }
        public DateTime DataCadastro { get; set; }
        [ForeignKey("Endereco")]
        public Int64 ChaveEndereco { get; set; }
        public virtual Endereco Endereco { get; set; }
    }
}
