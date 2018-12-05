using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class FenetreRessource : NetworkBehaviour {

	private void Update()
    {
        transform.Find("MontantOr").GetComponent<Text>().text = "Or: " + NetworkManager.singleton.playerPrefab.GetComponent<Joueur>().GetComponentInChildren<Joueur>().Ress_or;
        transform.Find("MontantBois").GetComponent<Text>().text = "Bois: " + NetworkManager.singleton.playerPrefab.GetComponent<Joueur>().GetComponentInChildren<Joueur>().Ress_bois;
        transform.Find("MontantPop").GetComponent<Text>().text = "Population: " + NetworkManager.singleton.playerPrefab.GetComponent<Joueur>().GetComponentInChildren<Joueur>().Ress_population+"/200";
    }
}
