using System.ComponentModel.DataAnnotations;

namespace Eventplus_api_senai.DTO
{
    public class LoginDTO
    {
        [Required(ErrorMessage = "Informe o e-mail do usuário!!")]
        public string? Email { get; set; }

        [Required(ErrorMessage = "Informe a senha do usuário!!")]
        public string? Senha { get; set; }
    }
}
