using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Joueur : MonoBehaviour {

    public int Num { get; set; }
    public string Nom { get; set; }
    public string Couleur { get; set; }
    public int Ress_bois { get; set; }
    public int Ress_or { get; set; }
    public int Ress_pierre { get; set; }
    public int Ress_mana { get; set; }
    public int Ress_population { get; set; }
    public bool Vaincu { get; set; } // <- Si le joueur a perdu OU declare forfait
    public bool Vainqueur { get; set; } // <- Si le joueur a gagne (il est le seul restant...)

    public Joueur()
    {
        Num = 0;
        Nom = "";
        Couleur = "blanc";
        Ress_bois = 0;
        Ress_or = 0;
        Ress_pierre = 0;
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
        Ress_or = 50;
        Ress_pierre = 150;
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
    public void AjouterPierre(int nbr)
    {
        Ress_pierre += nbr;
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
        if (nbr > Ress_bois)
        {
            return false;
        }
        Ress_bois -= nbr;
        return true;
    }
    public bool RetirerOr(int nbr)
    {
        if (nbr > Ress_or)
        {
            return false;
        }
        Ress_or -= nbr;
        return true;
    }
    public bool RetirerPierre(int nbr)
    {
        if (nbr > Ress_pierre)
        {
            return false;
        }
        Ress_pierre -= nbr;
        return true;
    }
    public bool RetirerMana(int nbr)
    {
        if (nbr > Ress_mana)
        {
            return false;
        }
        Ress_mana -= nbr;
        return true;
    }
    public bool RetirerPopulation(int nbr)
    {
        if (nbr > Ress_population)
        {
            return false;
        }
        Ress_population -= nbr;
        return true;
    }
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
