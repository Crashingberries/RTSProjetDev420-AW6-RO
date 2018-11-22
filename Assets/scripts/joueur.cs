using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



    public class Joueur
    {
    public static Joueur J1 = new Joueur(1, "Joueur 1");
    public static Joueur J2 = new Joueur(2, "Joueur 2");
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
        Ress_bois = 0;
        Ress_or = 0;
        Ress_mana = 0;
        Ress_population = 0;
        Vaincu = false;
        Vainqueur = false;
    }

    public Joueur(int _num, string _nom)
    {
        Num = _num;
        Nom = _nom;
        Ress_bois = 150;
        Ress_or = 200;
        Ress_mana = 0;
        Ress_population = 20;
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
    public bool RetirerBois(int nbr)
    {
        if (Ress_bois >= nbr)
        {
            Ress_bois -= nbr;
            return true;
        }
        return Ress_bois >= nbr;
    }
    public bool RetirerOr(int nbr)
    {
        if(Ress_or >= nbr)
        {
            Ress_or -= nbr;
            return true;
        }
        return Ress_or >= nbr;
    }
    public bool RetirerMana(int nbr)
    {
        if(Ress_mana >= nbr)
        {
            Ress_mana -= nbr;
            return true;
        }
        return Ress_mana >= nbr;
    }
    public bool RetirerPopulation(int nbr)
    {
        if(Ress_population >= nbr)
        {
            Ress_population -= nbr;
            return true;
        }
        return Ress_population >= nbr;
    }

    //===========================================
    // Actions joueur
    //===========================================
    public void Abandonner()
    {
        Vaincu = true;
    }

    public override string ToString()
    {
        return "J" + Num + " : " + Nom + " [bois_" + Ress_bois + ", or_" + Ress_or + ", pop_" + Ress_population + "]";
    }
    //private void Start()
    //{
    //    J1 = new Joueur(1,"Joueur 1");
    //    J2 = new Joueur(2,"Joueur 2");
    //    //print("JOUEUR START");
    //}
    //private void Update()
    //{
    //}
}
