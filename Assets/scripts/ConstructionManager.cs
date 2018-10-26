using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ConstructionManager : MonoBehaviour {
    
    public HealthManager[] all_barresVie;
    public Text[] all_textBarresVie;
    public BoxCollider _collider;
    

    // Use this for initialization
    void Start () {
        all_barresVie = GameObject.FindObjectsOfType<HealthManager>();
        all_textBarresVie = new Text[all_barresVie.Length];
        for (int i=0; i< all_barresVie.Length; i++)
        {
            all_textBarresVie[i] = all_barresVie[i].GetComponentInChildren<Text>();
        }
        //_se_degats = GetComponent<AudioSource>();
        //_se_detruit = GetComponent<AudioSource>();
        BoxCollider _self = GetComponent<BoxCollider>();
        print(""+_self.name);
        if (_self == null)
        {
            print("Collider : NULL");
        }
	}
	
	// Update is called once per frame
	void Update ()
    {
        for(int i=0; i < all_textBarresVie.Length; i++)
        {
            all_textBarresVie[i].text = all_barresVie[i].PvBar.value + "/" + all_barresVie[i].PvBar.maxValue + " PV";
        }


        //print("Destruit");
        //_pvText.text = _healthManager.PvBar.value + "/" + _healthManager.PvBar.maxValue + " PV";

        //if(_healthManager.PvBar.value == 0 && r_ennemi.position.y >= -50)
        //{
        //    print("Destruit");
        //    r_ennemi.MovePosition(new Vector3(r_ennemi.position.x, r_ennemi.position.y - (float)0.8, r_ennemi.position.z));
        //}
        //else if(_healthManager.PvBar.value == 0)
        //{
        //    if (GameObject.Find("Slider") != null)
        //    {
        //        Destroy(GameObject.Find("Ennemi"));
        //    }
        //}
    }

    
}
