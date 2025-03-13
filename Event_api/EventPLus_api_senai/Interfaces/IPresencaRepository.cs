using Eventplus_api_senai.Domais;

namespace Eventplus_api_senai.Interfaces
{
    public interface IPresencaRepository
    {
        List<Presenca> Listar();
        Presenca BuscarPorId(Guid id);
        void Atualizar(Guid id, Presenca presenca);
        Presenca Inscrever(Presenca Inscricao);
        List<Presenca> ListarMinhas();
        void Deletar(Guid id);
    }
}
