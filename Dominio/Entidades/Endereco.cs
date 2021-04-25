using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Dominio.Entidades
{
    [Table("Endereco")]
    public partial class Endereco
    {
        [Key]
        public Guid ChaveEndereco { get; set; }

        [MaxLength(8)]
        public string Cep { get; set; }
        [MaxLength(2)]
        public string Uf { get; set; }
        [MaxLength(30)]
        public string Estado { get; set; }
        [MaxLength(50)]
        public string Cidade { get; set; }
        [MaxLength(50)]
        public string Bairro { get; set; }
        [MaxLength(500)]
        public string Complemento { get; set; }
        [MaxLength(500)]
        public string Logradouro { get; set; }
        public string Ibge { get; set; }
        [MaxLength(2)]
        public string Ddd { get; set; }
        public string Siafi { get; set; }
    }
}
