using Eventplus_api_senai.Context;
using Eventplus_api_senai.Domais;
using Eventplus_api_senai.Interfaces;

namespace Eventplus_api_senai.Repository
{
    public class EventoRepository : IEventoRepository
    {
        private readonly Event_Context _context;
        public EventoRepository(Event_Context context)
        {
                _context = context;
        }

        public void Atualizar(Guid id, Evento evento)
        {
            try
            {
                Evento eventoBuscado = _context.Evento.Find(id)!;
                if (eventoBuscado != null) 
                {
                    eventoBuscado.NomeEvento = evento.NomeEvento;
                }
                _context.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void Cadastrar(Evento novoEvento)
        {
            try
            {
                _context.Evento.Add(novoEvento);
                _context.SaveChanges();
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
                Evento eventoBuscado = _context.Evento.Find(id)!;
                if (eventoBuscado != null)
                {
                    _context.Evento.Remove(eventoBuscado);
                }
                _context.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<Evento> Listar()
        {
            try
            {
                List<Evento> listaEventos = _context.Evento.ToList();

                return listaEventos;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<Evento> ListarPorId(Guid id)
        {
            try
            {
                List<Evento> listaEvento = _context.Evento.Where(p => p.EventoID == id).ToList();
                return listaEvento;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<Evento> ListarProximosEventos(Guid id)
        {
            try
            {
                List<Evento> listarProximoEvento = _context.Evento.Where(e => e.DataEvento > DateTime.Now).OrderBy(e => e.DataEvento).ToList();
                return listarProximoEvento;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
