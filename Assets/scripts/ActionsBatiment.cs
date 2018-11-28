using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActionsBatiment : MonoBehaviour
{

    public Transform t_batiment;
    public Vector3 ptdr;
    public GameObject raliement;
    private GameObject raliement2; // COPIE de raliement

    private int pourcentage = 0;

    private bool placer_ptdr;

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

    public List<GameObject> commandes;

    private GameObject _commande;

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
        if (commandes.Count > 0)
        {
            //Debug.Log(commandes[0].GetComponent<Text>().text);
            EnCommande();
        }
        //if(ouvrier_commande > 0)
        //{
        //    if(ouvrier_pour >= 100)
        //    {
        //        ouvrier_pour = 0;
        //        AnnulerCommandeUnit(commandes.First.Value);
        //        //Instantiate(unit, pos, t_batiment.rotation);
        //    }
        //    else
        //    {
        //        if (Time.time - ouvrier_debut >= 0.2 && "Ouvrier".Equals(commandes.First.Value.tag)) { ouvrier_pour++; ouvrier_debut = Time.time; commandes.First.Value.GetComponentInChildren<Text>().text = ouvrier_pour + "%\nx" + ouvrier_commande; }
        //    }
        //}

        //if (archer_commande > 0)
        //{
        //    if (archer_pour >= 100)
        //    {
        //        archer_pour = 0;
        //        AnnulerCommandeUnit(commandes[1]);
        //        //Instantiate(unit, pos, t_batiment.rotation);
        //    }
        //    else
        //    {
        //        if (Time.time - archer_debut >= 0.2 && "Archer".Equals(commandes.First.Value.tag)) { archer_pour++; archer_debut = Time.time; commandes.First.Value.GetComponentInChildren<Text>().text = archer_pour + "%\nx" + archer_commande; }
        //    }
        //}
        //if (fanta_commande > 0)
        //{
        //    if (fanta_pour >= 100)
        //    {
        //        fanta_pour = 0;
        //        AnnulerCommandeUnit(commandes.First.Value);
        //        //Instantiate(unit, pos, t_batiment.rotation);
        //    }
        //    else
        //    {
        //        if (Time.time - fanta_debut >= 0.2 && "Fantassin".Equals(commandes.First.Value.tag)) { fanta_pour++; fanta_debut = Time.time; commandes.First.Value.GetComponentInChildren<Text>().text = fanta_pour + "%\nx" + fanta_commande; }
        //    }
        //}
        //if (lancier_commande > 0)
        //{
        //    if (lancier_pour >= 100)
        //    {
        //        lancier_pour = 0;
        //        AnnulerCommandeUnit(commandes.First.Value);
        //        //Instantiate(unit, pos, t_batiment.rotation);
        //    }
        //    else
        //    {
        //        if (Time.time - lancier_debut >= 0.2 && "Lancier".Equals(commandes.First.Value.tag)) { lancier_pour++; lancier_debut = Time.time; commandes.First.Value.GetComponentInChildren<Text>().text = lancier_pour + "%\nx" + lancier_commande; }
        //    }
        //}
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
                pourcentage++;
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
        int valeurprc = 0;
        if (commandes.Count==0 || texte == commandes[0].name)
        {
            valeurprc = pourcentage;
        }
        GameObject.Find("btn_comCreate" + texte).GetComponent<UnityEngine.UI.Button>().GetComponentInChildren<Text>().text = valeurprc + " %\nx" + commandes.FindAll(unit => unit.name == texte).Count;
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
        commandes.Add(Unit);
        UpdateTextButton(Unit.name);
    }

    //public void CommanderUnit(GameObject commande)
    //{
    //    commandes.AddLast(commande);
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
    //    if (commande == commandes.First.Value)
    //    {
    //        commandes.RemoveFirst();
    //    }
    //    else
    //    {
    //        commandes.Remove(commande);
    //    }
    //}

    public void CreerUnit(GameObject commande)
    {
        if (Joueur.J1.Ress_bois >= 50)
        {
            Joueur.J1.RetirerBois(50);
            Vector3 pos = new Vector3(t_batiment.position.x + 10, t_batiment.position.y, t_batiment.position.z);
            //CommanderUnit(commande);
            //GameObject f = Instantiate(unit, pos, t_batiment.rotation);
            //f.SendMessage("SetRaliementCible", ptdr);
        }
        else
        {
            MessagesToPlayer.PasAssezRessources(Joueur.J1.Ress_bois >= 50, true, true);
        }
        //print(Joueur.J1.Ress_bois);
    }
}
