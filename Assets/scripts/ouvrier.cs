<<<<<<< HEAD
public class Ouvrier : Unit
=======
public class Ouvrier : Unité
>>>>>>> Julien
{
    public static Batiment[] BatimentsAConstruire;
	public bool EnConstruction { get; set; }
    public bool EnReparation { get; set; }
	public bool EnExploitation { get; set; }

<<<<<<< HEAD
    public Ouvrier(int PvM, int PaM, Position _pos, int _vitesse, bool _enDepl, Position _pointDepl, object _cible) : base(PvM, PaM, _pos, _vitesse, _enDepl, _pointDepl, _cible)
=======
    //j'ai ajouté
    public Ouvrier() : base()
    {
        EnConstruction = false;
        EnReparation = false;
        EnExploitation = false;
    }

    //j'ai ajouté
    public Ouvrier(int unPv, int uneArmure, Position unePosition, string unNom, int unCoutOr, int unCoutBois, int uneVitesseDeplacement, int unePuissanceAttaque, int unePortéeMin, int unePortéeMax, int unePuissanceAttaque, int uneVitesseAttaque) : 
        base(unPv, uneArmure, unePosition, unNom, unCoutOr, unCoutBois, uneVitesseDeplacement, unePuissanceAttaque, unePortéeMin, unePortéeMax, unePuissanceAttaque, uneVitesseAttaque)
    {
        EnConstruction = false;
        EnReparation = false;
        EnExploitation = false;
    }

    public Ouvrier(int PvM, int PaM, Position _pos, int _vitesse, bool _enDepl, Position _pointDepl, object _cible, int _attaque) : base(PvM, PaM, _pos, _vitesse, _enDepl, _pointDepl, _cible, _attaque)
>>>>>>> Julien
    {
        PV = PvM; PvMax = PvM;
        Armure = PaM; ArmureMax = PaM;
        Pos = new Position();
        Vitesse = _vitesse;
        EnDeplacement = _enDepl;
        EnAttaque = false;
        PointDeplacement = _pointDepl;
        Cible = _cible;
        PorteeMax = 0; // nombres Non significatifs... 
        PorteeMin = 0; //
<<<<<<< HEAD
=======
        Attaque = _attaque;
>>>>>>> Julien
        EnConstruction = false;
        EnReparation = false;
    }

<<<<<<< HEAD
	public override void Attaquer(Construction _construction)
    {
		// ...
    }

=======
>>>>>>> Julien
	public void Construire(string _batimentAConstruire)
    {
        new Batiment();
    }

	public void Reparer(Batiment _batimentAReparer)
    {
		// ...
    }

	public void Exploiter(RessourceNaturelle _ress)
    {
        // ...
    }
<<<<<<< HEAD
=======

    //j'ai ajouté
    public void Améliorer(Batiment unBatiment)
    {
        //à définir dans Unity
    }
>>>>>>> Julien
}