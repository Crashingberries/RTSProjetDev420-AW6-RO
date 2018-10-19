using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlacementBatiment : MonoBehaviour {

    private ConstructionPossible constructionPossible;
    private Transform batimentActuel;
    Camera cam;
    private bool EstPlace;
    public LayerMask coucheBatiment;
    Vector3 vecteurDefini;
    // Use this for initialization
    void Start() {
        cam = GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update() {
        RaycastHit hit;
        Ray ray = new Ray(transform.position, transform.forward);
        if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit) && EstPlace == false)
        {
            
            vecteurDefini.Set(hit.point.x, hit.collider.transform.position.y, hit.point.z);
            batimentActuel.transform.position = vecteurDefini;
        }
        if (Input.GetMouseButtonDown(0)) {
            if (EstLegal())
            {
                EstPlace = true;
            }
        }
    }   

    bool EstLegal()
    {
        constructionPossible = batimentActuel.GetComponent<ConstructionPossible>();
        if (constructionPossible.colliders.Count > 0)
        {
            print("pas legal");
            
            return false;
        }
        print("legal");
        return true;

    }
    public void ChoisirBatiment(GameObject b)
    {
        EstPlace = false;
        batimentActuel = ((GameObject)Instantiate(b)).transform;
    }
    
}
