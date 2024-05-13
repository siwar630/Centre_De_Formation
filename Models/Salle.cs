using System.ComponentModel.DataAnnotations.Schema;

namespace Centre_de_formation.Models
{
    public class Salle
    {
        public Salle() { }
        public Salle(int id,int num, string d)
        {
            this.Id = id;
            this.NumSalle = num;
            this.Depatement = d;
        }


        

        public int Id { get; set; }
        public int NumSalle { get; set; }


        public virtual ICollection<Session>? Sessions { get; set; }
        public string Depatement { get; set; }
    }
}
