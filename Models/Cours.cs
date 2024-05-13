using System.ComponentModel.DataAnnotations.Schema;

namespace Centre_de_formation.Models
{
    public class Cours
    {
        public Cours()
        {

        }
        public Cours(int id, string nom)
        {
            this.Id = id;
            this.NomCours = nom;
            
        }
        public int Id { get; set; }
        public string NomCours { get; set; }



        
        
        public virtual ICollection<Formation>? Formations { get; set; }
    }
}
