using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Eventplus_api_senai.Domais
{
    [Table("Instituicao")]
    [Index(nameof(CNPJ), IsUnique =true)]
    public class Institucao
    {
        [Key]
        public Guid InstituicaoID { get; set; }

        [Column(TypeName ="VARCHAR(100)")]
        [Required(ErrorMessage ="Nome Fantasia é obrigatorio!!")]
        public string? NomeFantasia { get; set; }

        [Column(TypeName ="VARCHAR(100)")]
        [Required(ErrorMessage ="É Obrigatorio informar um endereço!")]
        public string? Endereço { get; set; }

        [Column(TypeName ="VARCHAR(14)")]
        [Required(ErrorMessage="CNPJ é obrigatorio!")]
        [StringLength(14)]
        public string? CNPJ { get; set; }
    }
}
