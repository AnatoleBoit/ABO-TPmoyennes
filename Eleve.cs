namespace HNI_TPmoyennes;

class Eleve
{
    public string prenom { get; set; }
    public string nom {  get; set; }
    public Classe classe { get; }
    public List<Note> notes { get; set; } = new List<Note>(200);
    public Eleve(string _prenom, string _nom, Classe _classe)
    {
        prenom = _prenom;
        nom = _nom;
        classe = _classe;
    }

    public void ajouterNote(Note note)
    {
        if (notes.Count >= 200)
        {
            Console.WriteLine("Erreur : il ne peut y avoir que 200 notes par élève.");
            return;
        }
        notes.Add(note);
    }

    public float moyenneMatiere(int idMatiere)
    {
        float somme = 0f;
        int nbNoteMatiere = 0;
        foreach (Note note in notes)
        {
            if (note.matiere == idMatiere)
            {
                somme += note.note;
                ++nbNoteMatiere;
            }
        }
        if (nbNoteMatiere == 0)
        {
            Console.WriteLine($"{this.prenom} {this.nom} n'a aucune note pour la matière {idMatiere} !");
        }
        return (float)Math.Round(somme/nbNoteMatiere, 2);
    }

    public float moyenneGeneral()
    {
        if (classe.matieres.Count == 0)
        {
            Console.WriteLine($"La classe {this.classe.nomClasse} de l'élève {this.prenom} {this.nom} n'a aucune matière !");
        }
        float somme = 0f;
        for(int i=0; i<classe.matieres.Count; ++i)
        {
            somme += moyenneMatiere(i);
        }
        return (float)Math.Round(somme /classe.matieres.Count, 2);
    }
}
