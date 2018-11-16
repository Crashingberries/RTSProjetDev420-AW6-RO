using System;
using System.Timers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Recolte : MonoBehaviour {

    [SerializeField]
    [Range(1, 20)]
    private float vitesse = 10;

    private static int compteur = 0;

    public static Animator anim;

    Rigidbody rbody;

    

    private Vector3 positionCible;

    public static bool enMouvement;
    public static bool enRecolteOr;
    public static bool arbreFini { get; set; }
    public static bool enRecolteBois;

    [SerializeField] private float nextActionTime = 0f;
    public float period = 2f;


    // Use this for initialization
    void Start()
    {
        anim = GetComponent<Animator>();
        positionCible = transform.position;
        rbody = GetComponent<Rigidbody>();
        positionCible = GameObject.FindGameObjectWithTag("MineOr").transform.position;
        print(positionCible);
    }
    void Update()
    {
        if (enRecolteOr)
        {
            if (Time.time > nextActionTime)
            {
                print("incrémentation");
                nextActionTime = Time.time + period;
                ActionRecolteOr();
            }
        }
        if (enRecolteBois)
        {
            
            
            if (Time.time > nextActionTime)
            {
                anim.SetBool("EnMouvement", false);
                anim.SetBool("Attaque", true);
                print("incrementation bois");
                nextActionTime = Time.time + period;
                ActionRecolteBois();
            }
            //anim.SetBool("Attaque", false);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        
        if (collision.gameObject.name == "MineOr")
        {
            anim.SetBool("Attaque", true);
            enRecolteOr = true;
            print("dans le trigger");
        }
        if (collision.gameObject.tag == "Arbre")
        {
            anim.SetBool("Attaque", true);
            enRecolteBois = true;
            print("dans le trigger");
        }


    }

    private void OnCollisionExitOr(Collision collision)
    {

        anim.SetBool("Attaque",false);
        print("sorti du trigger");
        enRecolteOr = false;
        

    }
    private void OnCollisionExitBois(Collision collision)
    {

        anim.SetBool("Attaque", false);
        print("sorti du trigger");
        enRecolteBois = false;
        

    }

    /* private void InitializeTimer()
     {
         compteur = 0;
         ControleAugmentation.Interval = 2000;
         ControleAugmentation.Enabled = true;
         ControleAugmentation.Elapsed += new ElapsedEventHandler(ActionRecolte);
     }*/

    public void ActionRecolteOr()
    {
        
        RessourceDuJeu.IncrementerOr();
        compteur++;
        if (compteur >= 5)
        {  
            enRecolteOr = false;
            anim.SetBool("Attaque", false);
            Destroy(GameObject.FindGameObjectWithTag("MineOr"));
            compteur = 0;

        }   
    }
   
    public static void ActionRecolteBois()
    {
        
        RessourceDuJeu.IncrementerBois();
        compteur++;
        if (compteur >= 5)
        {
            enRecolteBois = false;
            //Destroy(GameObject.FindGameObjectWithTag("Arbre"));
            
            Debug.Log("Arbre fini");
            arbreFini = true;
            compteur = 0;
        }
    }



}


