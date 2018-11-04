using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MessagesToPlayer : MonoBehaviour {
    static GameObject msg;
    static float debut; // debut du timer du message (pas important)

    public static int TEMPS_MSG = 3; // En secondes

	// Use this for initialization
	void Start () {
        msg = GameObject.Find("MsgErr_NoRessource");
        msg.SetActive(false);
    }
	
	// Update is called once per frame
	void Update () {
        if (msg.activeSelf)
        {
            if (Time.time - debut > TEMPS_MSG)
            {
                msg.SetActive(false);
            }
        }
    }

    public static void PasAssezRessources(bool bois, bool or, bool pop)
    {
        if(!(bois && or && pop))
        {
            msg.GetComponentInChildren<Text>().text = "Vous n'avez pas assez ";
            msg.GetComponentInChildren<Text>().text += (bois) ? "" : "de bois! ";
            msg.GetComponentInChildren<Text>().text += (or) ? "" : "d'or! ";
            msg.GetComponentInChildren<Text>().text += (pop) ? "" : "de population!";
            msg.SetActive(true);
            debut = Time.time;
        }
    }

}
