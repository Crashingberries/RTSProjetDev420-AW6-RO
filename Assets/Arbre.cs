using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arbre : MonoBehaviour {

    GameObject thisArbre;
    public int vieArbre;
    private bool fini = false;
	// Use this for initialization
	void Start () {
        thisArbre = transform.parent.gameObject;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
