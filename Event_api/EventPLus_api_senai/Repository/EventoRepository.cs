﻿using Eventplus_api_senai.Context;
using Eventplus_api_senai.Domais;
using Eventplus_api_senai.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Eventplus_api_senai.Repository
{
    /// <summary>
    /// Repositório para gerenciamento dos eventos
    /// </summary>
    public class EventoRepository : IEventoRepository
    {
        private readonly Event_Context _context;

        /// <summary>
        /// Repositório para gerenciamento dos eventos
        /// </summary>
        public EventoRepository(Event_Context context)
        {
                _context = context;
        }


        /// <summary>
        /// Repositório para gerenciamento dos eventos
        /// </summary>
        public void Atualizar(Guid id, Evento evento)
        {
            try
            {
                Evento eventoBuscado = _context.Evento.Find(id)!;
                if (eventoBuscado != null) 
                {
                    eventoBuscado.NomeEvento = evento.NomeEvento;
                    eventoBuscado.DataEvento = evento.DataEvento;
                    eventoBuscado.Descricao = evento.Descricao;
                    eventoBuscado.TipoEventoID = evento.TipoEventoID;
                }
                _context.Evento.Update(eventoBuscado!);
                _context.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }


        /// <summary>
        /// Repositório para gerenciamento dos eventos
        /// </summary>
        public void Cadastrar(Evento novoEvento)
        {
            try
            {
                if (novoEvento.DataEvento < DateTime.Now) 
                {
                    throw new ArgumentException("A data do evento deve ser maior ou igual a data atual.");
                }
                novoEvento.EventoID = Guid.NewGuid();
                _context.Evento.Add(novoEvento);
                _context.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }


        /// <summary>
        /// Repositório para gerenciamento dos eventos
        /// </summary>
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


        /// <summary>
        /// Repositório para gerenciamento dos eventos
        /// </summary>
        public List<Evento> Listar()
        {
            try
            {
                return _context.Evento
                    .Select(e => new Evento
                    {
                        EventoID = e.EventoID,
                        NomeEvento = e.NomeEvento,
                        Descricao = e.Descricao,
                        DataEvento = e.DataEvento,
                        TipoEventoID = e.TipoEventoID,
                        TipoEvento = new TipoEvento
                        {
                            TipoEventoID = e.TipoEventoID,
                            TituloTipoEvento = e.TipoEvento!.TituloTipoEvento
                        },
                        InstituicaoID = e.InstituicaoID,
                        Instituicao = new Instituicao
                        {
                            InstituicaoID = e.InstituicaoID,
                            NomeFantasia = e.Instituicao!.NomeFantasia
                        }
                    }).ToList();
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
                return _context.Evento
                    .Include(e => e.Presenca)
                    .Where(e => e.Presenca!.Any(p => p.UsuarioID == id && p.Situacao == true))
                    .Select(e => new Evento
                    {
                        EventoID = e.EventoID,
                        NomeEvento = e.NomeEvento,
                        Descricao = e.Descricao,
                        DataEvento = e.DataEvento,
                        TipoEventoID = e.TipoEventoID,
                        TipoEvento = new TipoEvento
                        {
                            TipoEventoID = e.TipoEventoID,
                            TituloTipoEvento = e.TipoEvento!.TituloTipoEvento
                        },
                        InstituicaoID = e.InstituicaoID,
                        Instituicao = new Instituicao
                        {
                            InstituicaoID = e.InstituicaoID,
                            NomeFantasia = e.Instituicao!.NomeFantasia
                        },
                        // Aqui você monta uma lista com as presenças válidas (opcional)
                        Presenca = e.Presenca
                            .Where(p => p.UsuarioID == id && p.Situacao == true)
                            .ToList()
                    })
                    .ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }
        /// <summary>
        /// Repositório para gerenciamento dos eventos
        /// </summary>
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

        /// <summary>
        /// Repositório para gerenciamento dos eventos
        /// </summary>
        public Evento BuscarPorId(Guid id)
        {
            try
            {
                return _context.Evento
                    .Select(e => new Evento
                    {
                        EventoID = e.EventoID,
                        NomeEvento = e.NomeEvento,
                        Descricao = e.Descricao,
                        DataEvento = e.DataEvento,
                        TipoEvento = new TipoEvento
                        {
                            TituloTipoEvento = e.TipoEvento!.TituloTipoEvento
                        },
                        Instituicao = new Instituicao
                        {
                            NomeFantasia = e.Instituicao!.NomeFantasia
                        }
                    }).FirstOrDefault(e => e.EventoID == id)!;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
