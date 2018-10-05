using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConstructionPossible : MonoBehaviour {

    public List<Collider> colliders = new List<Collider>();
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Batiment")
        {
            colliders.Add(other);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Batiment")
        {
            colliders.Remove(other);
        }
    }
}
