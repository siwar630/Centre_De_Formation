using System.ComponentModel.DataAnnotations.Schema;

namespace Centre_de_formation.Models
{
    public class Formateur : Personne
    {
        public Formateur() { }
        public Formateur(int id, string n, string p, string tel, double salaire) : base(n, p, tel)
        {
            this.Id = id;
            this.Salaire = salaire;
        }

        
        public int Id { get; set; }
        public double Salaire { get; set; }

        public virtual ICollection<Session>? Sessions { get; set; }
    }
}
