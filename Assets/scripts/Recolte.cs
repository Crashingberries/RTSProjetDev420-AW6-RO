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
    Timer ControleAugmentation = new Timer();

    private Vector3 positionCible;
    private bool enMouvement;
    private bool enRecolte = false;

   

    // Use this for initialization
    void Start()
    {
        positionCible = transform.position;
        enMouvement = false;
    }

    // Update is called once per frame
    void Update()
    {

        SetPositionCible();


        if (enMouvement)
        {
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

        if (transform.position == positionCible)
        {
            enMouvement = false;
            enRecolte = true;
            ActionRecolte(null,null);
        }

        Debug.DrawLine(transform.position, positionCible, Color.red);
    }
    private void InitializeTimer()
    {
        compteur = 0;
        ControleAugmentation.Interval = 2000;
        ControleAugmentation.Enabled = true;
        ControleAugmentation.Elapsed += new ElapsedEventHandler(ActionRecolte);
    }

    public void ActionRecolte(object sender, ElapsedEventArgs e)
    {
        if (compteur >= 20)
        {
            ControleAugmentation.Enabled = false;
            enRecolte = false;
           
        }
        else
        {
                               
            RessourceDuJeu.IncrementerOr();
            compteur++;
            
        }
    }

        
  
}


