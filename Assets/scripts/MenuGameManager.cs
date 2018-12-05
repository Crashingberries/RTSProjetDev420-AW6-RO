using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class MenuGameManager : MonoBehaviour {

    public static MenuGameManager Instance { get; set; }
    public GameObject Menu,Creer,Rejoindre;

    public GameObject serveurPrefab, clientPrefab;
    public InputField NomClient;
	// Use this for initialization
	void Start () {
        DontDestroyOnLoad(gameObject);
        Instance = this;
        Creer.SetActive(false);
        Rejoindre.SetActive(false);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
    public void MenuCreerPartieBouton()
    {
        try
        {
            Serveur s = Instantiate(serveurPrefab).GetComponent<Serveur>();
            s.Init();

            Client c = Instantiate(clientPrefab).GetComponent<Client>();
            c.NomClient = "Hote";
            c.ConnectionServeur("127.0.0.1", 1234);
        }
        catch(Exception e)
        {
            Debug.Log(e.Message);
        }
        Menu.SetActive(false);
        Creer.SetActive(true);
    }
    public void AnnulerBouton()
    {
        Menu.SetActive(true);
        Creer.SetActive(false);
        Rejoindre.SetActive(false);
        Serveur s = FindObjectOfType<Serveur>();
        if (s != null) { Destroy(s.gameObject); }
        Client c = FindObjectOfType<Client>();
        if (c != null) { Destroy(c.gameObject); }
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
        try
        {
            Client c = Instantiate(clientPrefab).GetComponent<Client>();
            c.NomClient = NomClient.text;
            if (c.NomClient == "") { c.NomClient = "Joueur"; }
            c.ConnectionServeur(adresseHote,1234);
            Rejoindre.SetActive(false);
        }
        catch (Exception e)
        {
            Debug.Log(e.Message);
        }

    }
}
