using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaserneAction : MonoBehaviour {

    public GameObject HUD;
    // Use this for initialization
    void Start() {
        if (GameObject.Find(HUD.name) == null) {GameObject tmp =Instantiate(HUD); tmp.name = HUD.name; tmp.transform.parent= GameObject.Find("Canvas").transform; }
        else { Debug.Log(HUD.activeSelf); }
        
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
