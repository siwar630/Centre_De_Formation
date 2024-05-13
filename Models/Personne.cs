namespace Centre_de_formation.Models
{
    public class Personne
    {
        public Personne() { }
        public Personne(string n, string p, string tel)
        {
            this.Nom = n;
            this.Prenom = p;
            this.Tel = tel;
        }



        public string Nom { get; set; }
        public string Prenom { get; set; }
        public string Tel { get; set; }
    }
}
