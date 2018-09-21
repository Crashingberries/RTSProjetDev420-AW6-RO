//j'ai renomm� la classe Unit en Unit�
public abstract class Unit� : Construction
{
    public int VitesseD�placement { get; set; }//renomm� Vitesse en VitesseD�placement
    public bool EnDeplacement { get; set; }
    public bool EnAttaque { get; set; }
    public Position PointDeplacement { get; set; } // <- La position ou l'unit� est en train de se d�placer
    public object Cible { get; set; } // <- Batiment � attaquer, ressource naturelle � exploiter...
    public int PorteeMin { get; set; }
    public int PorteeMax { get; set; }
    public int PuissanceAttaque { get; set; }//renomm� en PuissanceAttaque
    //j'ai ajout�
    public int VitesseAttaque { get; set; }

    //j'ai ajout�
    public Unit�(): base()
    {
        VitesseD�placement = 0;
        PuissanceAttaque = 0;
        VitesseAttaque = 0;
        PorteeMin = 0;
        PorteeMax = 0;
        Cible = new Construction();
        PointDeplacement = new Position();
        EnDeplacement = false;
        EnAttaque = false;
    }

    //j'ai ajout�
    public Unit�(int unPv, int uneArmure, Position unePosition, string unNom, int unCoutOr, int unCoutBois, 
        int uneVitesseDeplacement, int unePuissanceAttaque, int unePort�eMin, int unePort�eMax, int unePuissanceAttaque, int uneVitesseAttaque) : 
        base(unPv, uneArmure, unePosition, unNom, unCoutOr, unCoutBois)
    {
        VitesseD�placement = uneVitesseDeplacement;
        EnDeplacement = false;
        EnAttaque = false;
        PointDeplacement = null;
        PorteeMin = unePort�eMin;
        Port�eMax = unePort�eMax;
        PuissanceAttaque = unePuissanceAttaque;
        VitesseAttaque = uneVitesseAttaque;
    }

    public Unit�(int PvM, int PaM, Position _pos) : base(PvM, PaM, _pos)
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

    public Unit�(int PvM, int PaM, Position _pos, int _vitesse, bool _enDepl, Position _pointDepl, object _cible, int _attaque) : base(PvM, PaM, _pos)
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