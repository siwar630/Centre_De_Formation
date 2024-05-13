using Microsoft.EntityFrameworkCore;

namespace Centre_de_formation.Models
{
    public class CentreFormationContext:DbContext
    {

        public CentreFormationContext(DbContextOptions<CentreFormationContext> options):base(options)
        {

        }
        public DbSet<Formateur> Formateurs { get; set; }
        public DbSet<Participant> Participants { get; set; }
        public DbSet<Formation> Formations { get; set; }
        public DbSet<Salle> Salles { get; set; }
        public DbSet<Cours> Cours { get; set; }
        public DbSet<Session> Sessions { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies(); // Enable lazy loading
        }
    }
}
