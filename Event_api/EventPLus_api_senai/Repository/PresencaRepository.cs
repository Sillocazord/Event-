using Eventplus_api_senai.Context;
using Eventplus_api_senai.Domais;
using Eventplus_api_senai.Interfaces;

namespace Eventplus_api_senai.Repository
{
    public class PresencaRepository : IPresencaRepository
    {
        private readonly Event_Context _context;
        public PresencaRepository(Event_Context context) 
        {
         _context = context;
        }

        public void Atualizar(Guid id, Presenca presenca)
        {
            try
            {
                Presenca presencaBuscado = _context.Presenca.Find(id)!;
                if (presencaBuscado != null) 
                {
                    presencaBuscado.Situacao = presenca.Situacao;
                }
                _context.SaveChanges();

            }
            catch (Exception)
            {

                throw;
            }
        }

        public Presenca BuscarPorId(Guid id)
        {
            try
            {
                return _context.Presenca
                   .Select(p => new Presenca
                   {
                       PresencaID = p.PresencaID,
                       Situacao = p.Situacao,

                       Evento = new Evento
                       {
                           EventoID = p.EventoID!,
                           DataEvento = p.Evento!.DataEvento,
                           NomeEvento = p.Evento.NomeEvento,
                           Descricao = p.Evento.Descricao,

                           Instituicao = new Instituicao
                           {
                               InstituicaoID = p.Evento.Instituicao!.InstituicaoID,
                               NomeFantasia = p.Evento.Instituicao!.NomeFantasia
                           }
                       }

                   }).FirstOrDefault(p => p.PresencaID == id)!;
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
                Presenca presencaBuscada = _context.Presenca.Find(id)!;
                if(presencaBuscada != null)
                {
                    _context.Presenca.Remove(presencaBuscada);
                }
                _context.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void Inscrever(Presenca Inscricao)
        {
            try
            {
                Inscricao.PresencaID = Guid.NewGuid();

                _context.Presenca.Add(Inscricao);

                _context.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<Presenca> Listar()
        {
            try
            {
                List<Presenca> listaPresenca = _context.Presenca.ToList();
                return listaPresenca;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<Presenca> ListarMinhas(Guid id)
        {
            try
            {
                List<Presenca> listaPresenca = _context.Presenca.Where(p => p.UsuarioID == id).ToList();
                return listaPresenca;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
