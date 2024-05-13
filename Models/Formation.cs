using System.ComponentModel.DataAnnotations.Schema;

namespace Centre_de_formation.Models
{
    public class Formation
    {
        public Formation() { }
        public Formation(int id, string nom, double prix, Cours c)
        {
            Id = id;
            NomFormation = nom;
            PrixFormation = prix;
            Cours = c;
        }
        
        public int Id { get; set; }

        public string NomFormation { get; set; }

        public double PrixFormation { get; set; }

        public int CoursId { get; set; } 
        public virtual Cours? Cours { get; set; }


        public virtual ICollection<Session>? Sessions { get; set; }
    }
}
