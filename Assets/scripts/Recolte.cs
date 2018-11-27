using System;
using System.Timers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Recolte : MonoBehaviour {

    [SerializeField]
    [Range(1, 20)]
    private float vitesse = 10;

    private int compteur;

    Animator anim;

    Rigidbody rbody;



    private Vector3 positionCible;

    private bool enMouvement;
    private bool enRecolte;

    [SerializeField] private float nextActionTime = 0f;
    public float period = 2f;


    // Use this for initialization
    void Start()
    {
        anim = GetComponent<Animator>();
        positionCible = transform.position;
        rbody = GetComponent<Rigidbody>();

    }
    void Update()
    {
        if (enRecolte)
        {
            if (Time.time > nextActionTime)
            {
                print("incrémentation");
                nextActionTime = Time.time + period;
                ActionRecolte();
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.name == "MineOr")
        {
            anim.SetBool("Attaque", true);
            enRecolte = true;
            print("dans le trigger");
        }

    }

    private void OnCollisionExit(Collision collision)
    {

        anim.SetBool("Attaque",false);
        //print("sorti du trigger");
        enRecolte = false;

    }

   /* private void InitializeTimer()
    {
        compteur = 0;
        ControleAugmentation.Interval = 2000;
        ControleAugmentation.Enabled = true;
        ControleAugmentation.Elapsed += new ElapsedEventHandler(ActionRecolte);
    }*/

    public void ActionRecolte()
    {
        RessourceDuJeu.SetMontantOr(1);
        compteur++;
        if (compteur >= 5)
        {
            enRecolte = false;
            anim.SetBool("Attaque", false);
            Destroy(GameObject.FindGameObjectWithTag("MineOr"));

        }
    }



}
