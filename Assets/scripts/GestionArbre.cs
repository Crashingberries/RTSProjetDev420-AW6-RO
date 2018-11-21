using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GestionArbre : MonoBehaviour
{
    GameObject ArbreTmp;
    Arbre ArbreTmpo;


    // Update is called once per frame
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit, 500000))
            {
                if (hit.collider.name.Contains("Arbre"))
                {
                    ArbreTmp = hit.collider.gameObject;
                    ArbreTmpo = ArbreTmp.GetComponent<Arbre>();
                    print(ArbreTmpo.GetRessources());
                    if (ArbreTmpo.GetRessources() != 0)
                    {
                        ArbreTmpo.Recolte(10);
                    }
                    else
                    {
                        Destroy(ArbreTmp);
                    }
                }
            }
        }
    }
}
