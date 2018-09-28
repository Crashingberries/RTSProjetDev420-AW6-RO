namespace RTS
{
    public abstract class Batiment : Construction
    {
        public Position PointRalliement { get; set; }
        public int TempsConstruction { get; set; }

        public Batiment() : base()
        {
            PointRalliement = new Position();
            TempsConstruction = 0;
        }

        public Batiment(int unPV, int uneArmure, Position unePosition, string unNom, int unCoutOr, int unCoutBois, int unTempsConstruction) :
            base(unPV, uneArmure, unePosition, unNom, unCoutOr, unCoutBois)
        {
            TempsConstruction = unTempsConstruction;
            PointRalliement = new Position();
        }
    }
}