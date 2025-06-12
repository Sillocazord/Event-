using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Eventplus_api_senai.Domais
{
    [Table("Eventos")]
    public class Evento
    {
        [Key]
        public Guid EventoID { get; set; }

        public Guid TipoEventoID { get; set; }

        [ForeignKey("TipoEventoID")]
        public TipoEvento? TipoEvento { get; set; }

        public Guid InstituicaoID { get; set; }

        [ForeignKey("InstituicaoID")]
        public Instituicao? Instituicao { get; set; }

        public ICollection<Presenca>? Presenca { get; set; } //public PresencasEventos? PresencasEventos {get; set;}

        [Column(TypeName ="VARCHAR(50)")]
        [Required(ErrorMessage ="O nome do evento é obrigatorio!")]
        public string? NomeEvento { get; set; }

        [Column(TypeName ="DATE")]
        [Required(ErrorMessage ="A data do evento é obrigatoria!")]
        public DateTime DataEvento { get; set; }

        [Column(TypeName = "TEXT")]
        [Required(ErrorMessage ="Descrição do evento é obrigatoria!!")]
        public string? Descricao { get; set; }
    }
}
