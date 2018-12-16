using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hud_Manager : MonoBehaviour {
    Canvas currentCav;

    // Use this for initialization
    void Start() {

    }
    public void CanvasActif(GameObject cav=null)
    {
        if (currentCav != null) { currentCav.gameObject.SetActive(false); }
        currentCav = cav.GetComponent<Canvas>();
        currentCav.gameObject.SetActive(true);
    }
    public void ResetCanvas()
    {
        if (currentCav != null) { currentCav.gameObject.SetActive(false); }
        currentCav = null;
    }
}
