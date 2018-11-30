using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Minerai : MonoBehaviour {

    public int Ressources = 300;
    // Use this for initialization
    void Start() {

    }

    // Update is called once per frame
    void Update() {

    }
    public void Recolte()
    {
        if (Ressources>35)
        {
            Joueur.J1.AjouterOr(35);
            Ressources -= 35;
        }
        else
        {
            Joueur.J1.AjouterOr(Ressources);
            Ressources = 0;
            Destroy(gameObject);
        }
        
        
    }
}
