using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttaqueManager : MonoBehaviour {
    public bool alerte;
    public int rayon;
    public int portee;

    //public Rigidbody cible;
    GameObject[] ennemis;

    public HealthManager pv_ennemi;
    public Rigidbody r_attaquant;
    public AudioSource _se_degats;
    public AudioSource _se_detruit;
    bool detruit = false;
    public float vitesseAttaque = (float)1.5;
    private float nextfire;
    Animator anim;

    // Use this for initialization
    void Start () {
        //pv_ennemi = GameObject.Find("Slider").GetComponent<HealthManager>();
        //cible = GameObject.Find("Ennemi").GetComponent<Rigidbody>();
        rayon = 100;
        portee = 10;
        alerte = true;
        anim = GameObject.Find("Allie").GetComponent<Animator>();
        r_attaquant = GameObject.Find("Allie").GetComponent<Rigidbody>();
    }
	
	// Update is called once per frame
	void Update () {
        ennemis = GameObject.FindGameObjectsWithTag("Ennemi");
        
        Alerter();
        IsInRange();
    }

    public void Alerter()
    {
        //if((r_attaquant.position.x - cible.position.x <= rayon && r_attaquant.position.x - cible.position.x >= -rayon) && (r_attaquant.position.z - cible.position.z <=rayon && r_attaquant.position.z - cible.position.z >= -rayon))
        //{
        //    print("ALERTER");
        //    Deplacer(cible.position.x, cible.position.z);
        //}
        //r_attaquant.MovePosition(new Vector3());
        float _x = r_attaquant.position.x;
        float _z = r_attaquant.position.z;
    }

    public void Deplacer(float x, float z)
    {
        if (!Input.anyKey)
        {
            if (r_attaquant.position.x > x)
            {
                r_attaquant.MovePosition(new Vector3(r_attaquant.position.x - 1, r_attaquant.position.y, r_attaquant.position.z));
            }
            else if (r_attaquant.position.x < x)
            {
                r_attaquant.MovePosition(new Vector3(r_attaquant.position.x + 1, r_attaquant.position.y, r_attaquant.position.z));
            }
            if (r_attaquant.position.z > z)
            {
                r_attaquant.MovePosition(new Vector3(r_attaquant.position.x, r_attaquant.position.y, r_attaquant.position.z - 1));
            }
            else if (r_attaquant.position.z < z)
            {
                r_attaquant.MovePosition(new Vector3(r_attaquant.position.x, r_attaquant.position.y, r_attaquant.position.z + 1));
            }
        }
    }

    public void IsInRange()
    {
        for (int i=0; i<ennemis.Length; i++)
        {

            Rigidbody cible = ennemis[i].GetComponent<Rigidbody>();
            Animator ennemi_anim= ennemis[i].GetComponent<Animator>();
            if ((r_attaquant.position.x - cible.position.x <= portee && r_attaquant.position.x - cible.position.x >= -portee) && (r_attaquant.position.z - cible.position.z <= portee && r_attaquant.position.z - cible.position.z >= -portee))
            {
 
                Attaquer(ennemis[i]);
                break;

            }
            else
            {
                
                ennemi_anim.ResetTrigger("SubirDegat");
            }
        }
    }

    public void Attaquer(GameObject cible)
    {
        anim.SetBool("Attaque", true);
        HealthManager hm_cible = cible.GetComponentInChildren<HealthManager>();
        anim.SetBool("Attaque", false);
        if (Time.time > nextfire)
        {
            print("Attaque : " + cible.name + ", PV : " + hm_cible.PvBar.name);
            nextfire = Time.time + vitesseAttaque;
            
            if (hm_cible.PvBar.value != 0)
            {
                anim.SetBool("Attaque", true);
                // _se_degats.Play();
                hm_cible.SubirDegats(15);
                cible.GetComponent<Animator>().SetTrigger("SubirDegat");
            }
            else
            {
                if (!detruit)
                {
                    //  _se_detruit.Play();
                    detruit = true;
                }
                else
                {
                    cible.GetComponent<Animator>().SetTrigger("EstMort");
                    Destroy(cible);
                }
            }
        }

    }
}
