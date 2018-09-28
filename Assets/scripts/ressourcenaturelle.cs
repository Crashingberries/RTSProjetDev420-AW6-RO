public class RessourceNaturelle
{
    public string Type { get; set; }
    public int Quantite { get; set; }
    public bool Epuise { get; set; }

    public RessourceNaturelle()
    {
        Type = "bois";
        Quantite = 1;
        Epuise = false;
    }

    public RessourceNaturelle(string _type, int _quantite)
    {
        Type = _type;
        Quantite = _quantite;
        Epuise = false;
    }

    public void Retirer(int _montant)
    {
        if (Epuise = false)
        {
            Quantite -= _montant;
            if (Quantite <= 0)
            {
                Quantite = 0;
                Epuise = true;
            }
        }
    }
}