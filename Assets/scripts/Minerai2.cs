using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Minerai2 : NetworkBehaviour 
{
    public int Ressources = 300;

    public void Update()
    {
        if (Input.GetKey(KeyCode.Q))
        {
            Debug.Log("Je reçois la touche Q.");
            Debug.Log("Ai-je le droit de modifier les mines?: " + hasAuthority + "J'ai tu ça au moins? " + localPlayerAuthority);
            

        }
    }
}
