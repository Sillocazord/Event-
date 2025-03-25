using Eventplus_api_senai.Domais;

namespace Eventplus_api_senai.Interfaces
{
    public interface IFeedbackRepository
    {
        void Cadastrar(Feedback novoFeedback);
        void Deletar (Guid id);
        List<Feedback> Listar(Guid id);

        Feedback BuscarPorIdUsuario(Guid UsuarioId, Guid EventoId);
    }
}