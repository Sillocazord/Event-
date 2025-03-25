using Eventplus_api_senai.Context;
using Eventplus_api_senai.Domais;
using Eventplus_api_senai.Interfaces;

namespace Eventplus_api_senai.Repository
{
    public class FeedbackRepository : IFeedbackRepository
    {
        private readonly Event_Context _context;

        public FeedbackRepository(Event_Context context)
        {
            _context = context;
        }

        public Feedback BuscarPorIdUsuario(Guid UsuarioId, Guid EventoId)
        {
            try
            {
                return _context.Feedback
                     .Select(c => new Feedback
                     {
                         FeedbackID = c.FeedbackID,
                         Descricao = c.Descricao,
                         Exibir = c.Exibir,
                         UsuarioID = c.UsuarioID,
                         EventoID = c.EventoID,

                         Usuario = new Usuario
                         {
                             Nome = c.Usuario!.Nome
                         },

                         Evento = new Evento
                         {
                             NomeEvento = c.Evento!.NomeEvento,
                         }

                     }).FirstOrDefault(c => c.UsuarioID == UsuarioId && c.EventoID == EventoId)!;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void Deletar(Guid id)
        {
            try
            {
                Feedback feedbackBuscado = _context.Feedback.Find(id)!;
                if (feedbackBuscado != null) 
                {
                    _context.Feedback.Remove(feedbackBuscado);
                }
                _context.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<Feedback> Listar(Guid id)
        {
            try
            {
                return _context.Feedback
                    .Select(c => new Feedback
                    {
                        FeedbackID = c.FeedbackID,
                        Descricao = c.Descricao,
                        Exibir = c.Exibir,
                        UsuarioID = c.UsuarioID,
                        EventoID = c.EventoID,

                        Usuario = new Usuario
                        {
                            Nome = c.Usuario!.Nome
                        },

                        Evento = new Evento
                        {
                            NomeEvento = c.Evento!.NomeEvento,
                        }

                    }).Where(c => c.EventoID == id).ToList();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void Cadastrar(Feedback novoFeedback)
        {
            try
            {
                novoFeedback.FeedbackID = Guid.NewGuid();

                _context.Feedback.Add(novoFeedback);

                _context.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
