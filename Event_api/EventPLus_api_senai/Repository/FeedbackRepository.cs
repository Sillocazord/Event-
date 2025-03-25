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
                Feedback feedbackBuscado = _context.Feedback.Find(UsuarioId)!;
                return feedbackBuscado;
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

        public List<Feedback> Listar()
        {
            try
            {
                List<Feedback> listaFeedback = _context.Feedback.ToList();
                return listaFeedback;
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
