using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConstructionPossible : MonoBehaviour {

    public List<Collider> colliders = new List<Collider>();
    private bool estSelectionne;
    public GameObject quad;
    Renderer rendTest;
    public Material shader1;
    public Material shader2;
    // Use this for initialization
    void Start() {
 
        quad = transform.Find("Quad").gameObject;
        rendTest = quad.GetComponent<Renderer>();
        rendTest.enabled = true;       
    }
    private void OnGUI()
    {
        if (estSelectionne)
        {
            GUI.Button(new Rect(100, 200, 100, 30), name);
        }
    }
    private void OnTriggerEnter(Collider other)
    {

        if (other.tag == "Batiment")
        {
            rendTest.sharedMaterial = shader2;
            colliders.Add(other);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Batiment")
        {
            colliders.Remove(other);
            if (colliders.Count < 1)
            {
                rendTest.sharedMaterial = shader1;
            }
        }
    }
    public void definirSelection(bool s)
    {
        estSelectionne = s;
    }
}
