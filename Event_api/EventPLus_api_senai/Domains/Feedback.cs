using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Eventplus_api_senai.Domais
{
    [Table("Feedback")]
    public class Feedback
    {
        [Key]
        public Guid FeedbackID { get; set; }

        public Guid EventoID { get; set; }  
        [ForeignKey("EventoID")]
        public Evento? Evento { get; set; }


        public Guid UsuarioID { get; set; }
        [ForeignKey("UsuarioID")]
        public Usuario? Usuario { get; set; }

        [Column(TypeName ="VARCHAR(300)")]
        public string? Descricao { get; set; }

        [Column(TypeName ="BIT")]
        public bool? Exibir {  get; set; }
    }
}
