using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Eventplus_api_senai.Domais
{
    [Table("Presenca")]
    public class Presenca
    {
        [Key]
        public Guid PresencaID { get; set; }

        public Guid EventoID { get; set; }
        [ForeignKey("EventoID")]
        public Evento? Evento { get; set; }
        
        public Guid UsuarioID { get; set; }

        [ForeignKey("UsuarioID")] 
        public Usuario? Usuario { get; set; }

        [Column(TypeName ="BIT")]
        public bool? Situacao { get; set; }

    }
}
