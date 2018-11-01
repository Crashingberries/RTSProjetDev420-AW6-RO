using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionsBatiment : MonoBehaviour {
    
    public Transform t_batiment;
    public Vector3 ptdr;
    public GameObject PointDeRaliement;
    public bool tmpBool;
   // private GameObject raliement2; // COPIE de raliement

	// Use this for initialization
	void Start () {
        t_batiment = GetComponent<Transform>();
        ptdr = new Vector3(t_batiment.position.x + 10, t_batiment.position.y, t_batiment.position.z);
        //print("ptdr " + ptdr);
    }
	
	// Update is called once per frame
	void Update () {
        if (PointDeRaliement.activeSelf && tmpBool)
        {
            PointDeRaliement.transform.position = GetMousePosition();
            if (Input.GetMouseButtonDown(0))
            {
                tmpBool = false;
              //  PointDeRaliement.SetActive(false);
            }
        }
	}

    public void PlacerPTDR()
    {
        tmpBool = true;
        PointDeRaliement.SetActive(true);
            //print("ptdr " + ptdr + " TRUE");
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
        Vector3 pos = PointDeRaliement.transform.position;
        GameObject f = Instantiate(unit, pos, new Quaternion(0f,180f,0f,0f));
       // f.SendMessage("SetRaliementCible", ptdr);
    }
}
