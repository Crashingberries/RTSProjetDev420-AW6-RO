namespace RTS
{
    public class Catapulte : Unite
    {
        public Catapulte() : base()
        {

        }

        public Catapulte(int unPv, int uneArmure, Position unePosition, string unNom, int unCoutOr, int unCoutBois, int uneVitesseDeplacement, int unePuissanceAttaque, int unePorteeMin, int unePorteeMax, int uneVitesseAttaque) :
            base(unPv, uneArmure, unePosition, unNom, unCoutOr, unCoutBois, uneVitesseDeplacement, unePuissanceAttaque, unePorteeMin, unePorteeMax, uneVitesseAttaque)
        {

        }

        public void Attaquer(Construction cible)
        {

        }
    }
}