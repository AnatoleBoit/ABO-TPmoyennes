namespace HNI_TPmoyennes;

class Classe
{
    public string nomClasse {  get; set; }
    public List<Eleve> eleves { get; set; } = new List<Eleve>(30);
    public List<string> matieres { get; set; } = new List<string>(10);
    public Classe(string _nomClasse)
    {
        nomClasse = _nomClasse;
    }

    public void ajouterEleve(string prenom, string nom)
    {
        if (eleves.Count >= 30)
        {
            Console.WriteLine("Erreur : il ne peut y avoir que 30 élèves par classe.");
            return;
        }
        eleves.Add(new Eleve(prenom, nom, this));
    }

    public void ajouterMatiere(string nomMatiere)
    {
        if (matieres.Count >= 10)
        {
            Console.WriteLine("Erreur : il ne peut y avoir que 10 matières par classe.");
            return;
        }
        matieres.Add(nomMatiere);
    }

    public float moyenneMatiere(int idMatiere)
    {
        if (this.eleves.Count == 0)
        {
            Console.WriteLine($"Erreur : il n'y a aucun élève dans la classe {this.nomClasse} !");
            return 0f;
        }
        float somme = 0f;
        foreach (Eleve eleve in eleves)
        {
            somme += eleve.moyenneMatiere(idMatiere);
        }
        return (float) Math.Round(somme / this.eleves.Count, 2);
    }

    public float moyenneGeneral()
    {
        if (this.matieres.Count == 0)
        {
            Console.WriteLine($"Erreur : il n'y a aucune matière dans la classe {this.nomClasse} !");
            return 0f;
        }
        float somme = 0f;
        for(int i=0; i<matieres.Count;++i)
        {
            somme += moyenneMatiere(i);
        }
        return (float)Math.Round(somme / matieres.Count, 2);
    }
}
