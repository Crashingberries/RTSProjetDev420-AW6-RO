using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConstructionPossible : MonoBehaviour {

    public List<Collider> colliders = new List<Collider>();
    private bool estSelectionne;
    Material colorquad;
    // Use this for initialization
    void Start() {
        
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
        GameObject quad = GameObject.Find("Quad");
        if (other.tag != "Terrain")
        {
            quad.GetComponent<Material>();
            colliders.Add(other);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag != "Terrain")
        {
            Material couleurQuad = GetComponentInChildren<Material>();
            couleurQuad.color = Color.red;
            colliders.Remove(other);
        }
    }
    public void definirSelection(bool s)
    {
        estSelectionne = s;
    }
}
