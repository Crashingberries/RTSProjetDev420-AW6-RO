using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;


public class ActionsBatiment : NetworkBehaviour
{

    public Transform t_batiment;
    public Vector3 ptdr;
    public GameObject raliement;
    private GameObject raliement2; // COPIE de raliement
    FenetreRessource jRess;
    Joueur j;
    private double pourcentage = 0;

    private bool placer_ptdr;

    public List<GameObject> commandes;

    private GameObject _commande;

    // Use this for initialization
    void Start()
    {
        foreach (Joueur x in GameObject.FindObjectsOfType<Joueur>())
        {
            if (x.isLocalPlayer)
            {
                j = x;
            }
        }
        Debug.Log(j.tag);
        jRess = GameObject.FindObjectOfType<FenetreRessource>();
        t_batiment = GetComponent<Transform>();
        ptdr = new Vector3(t_batiment.position.x + 10, t_batiment.position.y, t_batiment.position.z);
        //print("ptdr " + ptdr);
    }

    // Update is called once per frame
    void Update()
    {
        if (!hasAuthority)
        {
            return;
        }
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
        if (commandes.Count > 0)
        {
            //Debug.Log(commandes[0].GetComponent<Text>().text);
            EnCommande();
        }
    }
    public void EnCommande()
    {
        if (pourcentage >= 0)
        {

            if (pourcentage >= 100)
            {
                string nomTmp = commandes[0].name;
                pourcentage = 0;
                CreerUnit(commandes[0]);
                commandes.RemoveAt(0);
                commandes.TrimExcess();
                UpdateTextButton(nomTmp);
                CacherBoutton(nomTmp);
                Debug.Log(commandes.Count);

            }
            else
            {
                pourcentage += Time.deltaTime * 25; //Peut être modifié par la variable de l'unité en temps que tel pour avoir un temps custom.
                UpdateTextButton(commandes[0].name);
            }
        }
    }
    public void CacherBoutton(string Nom)
    {
        if (commandes.FindAll(unit => unit.name == Nom).Count == 0) { GameObject.Find("btn_comCreate" + Nom).SetActive(false); }

    }
    public void UpdateTextButton(string texte)
    {
        double valeurprc = 0;
        if (commandes.Count == 0 || texte == commandes[0].name)
        {
            valeurprc = pourcentage;
        }
        GameObject.Find("btn_comCreate" + texte).GetComponent<UnityEngine.UI.Button>().GetComponentInChildren<Text>().text = (int)valeurprc + " %\nx" + commandes.FindAll(unit => unit.name == texte).Count;
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
    public void CommanderUnit(GameObject Unit)
    {
        if (jRess.Ress_bois >= 50)
        {
            Debug.Log("Ressources avant le create: "+ jRess.Ress_bois);
            jRess.RetirerBois(50);
            Debug.Log("Ressources APRÈS le create: " + jRess.Ress_bois);
            commandes.Add(Unit);
            UpdateTextButton(Unit.name);
        }
        else
        {
            MessagesToPlayer.PasAssezRessources(jRess.Ress_bois >= 50, true, true);
            if (commandes.FindAll(commandes => commandes == Unit).Count == 0) { GameObject.Find("btn_comCreate" + Unit.name).SetActive(false); }

        }

    }
    public void AnnulerCommande(GameObject unit)
    {   
            int remove = commandes.FindLastIndex(commande => commande == unit);
            if (remove==0) { pourcentage = 0; };
            commandes.RemoveAt(remove);
            UpdateTextButton(unit.name);
            CacherBoutton(unit.name);
            jRess.AjouterBois(50);
    }

    public void CreerUnit(GameObject Unit)
    {
        Vector3 pos = new Vector3(t_batiment.position.x + 10, t_batiment.position.y, t_batiment.position.z);
        Debug.Log("ACTIONBATIMENT::CreerUnit, Tag:"+j.tag);
        j.CreerUnit(j.JoueurManager.GetComponent<PlacementBatiment>().ListeUnit.FindIndex(unite => unite == Unit),pos);
    }
}
