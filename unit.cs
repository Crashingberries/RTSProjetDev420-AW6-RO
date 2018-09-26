<<<<<<< HEAD
public abstract class Unit : Construction
{
    public int Vitesse { get; set; }
    public bool EnDeplacement { get; set; }
    public bool EnAttaque { get; set; }
    public Position PointDeplacement { get; set; } // <- La position ou l'unité est en train de se déplacer
    public object Cible { get; set; } // <- Batiment à attaquer, ressource naturelle à exploiter...
    public int PorteeMin { get; set; }
    public int PorteeMax { get; set; }

    public Unit(int PvM, int PaM, Position _pos) : base(PvM, PaM, _pos)
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
    }

    public Unit(int PvM, int PaM, Position _pos, int _vitesse, bool _enDepl, Position _pointDepl, object _cible) : base(PvM, PaM, _pos)
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
    }

    public void Deplacer(Position _pos)
    {
        PointDeplacement = _pos;
        EnDeplacement = true;
    }

    public abstract void Attaquer(Construction _construction);
=======
public abstract class Unit : Construction
{
    public int Vitesse { get; set; }
    public bool EnDeplacement { get; set; }
    public bool EnAttaque { get; set; }
    public Position PointDeplacement { get; set; } // <- La position ou l'unité est en train de se déplacer
    public object Cible { get; set; } // <- Batiment à attaquer, ressource naturelle à exploiter...
    public int PorteeMin { get; set; }
    public int PorteeMax { get; set; }
    public int Attaque { get; set; }

    public Unit(int PvM, int PaM, Position _pos) : base(PvM, PaM, _pos)
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

    public Unit(int PvM, int PaM, Position _pos, int _vitesse, bool _enDepl, Position _pointDepl, object _cible, int _attaque) : base(PvM, PaM, _pos)
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

>>>>>>> Cesar
}