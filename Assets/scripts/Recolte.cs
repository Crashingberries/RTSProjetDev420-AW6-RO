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
    private GameObject ressource;

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
        rbody = GetComponent<Rigidbody>();

    }
    void Update()
    {
        if (enRecolte)
        {
            if (Time.time > nextActionTime)
            {
                nextActionTime = Time.time + period;
                ActionRecolte();
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.tag == "MineOr")
        {

            StartAnimation();
            ressource = collision.gameObject;
        }
        else if (collision.gameObject.tag == "Arbre")
        {
            StartAnimation();
            ressource = collision.gameObject;
        }

    }

    private void OnCollisionExit(Collision collision)
    {

        StopAnimation();

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
        if (ressource.tag=="MineOr")
        {
            try
            {
                //ressource.GetComponent<Minerai>().Recolte();
            }
            catch
            {
                StopAnimation();
            }
        }
        else if (ressource.tag=="Arbre")
        {
            try
            {
                ressource.GetComponent<Arbre>().Recolte();
            }
            catch
            {
                StopAnimation();
            }
        }
    }
    public void StopAnimation()
    {
        anim.SetBool("Attaque", false);
        enRecolte = false;
    }
    public void StartAnimation()
    {
        anim.SetBool("Attaque", true);
        enRecolte = true;
    }



}
