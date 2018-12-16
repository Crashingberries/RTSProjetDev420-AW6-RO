using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class MenuGameManager : NetworkBehaviour {

    public GameObject Menu,Creer,Rejoindre;

    public InputField NomClient;
	// Use this for initialization
	void Start () {
        Creer.SetActive(false);
        Rejoindre.SetActive(false);
    }

    public void MenuCreerPartieBouton()
    {
        NetworkManager.singleton.networkPort = 7777;
        NetworkManager.singleton.StartHost();
        Menu.SetActive(false);
        //Creer.SetActive(true);
    }
    public void AnnulerBouton()
    {
        Menu.SetActive(true);
        Creer.SetActive(false);
        Rejoindre.SetActive(false);
    }
    public void MenuRejoindrePartieBouton()
    {
        Menu.SetActive(false);
        Rejoindre.SetActive(true);
    }
    public void ConnectionBouton()
    {
        string adresseHote = GameObject.Find("AdresseHoteInput").GetComponent<InputField>().text;
        if (adresseHote == "")
        {
            adresseHote = "127.0.0.1";
        }
        NetworkManager.singleton.networkAddress = adresseHote;
        
    }
}
