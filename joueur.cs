public class Joueur
{
	public int Num { get; set; }
	public string Nom { get; set; }
    public string Couleur { get; set; }
	public int Ress_bois { get; set; }
	public int Ress_or { get; set; }
	public int Ress_pierre { get; set; }
	public int Ress_mana { get; set; }
	public int Ress_population { get; set; }
	public bool Vaincu { get; set; } // <- Si le joueur a perdu OU déclarer forfait
	public bool Vainqueur { get; set; } // <- Si le joueur a gagné (il est le seul restant...)

    public Joueur(int _num, string _nom)
    {
        Num = _num;
        Ress_bois = 100;
        Ress_or = 50;
		Ress_pierre: 150;
        Ress_mana = 0;
        Ress_population = 10;
		switch (Num)
        {
            case 1:
                Couleur = "Rouge";
            case 2:
                Couleur = "Bleu";
            case 3:
                Couleur = "Vert";
            case 4:
                Couleur = "Bleu clair";
            case 5:
                Couleur = "Jaune";
            case 6:
                Couleur = "Mauve";
            case 7:
                Couleur = "Orange";
            case 8:
                Couleur = "Brun";
        }
    }


	//===========================================
	// Méthodes d'ajout de ressources
	//===========================================
	public void AjouterBois(int nbr)
    {
        Ress_bois += nbr;
    }
    public void AjouterOr(int nbr)
    {
        Ress_or += nbr;
    }
    public void AjouterPierre(int nbr)
    {
        Ress_pierre += nbr;
    }
    public void AjouterMana(int nbr)
    {
        Ress_mana += nbr;
    }
    public void AjouterPopulation(int nbr)
    {
        Ress_population += nbr;
    }


    //===========================================
    // Méthodes de retrait de ressources
    //===========================================
    public void RetirerBois(int nbr)
    {
        Ress_bois -= nbr;
    }
    public void RetirerOr(int nbr)
    {
        Ress_or -= nbr;
    }
    public void RetirerPierre(int nbr)
    {
        Ress_pierre -= nbr;
    }
    public void RetirerMana(int nbr)
    {
        Ress_mana -= nbr;
    }
    public void RetirerPopulation(int nbr)
    {
        Ress_population -= nbr;
    }


    //===========================================
    // Actions joueur
    //===========================================
    public void Abondonner()
    {
        Vaincu = true;
    }
}