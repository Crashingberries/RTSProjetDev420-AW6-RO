using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class FenetreRessource : MonoBehaviour {

    private void Awake()
    {
        RessourceDuJeu.MontantOrChangement += delegate (object sender, EventArgs e)
        {
            UpdateRessourceText();
        };
        UpdateRessourceText();
    }

	private void UpdateRessourceText()
    {
        transform.Find("MontantOr").GetComponent<Text>().text = "Or: " + RessourceDuJeu.GetMontantOr();
        transform.Find("MontantBois").GetComponent<Text>().text = "Bois: " + RessourceDuJeu.GetMontantBois();
        transform.Find("MontantPop").GetComponent<Text>().text = "Population: " + RessourceDuJeu.GetMontantPop()+"/200";
    }
}
