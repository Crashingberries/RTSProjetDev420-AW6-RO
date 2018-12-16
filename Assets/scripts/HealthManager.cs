using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour {

    public static int PVcourant;
    public Slider PvBar;
    public GameObject construction;

    // Use this for initialization
    void Start ()
    {
        construction=gameObject.transform.parent.parent.gameObject;
        PVcourant = (int)PvBar.maxValue;
    }

    public void SubirDegats(int degats)
    {
        PVcourant = PVcourant - degats;
        PvBar.value = PVcourant;
    }

    // Update is called once per frame
    void Update () {
        Debug.Log("HealthManager::Update ==> Nom du gameobject Parent:"+construction.name);
        GetComponentInChildren<Text>().text = PvBar.value + "/" + PvBar.maxValue;
        Vector3 pos = construction.transform.position;
        PvBar.transform.position = Camera.main.WorldToScreenPoint(new Vector3(pos.x+3, pos.y, pos.z+8));
    }
}
