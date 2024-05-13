using System.ComponentModel.DataAnnotations.Schema;

namespace Centre_de_formation.Models
{
    public class Participant : Personne
    {
        public Participant() { }
        public Participant(int id, string n, string p, string tel, bool etat) : base(n, p, tel)
        {
            this.Id = id;
            this.EtatPayment = etat;
        }
        
        public int Id { get; set; }

        public bool EtatPayment { get; set; }

        
        public virtual ICollection<Session>? Sessions { get; set; }
    }
}
