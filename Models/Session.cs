using System.ComponentModel.DataAnnotations.Schema;

namespace Centre_de_formation.Models
{
    public class Session
    {
        public Session() { }

        public Session(int id, int duree, Salle s, DateTime date, Formateur formateur, Formation f)
        {
            this.Id = id;
            this.duree = duree;
            this.dateDebut = date;
            this.Formateur = formateur;
            this.Formation = f;
            this.Participants = new List<Participant>();
            this.Salle = s;
        }
        
        public int Id { get; set; }

   

        public int duree { get; set; }
        public DateTime dateDebut { get; set; }
        public int SalleId { get; set; }
        public int FormateurId { get; set; }
        public int FormationId { get; set; }
        public virtual Salle? Salle { get; set; }
        
        public virtual ICollection<Participant>? Participants { get; set; }
        public virtual Formateur? Formateur { get; set; }
        public virtual Formation? Formation { get; set; }
    }
}
