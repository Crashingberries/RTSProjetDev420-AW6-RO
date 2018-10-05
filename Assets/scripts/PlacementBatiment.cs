using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlacementBatiment : MonoBehaviour {

    private Transform batimentActuel;
    Camera cam;
    private bool EstPlace;
    // Use this for initialization
    void Start () {
       cam = GetComponent<Camera>();
    }
	
	// Update is called once per frame
	void Update () {
		if (batimentActuel != null && !EstPlace)
        {
            Vector3 m = Input.mousePosition;
            m = new Vector3(m.x,m.y,transform.position.y);
            Vector3 p = cam.ScreenToWorldPoint(m);
            batimentActuel.position = new Vector3(p.x, 0, p.z);

            if (Input.GetMouseButtonDown(0)) {
                if (EstLegal())
                {
                    EstPlace = true;
                }
                
            }
        }
	}

    public void ChoisirBatiment(GameObject b)
    {
        EstPlace = false;
        batimentActuel = ((GameObject)Instantiate(b)).transform;
    }
    bool EstLegal()
    {
        return true;
    }
}
