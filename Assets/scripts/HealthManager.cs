using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour {

    public static int PVcourant=0;
    public Slider PvBar;

    // Use this for initialization
    void Start ()
    {
       // PvBar = GetComponent<Slider>();
        //PVcourant = (int)PvBar.maxValue;
    }

    public void SubirDegats(int degats)
    {
        PVcourant = PVcourant - degats;
        PvBar.value = PVcourant;
    }

    // Update is called once per frame
    void Update () {
        //PvBar.value = PVcourant;
    }
}
