using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConstructionPossible : MonoBehaviour {

    public List<Collider> colliders = new List<Collider>();
    private bool estSelectionne;
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
        if (other.tag == "Batiment"|| other.tag == "MineOr"|| other.tag == "Friendly"|| other.tag == "Ennemi")
        {
            colliders.Add(other);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Batiment"|| other.tag == "MineOr"|| other.tag == "Friendly"|| other.tag == "Ennemi")
        {
            colliders.Remove(other);
        }
    }
    public void definirSelection(bool s)
    {
        estSelectionne = s;
    }
}
