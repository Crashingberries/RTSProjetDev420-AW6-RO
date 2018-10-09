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

    [SerializeField] private float nextActionTime = 5f;
    public float period = 2f;

  
    // Use this for initialization
    void Start()
    {
        anim = GetComponent<Animator>();
        positionCible = transform.position;
        rbody = GetComponent<Rigidbody>();
        
    }

    // Update is called once per frame
    void Update()
    {
        enMouvement = false;
        enRecolte = false;

        SetPositionCible();


        if (enMouvement)
        {
            anim.SetBool("Run", true);
            AllezARecolte();
            
            
        }
    }

    void SetPositionCible()
    {

        positionCible = GameObject.FindGameObjectWithTag("MineOr").transform.position;


        enMouvement = true;

        
    }

    void AllezARecolte()
    {
        transform.LookAt(positionCible);
        transform.position = Vector3.MoveTowards(transform.position, positionCible, vitesse * Time.deltaTime);
       // rbody.AddForce(positionCible);
        if (transform.position == positionCible)
        {
            enRecolte = true;

            enMouvement = false;
            anim.SetBool("Run", false);
          



            if (Time.time > nextActionTime)
            {
                
                nextActionTime = Time.time + period;
                
               
                ActionRecolte();
              


            }
            
        }

        Debug.DrawLine(transform.position, positionCible, Color.red);
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
        if (compteur >= 20)
        {  
            enRecolte = false;
            anim.SetBool("Attack", false);
            Destroy(GameObject.FindGameObjectWithTag("MineOr"));
        }
        else
        {
            anim.SetBool("Attack", true);
            RessourceDuJeu.IncrementerOr();
            compteur++;
        }
     
    }

        
  
}


