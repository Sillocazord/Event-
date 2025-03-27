using Eventplus_api_senai.Domais;
using Eventplus_api_senai.DTO;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Eventplus_api_senai.Interfaces;
using Eventplus_api_senai.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace Eventplus_api_senai.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class LoginController : ControllerBase
    {
        private readonly IUsuarioRepository _usuariosRepository;
        public LoginController(IUsuarioRepository usuarioRepository)
        {
            _usuariosRepository = usuarioRepository;
        }

        /// <summary>
        /// Endpoint para Fazer Login.
        /// </summary>
        /// <param name="loginDTO"></param>
        /// <returns>Login</returns>
        [HttpPost]
        public IActionResult Login(LoginDTO loginDTO)
        {
            try
            {
                Usuario usuarioBuscado = _usuariosRepository.BuscarPorEmailESenha(loginDTO.Email!, loginDTO.Senha!);
                if (usuarioBuscado == null)
                {
                    return NotFound("Usuário não encontrado, email ou senha inválidos");
                }
                //1 Passo- Definir as Claims() que serão fornecidos no token
                var claims = new[]
                {
                new Claim(JwtRegisteredClaimNames.Jti,usuarioBuscado.UsuarioID.ToString()),
                new Claim(JwtRegisteredClaimNames.Email,usuarioBuscado.Email!),
                new Claim(JwtRegisteredClaimNames.Name,usuarioBuscado.Nome!),
                new Claim("Tipo do usuário", usuarioBuscado.TipoUsuario.TituloTipoUsuario.ToString()!),

                };
                //2 Passo-
                var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("event-chave-autenticacao-webapi-dev"));
                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                var token = new JwtSecurityToken
                    (
                    //emissor do token
                    issuer: "Eventplus_api_senai",
                    //destinatário do token
                    audience: "Eventplus_api_senai",
                    //dados definidos nas claims
                    claims: claims,
                    //tempo de expiração do token
                    expires: DateTime.Now.AddMinutes(5),
                    //credenciais do token
                    signingCredentials: creds
                    );
                //retorna o token criado
                return Ok(
                    new { token = new JwtSecurityTokenHandler().WriteToken(token) }
                    );
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }

        }
    }
}
