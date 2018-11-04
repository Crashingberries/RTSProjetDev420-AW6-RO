using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionsBatiment : MonoBehaviour {

    public Transform t_batiment;
    public Vector3 ptdr;
    public GameObject PointDeRaliement;
    private bool tmpBool, enCreationUnite;
    public GameObject UniteCree;
    private float vitesse;
    // private GameObject raliement2; // COPIE de raliement

    // Use this for initialization
    void Start() {
        vitesse = 10 * Time.deltaTime;
        t_batiment = GetComponent<Transform>();
        ptdr = new Vector3(t_batiment.position.x + 15, t_batiment.position.y, t_batiment.position.z);

    }

    // Update is called once per frame
    void Update() {
        if (PointDeRaliement.activeSelf && tmpBool)
        {
            PointDeRaliement.transform.position = GetMousePosition();
            if (Input.GetMouseButtonDown(0))
            {
                tmpBool = false;
                //  PointDeRaliement.SetActive(false);
            }
        }
        if (enCreationUnite)
        {
            UniteCree.transform.position = Vector3.MoveTowards(UniteCree.transform.position, PointDeRaliement.transform.position, vitesse);
            if (UniteCree.transform.position == PointDeRaliement.transform.position){ enCreationUnite = false; }
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
        UniteCree = Instantiate(unit, ptdr, new Quaternion(0f, 180f, 0f, 0f));
        // f.SendMessage("SetRaliementCible", ptdr);
        enCreationUnite = true;
    }
    /*public void DeplacementTest(Vector3 unite, Vector3 raliement)
    {
        print("DeplacementTest");
        float vitesse = 10 * Time.deltaTime;
        while (unite!=raliement)
        {
            print(unite);
            unite = Vector3.MoveTowards(unite,raliement,vitesse);
        }
        enCreationUnite = false;
    }*/
}
