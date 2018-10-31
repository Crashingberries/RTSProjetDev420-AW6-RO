using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionsBatiment : MonoBehaviour {
    
    public Transform t_batiment;
    public Vector3 ptdr;
    public GameObject raliement;
    private GameObject raliement2; // COPIE de raliement

    private bool placer_ptdr;

	// Use this for initialization
	void Start () {
        t_batiment = GetComponent<Transform>();
        ptdr = new Vector3(t_batiment.position.x + 10, t_batiment.position.y, t_batiment.position.z);
        //print("ptdr " + ptdr);
    }
	
	// Update is called once per frame
	void Update () {
        if (placer_ptdr)
        {
            raliement2.transform.position = GetMousePosition();
            if (Input.GetMouseButtonDown(0))
            {
                ptdr = GetMousePosition();
                placer_ptdr = false;
                Destroy(raliement2);
            }
        }
	}

    public void PlacerPTDR()
    {
        if (!placer_ptdr)
        {
            //print("ptdr " + ptdr + " TRUE");
            placer_ptdr = true;
            raliement2 = Instantiate(raliement, GetMousePosition(), new Quaternion());
        }
        else
        {
            //print("ptdr " + ptdr + " FALSE");
            placer_ptdr = false;
            Destroy(raliement2);
        }
    }

    private Vector3 GetMousePosition()
    {
        Vector3 pos = new Vector3();
        Plane plane = new Plane(Vector3.up, transform.position);
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        float point = 0f;
        if (plane.Raycast(ray, out point))
        {
            pos = ray.GetPoint(point);
        }
        return pos;
    }

    public void CreerUnit(GameObject unit)
    {
        Vector3 pos = new Vector3(t_batiment.position.x+10, t_batiment.position.y, t_batiment.position.z);
        GameObject f = Instantiate(unit, pos, t_batiment.rotation);
        f.SendMessage("SetRaliementCible", ptdr);
    }
}
