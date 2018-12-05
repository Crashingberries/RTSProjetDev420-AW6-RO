using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Minerai : NetworkBehaviour {

    public int Ressources = 300;
    // Use this for initialization
    void Start() {

    }

    // Update is called once per frame
    void Update() {
        if (Input.GetKey(KeyCode.Q))
        {
            Recolte();
        }
    }
    public void Recolte()
    {
        if (Ressources > 35)
        {
            NetworkManager.singleton.playerPrefab.GetComponent<Joueur>().GetComponentInChildren<Joueur>().AjouterOr(35);            
            CmdUpdateMine(35);
        }
        else
        {

            NetworkManager.singleton.playerPrefab.GetComponent<Joueur>().GetComponentInChildren<Joueur>().AjouterOr(Ressources);
            CmdUpdateMine(0);
            CmdDestroyMine();
        }


    }
    [Command]
    void CmdDestroyMine()
    {
        Destroy(gameObject);
    }

    [Command]
    void CmdUpdateMine(int valeur)
    {
        Ressources -= valeur;
    }
}
