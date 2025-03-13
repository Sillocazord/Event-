using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Eventplus_api_senai.Domais
{

    [Table ("TipoUsuario")]
    public class TipoUsuario
    {
        [Key]
        public Guid TipoUsuarioID { get; set; }
        [Column(TypeName = "VARCHAR(15)")]
        public string? TituloTipoUsuario { get; set; }
    }
}
