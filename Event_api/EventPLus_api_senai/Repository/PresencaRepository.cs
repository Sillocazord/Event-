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
                Presenca presencaBuscada = _context.Presenca.Find(id)!;
                return presencaBuscada;
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
