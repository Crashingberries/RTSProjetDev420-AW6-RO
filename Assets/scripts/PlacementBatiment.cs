using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PlacementBatiment : NetworkBehaviour {
    private ConstructionPossible constructionPossible;
    private GameObject batimentActuel = null;
    Camera cam;
    private bool EstPlace;
    public LayerMask coucheBatiment;
    Vector3 vecteurDefini;
    Joueur j;
    [SyncVar]
    public int Construction=0;
    public GameObject BatimentConstruction;
    public List<GameObject> ListeBatiment;
    public List<GameObject> ListeUnit;
    // Use this for initialization
    void Start() {
        cam = GetComponent<Camera>();
        j = GameObject.FindObjectOfType<Joueur>();
        j.SetAuth(GetComponent<NetworkIdentity>().netId, j.gameObject.GetComponent<NetworkIdentity>());

    }
    // Update is called once per frame
    void Update() {
        if (!hasAuthority) { gameObject.SetActive(false); }
        gameObject.SetActive(true);
        if (batimentActuel != null)
        {
            RaycastHit hit;
            Ray ray = new Ray(transform.position, transform.forward);
            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit) && EstPlace == false)
            {
                vecteurDefini.Set(hit.point.x, hit.collider.transform.position.y, hit.point.z);
                batimentActuel.transform.position = vecteurDefini;
            }
            if (Input.GetMouseButtonDown(0))
            {
                if (EstLegal())
                {
                    EstPlace = true;
                    if (batimentActuel.transform.Find("Quad").gameObject.activeSelf)
                    {
                        //test.SetActive(false);
                        //RessourceDuJeu.SetMontantBois(-10);
                        //RessourceDuJeu.SetMontantOr(-10);
                        batimentActuel.GetComponent<Collider>().isTrigger = false;
                        Debug.Log("Avant d'envoyer la création: " + j + "Est-ce que j'ai les droits?" + hasAuthority);
                        j.ActionCreationBatiment(Construction, vecteurDefini);
                        Destroy(batimentActuel.gameObject); 
                        //Joueur.J1.RetirerBois(50);
                        // print(Joueur.J1.Ress_bois);
                    }
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
        Construction=ListeBatiment.FindIndex(batiment => batiment == b);
        batimentActuel =Instantiate(b);
        batimentActuel.GetComponent<Collider>().isTrigger = true;

    }
}
