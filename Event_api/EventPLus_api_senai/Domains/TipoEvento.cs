using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Eventplus_api_senai.Domais
{
    [Table("TipoEvento")]
    public class TipoEvento
    {
        [Key]
        public Guid TipoEventoID { get; set; }

        [Column(TypeName = "VARCHAR(20)")]
        [Required(ErrorMessage ="O nome do evento é obrigatorio")]
        public string? TituloTipoEvento { get; set; }

    }
}
