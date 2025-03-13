using Eventplus_api_senai.Domais;
using Microsoft.EntityFrameworkCore;

namespace Eventplus_api_senai.Context
{
    public class Event_Context : DbContext
    {
        public Event_Context()
        {

        }
        public Event_Context(DbContextOptions<Event_Context> options) : base(options)
        { 
        }

        public DbSet<TipoUsuario> TipoUsuario { get; set; }
        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<Institucao> Instituicao { get; set; }
        public DbSet<TipoEvento> TipoEvento { get; set; }
        public DbSet<Evento> Evento { get; set; }
        public DbSet<Presenca> Presenca { get; set; }
        public DbSet<Feedback> Feedback { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=NOTE40-S28\\SQLEXPRESS; Database=Event; User Id=sa; Pwd=Senai@134; TrustServerCertificate=true;");
            }

        }


    }
}
