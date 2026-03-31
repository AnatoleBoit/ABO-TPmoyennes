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
        eleves.Add(new Eleve(prenom, nom));
    }

    public void ajouterMatiere(string nomMatiere)
    {
        matieres.Add(nomMatiere);
    }

    public float moyenneMatiere(int indice)
    {
        float somme = 0f;
        foreach (Eleve eleve in eleves)
        {
            somme += eleve.notes[indice].note;
        }
        return (float) Math.Round(somme / this.eleves.Count, 2);
    }

    public float moyenneGeneral()
    {
        float somme = 0f;
        for(int i=0; i<matieres.Count;++i)
        {
            somme += moyenneMatiere(i);
        }
        return (float)Math.Round(somme / matieres.Count, 2);
    }
}
