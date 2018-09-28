//j'ai renommé la classe Unit en Unite
public abstract class Unité : Construction
{
    public int VitesseDeplacement { get; set; }//renomme Vitesse en VitesseDeplacement
    public bool EnDeplacement { get; set; }
    public bool EnAttaque { get; set; }
    public Position PointDeplacement { get; set; } // <- La position ou l'unite est en train de se deplacer
    public object Cible { get; set; } // <- Batiment à attaquer, ressource naturelle à exploiter...
    public int PorteeMin { get; set; }
    public int PorteeMax { get; set; }
    public int PuissanceAttaque { get; set; }//renomme en PuissanceAttaque
    //j'ai ajoute
    public int VitesseAttaque { get; set; }

    //j'ai ajoute
    public Unité(): base()
    {
        VitesseDeplacement = 0;
        PuissanceAttaque = 0;
        VitesseAttaque = 0;
        PorteeMin = 0;
        PorteeMax = 0;
        Cible = new Construction();
        PointDeplacement = new Position();
        EnDeplacement = false;
        EnAttaque = false;
    }

    //j'ai ajoute
    public Unite(int unPv, int uneArmure, Position unePosition, string unNom, int unCoutOr, int unCoutBois, 
        int uneVitesseDeplacement, int unePuissanceAttaque, int unePorteeMin, int unePorteeMax, int unePuissanceAttaque, int uneVitesseAttaque) : 
        base(unPv, uneArmure, unePosition, unNom, unCoutOr, unCoutBois)
    {
        VitesseDeplacement = uneVitesseDeplacement;
        EnDeplacement = false;
        EnAttaque = false;
        PointDeplacement = null;
        PorteeMin = unePorteeMin;
        PortéeMax = unePorteeMax;
        PuissanceAttaque = unePuissanceAttaque;
        VitesseAttaque = uneVitesseAttaque;
    }

    public Unite(int PvM, int PaM, Position _pos) : base(PvM, PaM, _pos)
    {
        PV = PvM; PvMax = PvM;
        Armure = PaM; ArmureMax = PaM;
        Pos = new Position();
        Vitesse = 100;
        EnDeplacement = false;
        EnAttaque = false;
        PointDeplacement = null;
        Cible = null;
        PorteeMax = 0; // nombres Non significatifs... 
        PorteeMin = 0; //
        Attaque = 1;   //
    }

    public Unite(int PvM, int PaM, Position _pos, int _vitesse, bool _enDepl, Position _pointDepl, object _cible, int _attaque) : base(PvM, PaM, _pos)
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
        Attaque = _attaque;
    }

    public void Deplacer(Position _pos)
    {
        PointDeplacement = _pos;
        EnDeplacement = true;
    }

    public void Attaquer(ref Construction _construction)
    {
        _construction.SubirDegats(Attaque);
    }

}