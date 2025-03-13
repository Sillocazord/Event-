using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Eventplus_api_senai.Domais
{
    [Table("Usuario")]
    [Index(nameof(Email), IsUnique = true)]
    public class Usuario
    {
        [Key]
        public Guid UsuarioID { get; set; }

        [Required(ErrorMessage ="O tipo de usuário é obrigatorio!")]
        public Guid TipoUsuarioID { get; set; }

        [ForeignKey("TipoUsuarioID")]
        public TipoUsuario? TipoUsuario { get; set; }

        [Column(TypeName ="VARCHAR(50)")]
        [Required(ErrorMessage = "O nome é obrigatório")]
        public string? Nome { get; set; }

        [Column(TypeName ="VARCHAR(100)")]
        [Required(ErrorMessage = "O Email é obrigatorio")]
        public string? Email { get; set; }

        [Column(TypeName ="VARCHAR(60)")]
        [Required(ErrorMessage ="A senha é obrigatoria")]
        [StringLength(60, MinimumLength = 6, ErrorMessage ="A senha deve conter no minimo 6 caracteres, e no maximo 60")]
        public string? Senha { get; set; }
    }
}
