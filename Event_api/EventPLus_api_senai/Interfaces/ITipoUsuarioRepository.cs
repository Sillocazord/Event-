using Eventplus_api_senai.Domais;

namespace Eventplus_api_senai.Interfaces
{
    public interface ITipoUsuarioRepository
    {
        void Cadastro(TipoUsuario novoTipoUsuario);
        List<TipoUsuario> Listar();
        void Deletar(Guid id);
        void Atualizar(Guid id, TipoUsuario tipoUsuario);
        TipoUsuario BuscarPorId(Guid id);
    }
}
