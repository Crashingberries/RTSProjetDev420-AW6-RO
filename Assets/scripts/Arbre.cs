using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Arbre : NetworkBehaviour
{

    public int Ressources = 100;
    // Use this for initialization

    public void Recolte(int ress)
    {
        Joueur j = GameObject.FindObjectOfType<Joueur>();
        FenetreRessource jRess = GameObject.FindObjectOfType<FenetreRessource>();
        Debug.Log("Arbre::Recolte --- Execution");
        if (ress > 35)
        {

            jRess.AjouterBois(35);
            Ressources -= 35;
            j.UpdateRessource(Ressources, gameObject.GetComponent<NetworkIdentity>());
        }
        else
        {
            Debug.Log("Minerai::Recolte ==> Phase de destruction");
            jRess.AjouterOr(Ressources);
            j.DetruireRessource(gameObject.GetComponent<NetworkIdentity>());

        }


    }
}
       