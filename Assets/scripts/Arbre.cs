using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arbre : MonoBehaviour
{

    public int ressources = 100;
    // Use this for initialization
    private void Start()
    {
    }

    public void Recolte()
    {
        if (ressources > 35)
        {
            //Joueur.J1.AjouterBois(35);
            ressources -= 35;
        }
        else
        {
            //Joueur.J1.AjouterBois(ressources);
            ressources = 0;
            Destroy(gameObject);
        }
    }
}
       