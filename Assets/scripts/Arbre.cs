using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arbre : MonoBehaviour {

    public int valeurMax = 100;
    private int ressources;

    // Use this for initialization
    private void Start()
    {
        ressources = valeurMax;
    }

    public void Recolte(int valeur)
    {
        ressources -= valeur;
    }
    public int GetRessources()
    {
        return ressources;
    }
}
       