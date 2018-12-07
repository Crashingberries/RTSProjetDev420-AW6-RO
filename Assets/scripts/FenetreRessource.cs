using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FenetreRessource : MonoBehaviour {

    public int Ress_bois=500, Ress_or=500, Ress_mana=0, Ress_population=10;
    private void Update()
    {
        transform.Find("MontantOr").GetComponent<Text>().text = "Or: " + Ress_or;
        transform.Find("MontantBois").GetComponent<Text>().text = "Bois: " + Ress_bois;
        transform.Find("MontantPop").GetComponent<Text>().text = "Population: " + Ress_population+"/200";
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
}
