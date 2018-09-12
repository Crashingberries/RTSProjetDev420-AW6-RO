public class RessourceNaturelle
{
    public int Stock { get; set; }
    public bool Epuise { get; set; }
    public string Type { get; set; }

    public RessourceNaturelle(string _type, int _stock)
    {
        Type = _type;
        Stock = _stock;
    }

    public void Retirer(int _montant)
    {
        if (!Epuise)
        {
            Stock -= _montant;
            if (Stock <= 0)
            {
                Stock = 0;
                Epuise = true;
            }
        }
    }
}