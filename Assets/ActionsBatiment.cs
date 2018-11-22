using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActionsBatiment : MonoBehaviour
{

    public Transform t_batiment;
    public Vector3 ptdr;
    public GameObject raliement;
    private GameObject raliement2; // COPIE de raliement

    private bool placer_ptdr;
    /*
    private int ouvrier_commande = 0;
    private int fanta_commande = 0;
    private int archer_commande = 0;
    private int lancier_commande = 0;
    private int chevalier_commande = 0;

    private int ouvrier_pour = 0;
    private int fanta_pour = 0;
    private int archer_pour = 0;
    private int lancier_pour = 0;
    private int chevalier_pour = 0;

    private float ouvrier_debut;
    private float fanta_debut;
    private float archer_debut;
    private float lancier_debut;
    private float chevalier_debut;


    private Queue<GameObject> commandes = new Queue<GameObject>(30);

    private GameObject _commande;
    */

    // Use this for initialization
    void Start()
    {
        t_batiment = GetComponent<Transform>();
        ptdr = new Vector3(t_batiment.position.x + 10, t_batiment.position.y, t_batiment.position.z);
        //print("ptdr " + ptdr);
    }

    // Update is called once per frame
    void Update()
    {
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


    //private void TrucCommande()
    //{
    //    if (ouvrier_commande > 0)
    //    {
    //        if (ouvrier_pour >= 100)
    //        {
    //            ouvrier_pour = 0;
    //            AnnulerCommandeUnit(commandes.Peek());
    //        }
    //        else
    //        {
    //            if (Time.time - ouvrier_debut >= 0.2 && "Ouvrier".Equals(commandes.Peek().tag)) { ouvrier_pour++; ouvrier_debut = Time.time; }
    //            commandes.Peek().GetComponentInChildren<Text>().text = ouvrier_pour + "%\nx" + ouvrier_commande;
    //        }
    //    }
    //    if (fanta_commande > 0)
    //    {
    //        if (fanta_pour >= 100)
    //        {
    //            fanta_pour = 0;
    //            AnnulerCommandeUnit(commandes.Peek());
    //        }
    //        else
    //        {
    //            if (Time.time - fanta_debut >= 0.2 && "Fantassin".Equals(commandes.Peek().tag)) { fanta_pour++; fanta_debut = Time.time; }
    //            commandes.Peek().GetComponentInChildren<Text>().text = fanta_pour + "%\nx" + fanta_commande;
    //        }
    //    }
    //    if (archer_commande > 0)
    //    {
    //        if (archer_pour >= 100)
    //        {
    //            archer_pour = 0;
    //            AnnulerCommandeUnit(commandes.Peek());
    //        }
    //        else
    //        {
    //            if (Time.time - archer_debut >= 0.2 && "Archer".Equals(commandes.Peek().tag)) { archer_pour++; archer_debut = Time.time; }
    //            commandes.Peek().GetComponentInChildren<Text>().text = archer_pour + "%\nx" + archer_commande;
    //        }
    //    }
    //    if (lancier_commande > 0)
    //    {
    //        if (lancier_pour >= 100)
    //        {
    //            lancier_pour = 0;
    //            AnnulerCommandeUnit(commandes.Peek());
    //        }
    //        else
    //        {
    //            if (Time.time - lancier_debut >= 0.2 && "Lancier".Equals(commandes.Peek().tag)) { lancier_pour++; lancier_debut = Time.time; }
    //            commandes.Peek().GetComponentInChildren<Text>().text = lancier_pour + "%\nx" + lancier_commande;
    //        }
    //    }
    //}
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

    //public void CommanderUnit(GameObject commande)
    //{
    //    commandes.Enqueue(commande);
    //    _commande = commandes.Peek();
    //    switch (commande.tag)
    //    {
    //        case "Ouvrier":
    //            ouvrier_debut = Time.time;
    //            if (ouvrier_commande == 0)
    //            {
    //                commande.SetActive(true);
    //            }
    //            ouvrier_commande++;
    //            commande.GetComponentInChildren<Text>().text = "0%\nx" + ouvrier_commande;
    //            break;
    //        case "Fantassin":
    //            fanta_debut = Time.time;
    //            if (fanta_commande == 0)
    //            {
    //                commande.SetActive(true);
    //            }
    //            fanta_commande++;
    //            commande.GetComponentInChildren<Text>().text = "0%\nx" + fanta_commande;
    //            break;
    //        case "Archer":
    //            archer_debut = Time.time;
    //            if (archer_commande == 0)
    //            {
    //                commande.SetActive(true);
    //            }
    //            archer_commande++;
    //            commande.GetComponentInChildren<Text>().text = "0%\nx" + archer_commande;
    //            break;
    //        case "Lancier":
    //            lancier_debut = Time.time;
    //            if (lancier_commande == 0)
    //            {
    //                commande.SetActive(true);
    //            }
    //            lancier_commande++;
    //            commande.GetComponentInChildren<Text>().text = "0%\nx" + lancier_commande;
    //            break;
    //        case "Chevalier":
    //            chevalier_debut = Time.time;
    //            if (chevalier_commande == 0)
    //            {
    //                commande.SetActive(true);
    //            }
    //            chevalier_commande++;
    //            commande.GetComponentInChildren<Text>().text = "0%\nx" + chevalier_commande;
    //            break;
    //    }
    //}

    //public void AnnulerCommandeUnit(GameObject commande)
    //{
    //    if (commande == commandes.Peek()) { commandes.Dequeue(); }
    //    _commande = commandes.Peek();
    //    switch (commande.tag)
    //    {
    //        case "Ouvrier":
    //            ouvrier_pour = 0;
    //            ouvrier_debut = Time.time;
    //            if (ouvrier_commande <= 1)
    //            {
    //                commande.SetActive(false);
    //            }
    //            ouvrier_commande--;
    //            Joueur.J1.AjouterBois(50);
    //            commande.GetComponentInChildren<Text>().text = "0%\nx" + ouvrier_commande;
    //            break;
    //        case "Fantassin":
    //            fanta_pour = 0;
    //            fanta_debut = Time.time;
    //            if (fanta_commande <= 1)
    //            {
    //                commande.SetActive(false);
    //            }
    //            fanta_commande--;
    //            Joueur.J1.AjouterBois(50);
    //            commande.GetComponentInChildren<Text>().text = "0%\nx" + fanta_commande;
    //            break;
    //        case "Archer":
    //            archer_pour = 0;
    //            archer_debut = Time.time;
    //            if (archer_commande <= 1)
    //            {
    //                commande.SetActive(false);
    //            }
    //            archer_commande--;
    //            Joueur.J1.AjouterBois(50);
    //            commande.GetComponentInChildren<Text>().text = "0%\nx" + archer_commande;
    //            break;
    //        case "Lancier":
    //            lancier_pour = 0;
    //            lancier_debut = Time.time;
    //            if (lancier_commande <= 1)
    //            {
    //                commande.SetActive(false);
    //            }
    //            lancier_commande--;
    //            Joueur.J1.AjouterBois(50);
    //            commande.GetComponentInChildren<Text>().text = "0%\nx" + lancier_commande;
    //            break;
    //        case "Chevalier":
    //            chevalier_pour = 0;
    //            chevalier_debut = Time.time;
    //            if (chevalier_commande <= 1)
    //            {
    //                commande.SetActive(false);
    //            }
    //            chevalier_commande--;
    //            Joueur.J1.AjouterBois(50);
    //            commande.GetComponentInChildren<Text>().text = "0%\nx" + chevalier_commande;
    //            break;
    //    }
    //}

    public void CreerUnit(GameObject bouton)
    {
        if (Joueur.J1.Ress_bois >= 50)
        {
            Joueur.J1.RetirerBois(50);
            Vector3 pos = new Vector3(t_batiment.position.x + 10, t_batiment.position.y, t_batiment.position.z);
            ConstructionUnite(bouton);
            //GameObject f = Instantiate(unit, pos, t_batiment.rotation);
            //f.SendMessage("SetRaliementCible", ptdr);
        }
        else
        {
            MessagesToPlayer.PasAssezRessources(Joueur.J1.Ress_bois >= 50, true, true);
        }
        //print(Joueur.J1.Ress_bois);
    }
    public void ConstructionUnite(GameObject bouton)
    {

    }
}
