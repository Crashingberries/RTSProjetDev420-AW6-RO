using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlacementBatiment : MonoBehaviour {

    private ConstructionPossible constructionPossible;
    private Transform batimentActuel;
    Camera cam;
    private bool EstPlace;
    public LayerMask coucheBatiment;
    // Use this for initialization
    void Start() {
        cam = GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update() {
        Vector3 m = Input.mousePosition;
        m = new Vector3(m.x, m.y, transform.position.y);
        Vector3 p = cam.ScreenToWorldPoint(m);
        if (batimentActuel != null && !EstPlace)
        {
            batimentActuel.position = new Vector3(p.x, p.y, p.z);
            if (Input.GetMouseButtonDown(0)) {
                if (EstLegal())
                {
                    EstPlace = true;
                }
            }
        }
        /*  else
          {
              if (Input.GetMouseButtonDown(0))
              {
                  RaycastHit hit = new RaycastHit();
                  Ray ray = new Ray(new Vector3(p.x, 100, p.z), Vector3.down);
                  if (Physics.Raycast(ray, out hit, Mathf.Infinity, coucheBatiment)) {
                      hit.collider.gameObject.GetComponent<ConstructionPossible>().definirSelection(true);
                  }
              }
          }*/
    }

    bool EstLegal()
    {
        constructionPossible = batimentActuel.GetComponent<ConstructionPossible>();
        if (constructionPossible.colliders.Count > 0)
        {
            return false;
        }
        return true;

    }
    public void ChoisirBatiment(GameObject b)
    {
        EstPlace = false;
        batimentActuel = ((GameObject)Instantiate(b)).transform;
    }
    
}
