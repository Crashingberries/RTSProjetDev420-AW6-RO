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
                GameObject test = batimentActuel.transform.Find("Quad").gameObject;
                if (test.activeSelf)
                {
                    test.SetActive(false);
                    RessourceDuJeu.SetMontantBois(-10);
                    RessourceDuJeu.SetMontantOr(-10);
                    batimentActuel.GetComponent<Collider>().isTrigger = false;
                    StartCoroutine(EnConstruction(batimentActuel, vecteurDefini));
                    //Joueur.J1.RetirerBois(50);
                   // print(Joueur.J1.Ress_bois);
                }

            }
        }
    }

    bool EstLegal()
    {
        constructionPossible = batimentActuel.GetComponent<ConstructionPossible>();
        /*Pontentiel amelioration: Diviser la condition afin d'envoyer un message au Joueur
         *Prendre la bonne valeur de chaque consctruction (et non juste 50)
         */
        if (constructionPossible.colliders.Count > 0  /*|| Joueur.J1.Ress_bois<50*/)
        {
            return false;
        }
        return true;

    }
    public void ChoisirBatiment(GameObject b)
    {
        EstPlace = false;
        batimentActuel = ((GameObject)Instantiate(b)).transform;
        batimentActuel.GetComponent<Collider>().isTrigger = true;
    }

    IEnumerator EnConstruction(Transform construction,Vector3 placement)
    {
        Transform f = batimentActuel.Find("Canvas");
        for (float i = 10; i >= 0; i=i-0.3f)
        {
            construction.transform.position = new Vector3(placement.x, placement.y-i, placement.z);
            yield return new WaitForSeconds(0.2f);
        }
        f.gameObject.SetActive(true);

    }
}
