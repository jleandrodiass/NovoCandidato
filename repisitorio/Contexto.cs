using Microsoft.EntityFrameworkCore;
using Candidatos.modelo;

namespace Candidatos.repositorio
{
    public partial class Contexto : DbContext
    {
        public Contexto()
        {
        }

        public Contexto(DbContextOptions<Contexto> options)
         : base(options)
        {
        }

        public virtual DbSet<Candidato> Candidato { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=Candidato;Data Source=DESKTOP-321DA7H\\SQLEXPRESS");

            }
        }

    }
}

