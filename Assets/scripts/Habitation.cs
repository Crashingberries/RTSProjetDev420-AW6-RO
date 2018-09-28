public class Habitation: Batiment
{
    public Habitation():base()
    {

    }

    public Habitation(int unPV, int uneArmure, Position unePosition, string unNom, int unCoutOr, int unCoutBois, int unTempsConstruction) :
        base(unPV, uneArmure, unePosition, unNom, unCoutOr, unCoutBois, unTempsConstruction)
    {

    }
}