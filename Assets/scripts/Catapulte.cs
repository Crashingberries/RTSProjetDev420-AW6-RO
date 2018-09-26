public class Catapulte: Unité
{
    public Catapulte() : base()
    {

    }

    public Catapulte(int unPv, int uneArmure, Position unePosition, string unNom, int unCoutOr, int unCoutBois, int uneVitesseDeplacement, int unePuissanceAttaque, int unePortéeMin, int unePortéeMax, int unePuissanceAttaque, int uneVitesseAttaque) : 
        base(unPv, uneArmure, unePosition, unNom, unCoutOr, unCoutBois, uneVitesseDeplacement, unePuissanceAttaque, unePortéeMin, unePortéeMax, unePuissanceAttaque, uneVitesseAttaque)
    {

    }

    public void Attaquer(Construction cible)
    {

    }
}