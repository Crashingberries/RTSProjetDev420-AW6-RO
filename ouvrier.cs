public class Ouvrier : Unit
{
    public static Batiment[] BatimentsAConstruire;
	public bool EnConstruction { get; set; }
    public bool EnReparation { get; set; }
	public bool EnExploitation { get; set; }

    public Ouvrier(int PvM, int PaM, Position _pos, int _vitesse, bool _enDepl, Position _pointDepl, object _cible) : base(PvM, PaM, _pos, _vitesse, _enDepl, _pointDepl, _cible)
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
        EnConstruction = false;
        EnReparation = false;
    }

	public override void Attaquer(Construction _construction)
    {
		// ...
    }

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
}