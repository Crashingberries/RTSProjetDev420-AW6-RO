namespace RTS
{
    public class Partie
    {
        public Joueur[] Joueurs;
        public static int MaxJoueurs = 8;
        public bool Termine { get; set; }

        public Partie()
        {
            /*Joueurs.Add(unJoueur = new Joueur());
            Termine = false;*/
        }

        public Partie(Joueur[] _joueurs)
        {
            Joueurs = _joueurs;
            Termine = false;
        }

        public bool AjouterJoueur(Joueur _joueur)
        {
            for (int i = 0; i < MaxJoueurs; i++)
            {
                if (Joueurs[i] == null)
                {
                    Joueurs[i] = _joueur;
                    return true;
                }
            }
            return false;
        }

        public void RetirerJoueur(int _num)
        {
            for (int i = 0; i < MaxJoueurs; i++)
            {
                if (Joueurs[i].Num == _num)
                {
                    Joueurs[i] = null;
                }
            }
        }
    }
}