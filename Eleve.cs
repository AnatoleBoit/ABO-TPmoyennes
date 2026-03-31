namespace HNI_TPmoyennes;

class Eleve
{
    public string prenom { get; set; }
    public string nom {  get; set; }
    public List<Note> notes { get; set; } = new List<Note>(200);
    public Eleve(string _prenom, string _nom)
    {
        prenom = _prenom;
        nom = _nom;
    }

    public void ajouterNote(Note note)
    {
        notes.Add(note);
    }

    public float moyenneMatiere(int indice)
    {
        return (float)Math.Round(notes[indice].note, 2);
    }

    public float moyenneGeneral()
    {
        float somme = 0f;
        foreach (Note note in notes)
        {
            somme += note.note;
        }
        return (float)Math.Round(somme /notes.Count, 2);
    }
}
