using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;



    public class Joueur:NetworkBehaviour
    {
    public GameObject cameraJ1;
    public GameObject cameraJ2;
    public int Num; //{ get; set; }
    public string Nom; //{ get; set; }
    public string Couleur;//{ get; set; }
    public int Ress_bois;//{ get; set; }
    public int Ress_or;//{ get; set; }
    public int Ress_mana; //{ get; set; }
    public int Ress_population; //{ get; set; }
    public bool Vaincu; //{ get; set; } // <- Si le joueur a perdu OU declare forfait
    public bool Vainqueur; //{ get; set; } // <- Si le joueur a gagne (il est le seul restant...)

    

        public Joueur()
        {
            Num = 0;
            Nom = "";
            Couleur = "blanc";
            Ress_bois = 500;
            Ress_or = 500;
            Ress_mana = 0;
            Ress_population = 0;
            Vaincu = false;
            Vainqueur = false;
        }

        public Joueur(int _num, string _nom)
        {
            Num = _num;
            Nom = _nom;
            Ress_bois = 100;
            Ress_or = 100;
            Ress_mana = 0;
            Ress_population = 10;
            Vaincu = false;
            Vainqueur = false;
            switch (Num)
            {
                case 1:
                    Couleur = "Rouge";
                    break;
                case 2:
                    Couleur = "Bleu";
                    break;
                case 3:
                    Couleur = "Vert";
                    break;
                case 4:
                    Couleur = "Bleu clair";
                    break;
                case 5:
                    Couleur = "Jaune";
                    break;
                case 6:
                    Couleur = "Mauve";
                    break;
                case 7:
                    Couleur = "Orange";
                    break;
                case 8:
                    Couleur = "Brun";
                    break;
            }
        }


        //===========================================
        // Methodes d'ajout de ressources
        //===========================================
        public void AjouterBois(int nbr)
        {
            Ress_bois += nbr;
        }
        public void AjouterOr(int nbr)
        {
            Ress_or += nbr;
        }
        public void AjouterMana(int nbr)
        {
            Ress_mana += nbr;
        }
        public void AjouterPopulation(int nbr)
        {
            Ress_population += nbr;
        }


        //===========================================
        // Methodes de retrait de ressources
        //===========================================
        public void RetirerBois(int nbr)
        {
            Ress_bois -= nbr;
        }
        public void RetirerOr(int nbr)
        {
            Ress_or -= nbr;
        }
        public void RetirerMana(int nbr)
        {
            Ress_mana -= nbr;
        }
        public void RetirerPopulation(int nbr)
        {
            Ress_population -= nbr;
        }

        //===========================================
        // Actions joueur
        //===========================================
        public void Abandonner()
        {
            Vaincu = true;
        }
    private void Start()
    {
        if (isServer)
        {
            Instantiate(cameraJ1);
        }
        else
        {
            Instantiate(cameraJ2);
        }
    }
}
