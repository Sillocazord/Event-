using Eventplus_api_senai.Domais;

namespace Eventplus_api_senai.Interfaces
{
    public interface IUsuarioRepository
    { 
        void Cadastrar (Usuario novoUsuario);
        Usuario BuscarPorId(Guid id);

        Usuario BuscarPorEmailESenha(string email, string senha);
    }
}
