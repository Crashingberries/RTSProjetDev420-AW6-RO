using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;



public class Joueur : NetworkBehaviour
{
    public GameObject cameraJ1, cameraJ2;

    public int Num; //{ get; set; }
    public string Nom; //{ get; set; }
    public string Couleur;//{ get; set; }
    public bool Vaincu; //{ get; set; } // <- Si le joueur a perdu OU declare forfait
    public bool Vainqueur; //{ get; set; } // <- Si le joueur a gagne (il est le seul restant...)



    public Joueur()
    {
        Num = 0;
        Nom = "";
        Couleur = "blanc";
        Vaincu = false;
        Vainqueur = false;
    }

    public Joueur(int _num, string _nom)
    {
        Num = _num;
        Nom = _nom;
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
    /*
     *Fonctions qui permettent de gérer la mine
     * 
     * Ce premier bloc sert à la destruction de celle-ci une fois qu'elle est vide de ressources.
     */

    public void DetruireMine(GameObject m)
    {
        Debug.Log("Joueur::DetruireMine");

        CmdDetruireMine(m);
    }
    [Command]
    void CmdDetruireMine(GameObject m)
    {
        Debug.Log("Joueur::CmdDetruireMine");

        RpcDetruireMine(m);
        Destroy(m);
    }
    [ClientRpc]
    void RpcDetruireMine(GameObject m)
    {
        Debug.Log("Joueur::RpcDetruireMine");

        Destroy(m);
    }

    /*
     * Ce deuxième bloc gère l'update des ressources de la mine à travers le serveur. De cette façon, lorsque la valeur de la mine change, 
     * celle-ci est mise à jour sur le serveur.
     */
    public void UpdateMine(int valeur, GameObject m)
    {
        Debug.Log("Joueur::UpdateMine");
        CmdUpdateMine(valeur, m);
    }
    [Command]
    void CmdUpdateMine(int valeur, GameObject m)
    {
        Debug.Log("Joueur::CmdUpdateMine");
        m.GetComponent<Minerai>().Ressources = valeur;
        RpcUpdateMine(valeur, m);
    }
    [ClientRpc]
    void RpcUpdateMine(int valeur, GameObject m)
    {
        Debug.Log("Joueur::RpcUpdateMine");
        m.GetComponent<Minerai>().Ressources = valeur;
    }
}
