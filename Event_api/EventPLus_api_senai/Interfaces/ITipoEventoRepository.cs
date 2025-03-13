using Eventplus_api_senai.Domais;

namespace Eventplus_api_senai.Interfaces
{
    public interface ITipoEventoRepository
    {
        void Cadastro(TipoEvento novoTipoEvento);
        List<TipoEvento> Listar();
        void Deletar(Guid id);
        void Atualizar(Guid id, TipoEvento tipoEvento);
        TipoEvento BuscarPorId(Guid id);
    }
}
